//------------------------------------------------------------------------------
// <copyright file="XmlSiteMapProvider.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

/*
 * XmlSiteMapProvider class definition
 *
 * Copyright (c) 2002 Microsoft Corporation
 */

namespace THS.UMS.AO.Providers
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Configuration.Provider;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using System.Web;
    using System.Web.Hosting;
    using System.Xml;

    // XmlMapProvider that generates sitemap tree from xml files

    public class XmlSiteMapProvider : StaticSiteMapProvider, IDisposable
    {

        private string _filename;
        private String _virtualPath;
        private String _normalizedVirtualPath;
        private SiteMapNode _siteMapNode;
        private XmlDocument _document;
        private bool _initialized;
        //private FileChangeEventHandler _handler;
        private StringCollection _parentSiteMapFileCollection;

        private const string ProviderAttribute = "provider";
        private const string SiteMapFileAttribute = "siteMapFile";
        private const string SiteMapNodeName = "siteMapNode";
        private const string XmlSiteMapFileExtension = ".sitemap";
        private const string ResourcePrefix = "$resources:";
        private const String SecurityTrimmingEnabledAttrName = "securityTrimmingEnabled";
        private const int ResourcePrefixLength = 10;
        private const char ResourceKeySeparator = ',';
        private static readonly char[] Seperators = new[] { ';', ',' };

        private ArrayList _childProviderList;

        // table containing mappings from child providers to their root nodes.
        private Hashtable _childProviderTable;


        private ArrayList ChildProviderList
        {
            get
            {
                if (_childProviderList == null)
                {
                    lock (_lock)
                    {
                        if (_childProviderList == null)
                        {
                            _childProviderList = ArrayList.ReadOnly(new ArrayList(ChildProviderTable.Keys));
                        }
                    }
                }

                return _childProviderList;
            }
        }

        private Hashtable ChildProviderTable
        {
            get
            {
                if (_childProviderTable == null)
                {
                    lock (_lock)
                    {
                        if (_childProviderTable == null)
                        {
                            _childProviderTable = new Hashtable();
                        }
                    }
                }

                return _childProviderTable;
            }
        }


        public override SiteMapNode RootNode
        {
            get
            {
                BuildSiteMap();
                return ReturnNodeIfAccessible(_siteMapNode);
            }
        }

        protected override void AddNode(SiteMapNode node, SiteMapNode parentNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (parentNode == null)
            {
                throw new ArgumentNullException("parentNode");
            }

            SiteMapProvider ownerProvider = node.Provider;
            SiteMapProvider parentOwnerProvider = parentNode.Provider;

            if (ownerProvider != this)
            {
                throw new ArgumentException(SR.GetString(SR.XmlSiteMapProviderCannotAddNode, node.ToString()), "node");
            }

            if (parentOwnerProvider != this)
            {
                throw new ArgumentException(SR.GetString(SR.XmlSiteMapProviderCannotAddNode, parentNode.ToString()), "parentNode");
            }

            lock (_lock)
            {
                // First remove it from its current location.
                RemoveNode(node);
                AddNodeInternal(node, parentNode, null);
            }
        }

        private void AddNodeInternal(SiteMapNode node, SiteMapNode parentNode, XmlNode xmlNode)
        {
            lock (_lock)
            {
                String url = node.Url;
                String key = node.Key;

                bool isValidUrl = false;

                // Only add the node to the url table if it's a static node.
                if (!String.IsNullOrEmpty(url))
                {
                    if (UrlTable[url] != null)
                    {
                        if (xmlNode != null)
                        {
                            throw new ConfigurationErrorsException(
                                SR.GetString(SR.XmlSiteMapProviderMultipleNodesWithIdenticalUrl, url),
                                xmlNode);
                        }
                        throw new InvalidOperationException(SR.GetString(
                            SR.XmlSiteMapProviderMultipleNodesWithIdenticalUrl, url));
                    }

                    isValidUrl = true;
                }

                if (KeyTable.Contains(key))
                {
                    if (xmlNode != null)
                    {
                        throw new ConfigurationErrorsException(
                            SR.GetString(SR.XmlSiteMapProviderMultipleNodesWithIdenticalKey, key),
                            xmlNode);
                    }
                    throw new InvalidOperationException(
                        SR.GetString(SR.XmlSiteMapProviderMultipleNodesWithIdenticalKey, key));
                }

                if (isValidUrl)
                {
                    UrlTable[url] = node;
                }

                KeyTable[key] = node;

                // Add the new node into parentNode collection
                if (parentNode != null)
                {
                    ParentNodeTable[node] = parentNode;

                    if (ChildNodeCollectionTable[parentNode] == null)
                    {
                        ChildNodeCollectionTable[parentNode] = new SiteMapNodeCollection();
                    }

                    ((SiteMapNodeCollection)ChildNodeCollectionTable[parentNode]).Add(node);
                }
            }
        }

        protected virtual void AddProvider(string providerName, SiteMapNode parentNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException("parentNode");
            }

            if (parentNode.Provider != this)
            {
                throw new ArgumentException(SR.GetString(SR.XmlSiteMapProviderCannotAddNode, parentNode.ToString()), "parentNode");
            }

            SiteMapNode node = GetNodeFromProvider(providerName);
            AddNodeInternal(node, parentNode, null);
        }


        public override SiteMapNode BuildSiteMap()
        {

            SiteMapNode tempNode = _siteMapNode;

            // If siteMap is already constructed, simply returns it.
            // Child providers will only be updated when the parent providers need to access them.
            if (tempNode != null)
            {
                return tempNode;
            }

            XmlDocument document = GetConfigDocument();

            lock (_lock)
            {
                if (_siteMapNode != null)
                {
                    return _siteMapNode;
                }

                Clear();

                // Need to check if the sitemap file exists before opening it.
                CheckSiteMapFileExists();

                try
                {
                    using (Stream stream = HostingEnvironment.VirtualPathProvider.GetFile(_normalizedVirtualPath).Open())
                    {
                        XmlReader reader = new XmlTextReader(stream);
                        document.Load(reader);
                    }
                }
                catch (Exception e)
                {
                    throw new ConfigurationErrorsException(
                        SR.GetString(SR.XmlSiteMapProviderErrorLoadingConfigFile, _virtualPath, e.Message), e);
                }

                XmlNode node = document.ChildNodes.Cast<XmlNode>().FirstOrDefault(siteMapMode => String.Equals(siteMapMode.Name, "siteMap", StringComparison.Ordinal));

                if (node == null)
                    throw new ConfigurationErrorsException(
                        SR.GetString(SR.XmlSiteMapProviderTopElementMustBeSiteMap),
                        document);

                bool enableLocalization = false;
                SecUtility.GetAndRemoveBooleanAttribute(node, "enableLocalization", ref enableLocalization);
                EnableLocalization = enableLocalization;

                XmlNode topElement = null;
                foreach (XmlNode subNode in node.ChildNodes)
                {
                    if (subNode.NodeType == XmlNodeType.Element)
                    {
                        if (!SiteMapNodeName.Equals(subNode.Name))
                        {
                            throw new ConfigurationErrorsException(
                                SR.GetString(SR.XmlSiteMapProviderOnlySiteMapNodeAllowed),
                                subNode);
                        }

                        if (topElement != null)
                        {
                            throw new ConfigurationErrorsException(
                                SR.GetString(SR.XmlSiteMapProviderOnlyOneSiteMapNodeRequiredAtTop),
                                subNode);
                        }

                        topElement = subNode;
                    }
                }

                if (topElement == null)
                {
                    throw new ConfigurationErrorsException(
                         SR.GetString(SR.XmlSiteMapProviderOnlyOneSiteMapNodeRequiredAtTop),
                         node);
                }

                var queue = new Queue(50);

                // The parentnode of the top node does not exist,
                // simply add a null to satisfy the ConvertFromXmlNode condition.
                queue.Enqueue(null);
                queue.Enqueue(topElement);
                _siteMapNode = ConvertFromXmlNode(queue);

                return _siteMapNode;
            }
        }

        private void CheckSiteMapFileExists()
        {
            if (!HostingEnvironment.VirtualPathProvider.FileExists(_normalizedVirtualPath))
            {
                throw new InvalidOperationException(
                    SR.GetString(SR.XmlSiteMapProviderFileNameDoesNotExist, _virtualPath));
            }
        }


        protected override void Clear()
        {
            lock (_lock)
            {
                ChildProviderTable.Clear();
                _siteMapNode = null;
                _childProviderList = null;

                base.Clear();
            }
        }

        // helper method to convert an XmlNode to a SiteMapNode
        private SiteMapNode ConvertFromXmlNode(Queue queue)
        {

            SiteMapNode rootNode = null;
            while (true)
            {
                if (queue.Count == 0)
                {
                    return rootNode;
                }

                var parentNode = (SiteMapNode)queue.Dequeue();
                var xmlNode = (XmlNode)queue.Dequeue();

                SiteMapNode node;

                if (!SiteMapNodeName.Equals(xmlNode.Name))
                {
                    throw new ConfigurationErrorsException(
                        SR.GetString(SR.XmlSiteMapProviderOnlySiteMapNodeAllowed),
                        xmlNode);
                }

                string providerName = null;
                SecUtility.GetAndRemoveNonEmptyStringAttribute(xmlNode, ProviderAttribute, ref providerName);

                // If the siteMapNode references another provider
                if (providerName != null)
                {
                    node = GetNodeFromProvider(providerName);

                    // No other attributes or child nodes are allowed on a provider node.
                    SecUtility.CheckForUnrecognizedAttributes(xmlNode);
                    SecUtility.CheckForNonCommentChildNodes(xmlNode);
                }
                else
                {
                    string siteMapFile = null;
                    SecUtility.GetAndRemoveNonEmptyStringAttribute(xmlNode, SiteMapFileAttribute, ref siteMapFile);

                    node = siteMapFile != null ? GetNodeFromSiteMapFile(xmlNode, siteMapFile) : GetNodeFromXmlNode(xmlNode, queue);
                }

                AddNodeInternal(node, parentNode, xmlNode);

                if (rootNode == null)
                {
                    rootNode = node;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            //if (_handler != null)
            //{
            //    Debug.Assert(_filename != null);
            //    HttpRuntime.FileChangesMonitor.StopMonitoringFile(_filename, _handler);
            //}
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void EnsureChildSiteMapProviderUpToDate(SiteMapProvider childProvider)
        {
            var oldNode = (SiteMapNode)ChildProviderTable[childProvider];

            SiteMapNode newNode = ((XmlSiteMapProvider)childProvider).GetRootNodeCore();
            if (newNode == null)
            {
                throw new ProviderException(SR.GetString(SR.XmlSiteMapProviderInvalidSitemapnodeReturned, childProvider.Name));
            }

            // child providers have been updated.
            if (!oldNode.Equals(newNode))
            {
                lock (_lock)
                {
                    oldNode = (SiteMapNode)ChildProviderTable[childProvider];
                    // If the child provider table has been updated, simply return null. See above.
                    if (oldNode == null)
                    {
                        return;
                    }

                    newNode = ((XmlSiteMapProvider)childProvider).GetRootNodeCore();
                    if (newNode == null)
                    {
                        throw new ProviderException(SR.GetString(SR.XmlSiteMapProviderInvalidSitemapnodeReturned, childProvider.Name));
                    }

                    if (!oldNode.Equals(newNode))
                    {

                        // If the current provider does not contain any nodes but one child provider
                        // ie. _siteMapNode == oldNode
                        // the oldNode needs to be removed from Url table and the new node will be added.
                        if (_siteMapNode.Equals(oldNode))
                        {
                            UrlTable.Remove(oldNode.Url);
                            KeyTable.Remove(oldNode.Key);

                            UrlTable.Add(newNode.Url, newNode);
                            KeyTable.Add(newNode.Key, newNode);

                            _siteMapNode = newNode;
                        }

                        // First find the parent node
                        var parent = (SiteMapNode)ParentNodeTable[oldNode];

                        // parent is null when the provider does not contain any static nodes, ie.
                        // it only contains definition to include one child provider.
                        if (parent != null)
                        {
                            // Update the child nodes table
                            var list = (SiteMapNodeCollection)ChildNodeCollectionTable[parent];

                            // Add the newNode to where the oldNode is within parent node's collection.
                            int index = list.IndexOf(oldNode);
                            if (index != -1)
                            {
                                list.Remove(oldNode);
                                list.Insert(index, newNode);
                            }
                            else
                            {
                                list.Add(newNode);
                            }

                            // Update the parent table
                            ParentNodeTable[newNode] = parent;
                            ParentNodeTable.Remove(oldNode);

                            // Update the Url table
                            UrlTable.Remove(oldNode.Url);
                            KeyTable.Remove(oldNode.Key);

                            UrlTable.Add(newNode.Url, newNode);
                            KeyTable.Add(newNode.Key, newNode);
                        }
                        else
                        {
                            // Notify the parent provider to update its child provider collection.
                            var provider = ParentProvider as XmlSiteMapProvider;
                            if (provider != null)
                            {
                                provider.EnsureChildSiteMapProviderUpToDate(this);
                            }
                        }

                        // Update provider nodes;
                        ChildProviderTable[childProvider] = newNode;
                        _childProviderList = null;
                    }
                }
            }
        }

        // Returns sitemap node; Search recursively in child providers if not found.

        public override SiteMapNode FindSiteMapNode(string rawUrl)
        {
            var node = base.FindSiteMapNode(rawUrl);

            if (node == null)
            {
                foreach (SiteMapProvider provider in ChildProviderList)
                {
                    // First make sure the child provider is up-to-date.
                    EnsureChildSiteMapProviderUpToDate(provider);

                    node = provider.FindSiteMapNode(rawUrl);
                    if (node != null)
                    {
                        return node;
                    }
                }
            }

            return node;
        }

        // Returns sitemap node; Search recursively in child providers if not found.
        public override SiteMapNode FindSiteMapNodeFromKey(string key)
        {
            SiteMapNode node = base.FindSiteMapNodeFromKey(key);

            if (node == null)
            {
                foreach (SiteMapProvider provider in ChildProviderList)
                {
                    // First make sure the child provider is up-to-date.
                    EnsureChildSiteMapProviderUpToDate(provider);

                    node = provider.FindSiteMapNodeFromKey(key);
                    if (node != null)
                    {
                        return node;
                    }
                }
            }

            return node;
        }

        private XmlDocument GetConfigDocument()
        {
            if (_document != null)
                return _document;

            if (!_initialized)
            {
                throw new InvalidOperationException(
                    SR.GetString(SR.XmlSiteMapProviderNotInitialized));
            }

            // Do the error checking here
            if (_virtualPath == null)
            {
                throw new ArgumentException(
                    SR.GetString(SR.XmlSiteMapProviderMissingSiteMapFile, SiteMapFileAttribute));
            }

            if (!Path.GetExtension(_virtualPath).Equals(XmlSiteMapFileExtension, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    SR.GetString(SR.XmlSiteMapProviderInvalidExtension, _virtualPath));
            }

            // Ensure the appdomain virtualpath has proper trailing slash
            _normalizedVirtualPath =
                VirtualPathUtility.Combine(AppDomainAppVirtualPathWithTrailingSlash, _virtualPath);

            // Make sure the file exists
            CheckSiteMapFileExists();

            _parentSiteMapFileCollection = new StringCollection();
            var xmlParentProvider = ParentProvider as XmlSiteMapProvider;
            if (xmlParentProvider != null && xmlParentProvider._parentSiteMapFileCollection != null)
            {
                if (xmlParentProvider._parentSiteMapFileCollection.Contains(_normalizedVirtualPath))
                {
                    throw new InvalidOperationException(
                        SR.GetString(SR.XmlSiteMapProviderFileNameAlreadyInUse, _virtualPath));
                }

                // Copy the sitemapfiles in used from parent provider to current provider.
                foreach (string filename in xmlParentProvider._parentSiteMapFileCollection)
                {
                    _parentSiteMapFileCollection.Add(filename);
                }
            }

            // Add current sitemap file to the collection
            _parentSiteMapFileCollection.Add(_normalizedVirtualPath);

            _filename = HostingEnvironment.MapPath(_normalizedVirtualPath);

            if (!String.IsNullOrEmpty(_filename))
            {
                //_handler = new FileChangeEventHandler(this.OnConfigFileChange);
                //HttpRuntime.FileChangesMonitor.StartMonitoringFile(_filename, _handler);
                ResourceKey = (new FileInfo(_filename)).Name;
            }

            _document = new ConfigXmlDocument();

            return _document;
        }

        private SiteMapNode GetNodeFromProvider(string providerName)
        {
            SiteMapProvider provider = GetProviderFromName(providerName);

            // Check infinite recursive sitemap files
            if (provider is XmlSiteMapProvider)
            {
                var xmlProvider = (XmlSiteMapProvider)provider;

                var parentSiteMapFileCollection = new StringCollection();
                if (_parentSiteMapFileCollection != null)
                {
                    foreach (string filename in _parentSiteMapFileCollection)
                    {
                        parentSiteMapFileCollection.Add(filename);
                    }
                }

                // Make sure the provider is initialized before adding to the collection.
                xmlProvider.BuildSiteMap();

                parentSiteMapFileCollection.Add(_normalizedVirtualPath);
                if (parentSiteMapFileCollection.Contains(xmlProvider._normalizedVirtualPath))
                {
                    throw new InvalidOperationException(SR.GetString(SR.XmlSiteMapProviderFileNameAlreadyInUse, xmlProvider._virtualPath));
                }

                xmlProvider._parentSiteMapFileCollection = parentSiteMapFileCollection;
            }

            SiteMapNode node = ((XmlSiteMapProvider)provider).GetRootNodeCore();
            if (node == null)
            {
                throw new InvalidOperationException(
                    SR.GetString(SR.XmlSiteMapProviderInvalidGetRootNodeCore, provider.Name));
            }

            ChildProviderTable.Add(provider, node);
            _childProviderList = null;

            provider.ParentProvider = this;

            return node;
        }

        private SiteMapNode GetNodeFromSiteMapFile(XmlNode xmlNode, String siteMapFile)
        {
            // For external sitemap files, its secuity setting is inherited from parent provider
            bool secuityTrimmingEnabled = SecurityTrimmingEnabled;
            SecUtility.GetAndRemoveBooleanAttribute(xmlNode, SecurityTrimmingEnabledAttrName, ref secuityTrimmingEnabled);

            // No other attributes or non-comment nodes are allowed on a siteMapFile node
            SecUtility.CheckForUnrecognizedAttributes(xmlNode);
            SecUtility.CheckForNonCommentChildNodes(xmlNode);

            var childProvider = new XmlSiteMapProvider();

            // siteMapFile was relative to the sitemap file where this xmlnode is defined, make it an application path.
            siteMapFile = VirtualPathUtility.Combine(VirtualPathUtility.GetDirectory(_normalizedVirtualPath), siteMapFile);

            childProvider.ParentProvider = this;
            childProvider.Initialize(siteMapFile, secuityTrimmingEnabled);
            childProvider.BuildSiteMap();

            SiteMapNode node = childProvider._siteMapNode;

            ChildProviderTable.Add(childProvider, node);
            _childProviderList = null;

            return node;
        }

        private static void HandleResourceAttribute(XmlNode xmlNode, ref NameValueCollection collection,
            string attrName, ref string text, bool allowImplicitResource)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }

            string resourceKey;
            var temp = text.TrimStart(new[] { ' ' });

            if (temp.Length > ResourcePrefixLength)
            {
                if (temp.ToLower(CultureInfo.InvariantCulture).StartsWith(ResourcePrefix, StringComparison.Ordinal))
                {
                    if (!allowImplicitResource)
                    {
                        throw new ConfigurationErrorsException(
                            SR.GetString(SR.XmlSiteMapProviderMultipleResourceDefinition, attrName), xmlNode);
                    }

                    resourceKey = temp.Substring(ResourcePrefixLength + 1);

                    if (resourceKey.Length == 0)
                    {
                        throw new ConfigurationErrorsException(
                            SR.GetString(SR.XmlSiteMapProviderResourceKeyCannotBeEmpty), xmlNode);
                    }

                    // Retrieve className from attribute
                    var index = resourceKey.IndexOf(ResourceKeySeparator);
                    if (index == -1)
                    {
                        throw new ConfigurationErrorsException(
                            SR.GetString(
                            SR.XmlSiteMapProviderInvalidResourceKey, resourceKey), xmlNode);
                    }

                    var className = resourceKey.Substring(0, index);
                    var key = resourceKey.Substring(index + 1);

                    // Retrieve resource key and default value from attribute
                    var defaultIndex = key.IndexOf(ResourceKeySeparator);
                    if (defaultIndex != -1)
                    {
                        text = key.Substring(defaultIndex + 1);
                        key = key.Substring(0, defaultIndex);
                    }
                    else
                    {
                        text = null;
                    }

                    if (collection == null)
                    {
                        collection = new NameValueCollection();
                    }

                    collection.Add(attrName, className.Trim());
                    collection.Add(attrName, key.Trim());
                }
            }
        }

        private SiteMapNode GetNodeFromXmlNode(XmlNode xmlNode, Queue queue)
        {
            // static nodes
            string title = null, url = null, description = null, roles = null, resourceKey = null;

            // Url attribute is NOT required for a xml node.
            SecUtility.GetAndRemoveStringAttribute(xmlNode, "url", ref url);
            SecUtility.GetAndRemoveStringAttribute(xmlNode, "title", ref title);
            SecUtility.GetAndRemoveStringAttribute(xmlNode, "description", ref description);
            SecUtility.GetAndRemoveStringAttribute(xmlNode, "roles", ref roles);
            SecUtility.GetAndRemoveStringAttribute(xmlNode, "resourceKey", ref resourceKey);

            // Do not add the resourceKey if the resource is not valid.
            if (!String.IsNullOrEmpty(resourceKey) &&
                !ValidateResource(ResourceKey, resourceKey + ".title"))
            {
                resourceKey = null;
            }

            SecUtility.CheckForbiddenAttribute(xmlNode, SecurityTrimmingEnabledAttrName);

            NameValueCollection resourceKeyCollection = null;
            bool allowImplicitResourceAttribute = String.IsNullOrEmpty(resourceKey);
            HandleResourceAttribute(xmlNode, ref resourceKeyCollection,
                "title", ref title, allowImplicitResourceAttribute);
            HandleResourceAttribute(xmlNode, ref resourceKeyCollection,
                "description", ref description, allowImplicitResourceAttribute);

            var roleList = new ArrayList();
            if (roles != null)
            {
                int foundIndex = roles.IndexOf('?');
                if (foundIndex != -1)
                {
                    throw new ConfigurationErrorsException(
                        SR.GetString(SR.AuthRuleNamesCantContainChar,
                            roles[foundIndex].ToString(CultureInfo.InvariantCulture)), xmlNode);
                }

                foreach (var role in roles.Split(Seperators))
                {
                    var trimmedRole = role.Trim();
                    if (trimmedRole.Length > 0)
                    {
                        roleList.Add(trimmedRole);
                    }
                }
            }
            roleList = ArrayList.ReadOnly(roleList);

            String key;

            // Make urls absolute.
            if (!String.IsNullOrEmpty(url))
            {
                // URL needs to be trimmed.
                url = url.Trim();

                if (!SecUtility.IsAbsolutePhysicalPath(url))
                {
                    if (SecUtility.IsRelativeUrl(url))
                    {
                        string virtualPath = url;

                        int qs = url.IndexOf('?');
                        if (qs != -1)
                        {
                            virtualPath = url.Substring(0, qs);
                        }

                        // Make sure the path is adjusted properly
                        virtualPath =
                            VirtualPathUtility.Combine(AppDomainAppVirtualPathWithTrailingSlash, virtualPath);

                        // Make it an absolute virtualPath
                        virtualPath = VirtualPathUtility.ToAbsolute(virtualPath);

                        if (qs != -1)
                        {
                            virtualPath += url.Substring(qs);
                        }

                        url = virtualPath;
                    }
                }

                // Reject any suspicious or mal-formed Urls.
                string decodedUrl = HttpUtility.UrlDecode(url);
                if (!String.Equals(url, decodedUrl, StringComparison.Ordinal))
                {
                    throw new ConfigurationErrorsException(
                        SR.GetString(SR.PropertyHadMalformedUrl, "url", url), xmlNode);
                }

                key = url.ToLowerInvariant();
            }
            else
            {
                key = Guid.NewGuid().ToString();
            }

            // attribute collection does not contain pre-defined properties like title, url, etc.
            var attributeCollection = new ReadOnlyNameValueCollection();
            attributeCollection.SetReadOnly(false);
            if (xmlNode.Attributes != null)
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    var value = attribute.Value;
                    HandleResourceAttribute(xmlNode, ref resourceKeyCollection, attribute.Name, ref value, allowImplicitResourceAttribute);
                    attributeCollection[attribute.Name] = value;
                }
            attributeCollection.SetReadOnly(true);

            var node = new SiteMapNode(this, key, url, title, description, roleList, attributeCollection, resourceKeyCollection, resourceKey) { ReadOnly = true };

            foreach (var subNode in
                xmlNode.ChildNodes.Cast<XmlNode>().Where(subNode => subNode.NodeType == XmlNodeType.Element))
            {
                queue.Enqueue(node);
                queue.Enqueue(subNode);
            }

            return node;
        }

        private static SiteMapProvider GetProviderFromName(string providerName)
        {
            Debug.Assert(providerName != null);

            SiteMapProvider provider = SiteMap.Providers[providerName];
            if (provider == null)
            {
                throw new ProviderException(SR.GetString(SR.ProviderNotFound, providerName));
            }

            return provider;
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            BuildSiteMap();
            return _siteMapNode;
        }


        public override void Initialize(string name, NameValueCollection attributes)
        {
            if (_initialized)
            {
                throw new InvalidOperationException(
                    SR.GetString(SR.XmlSiteMapProviderCannotBeInitedTwice));
            }

            if (attributes != null)
            {
                if (string.IsNullOrEmpty(attributes["description"]))
                {
                    attributes.Remove("description");
                    attributes.Add("description", SR.GetString(SR.XmlSiteMapProviderDescription));
                }

                string siteMapFile = null;
                SecUtility.GetAndRemoveStringAttribute(attributes, SiteMapFileAttribute, name, ref siteMapFile);
                _virtualPath = siteMapFile;
            }

            base.Initialize(name, attributes);

            if (attributes != null)
            {
                SecUtility.CheckUnrecognizedAttributes(attributes, name);
            }

            _initialized = true;
        }

        private void Initialize(string virtualPath, bool secuityTrimmingEnabled)
        {
            var coll = new NameValueCollection
                           {
                               {SiteMapFileAttribute, virtualPath},
                               {SecurityTrimmingEnabledAttrName, SecUtility.GetStringFromBool(secuityTrimmingEnabled)}
                           };

            // Use the siteMapFile virtual path as the provider name
            Initialize(virtualPath, coll);
        }

        //private void OnConfigFileChange(Object sender, FileChangeEvent e)
        //{
        //    // Notifiy the parent for the change.
        //    XmlSiteMapProvider parentProvider = ParentProvider as XmlSiteMapProvider;
        //    if (parentProvider != null)
        //    {
        //        parentProvider.OnConfigFileChange(sender, e);
        //    }
        //    Clear();
        //}

        protected override void RemoveNode(SiteMapNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            SiteMapProvider ownerProvider = node.Provider;

            if (ownerProvider != this)
            {

                // Only nodes defined in this provider tree can be removed.
                SiteMapProvider parentProvider = ownerProvider.ParentProvider;
                while (parentProvider != this)
                {
                    if (parentProvider == null)
                    {
                        // Cannot remove nodes defined in other providers
                        throw new InvalidOperationException(SR.GetString(
                            SR.XmlSiteMapProviderCannotRemoveNode, node.ToString(),
                            Name, ownerProvider.Name));
                    }

                    parentProvider = parentProvider.ParentProvider;
                }
            }

            if (node.Equals(((XmlSiteMapProvider)ownerProvider).GetRootNodeCore()))
            {
                throw new InvalidOperationException(SR.GetString(SR.SiteMapProviderCannotRemoveRootNode));
            }

            if (ownerProvider != this)
            {
                // Remove node from the owner provider.
                ((XmlSiteMapProvider)ownerProvider).RemoveNode(node);
            }

            base.RemoveNode(node);
        }

        protected virtual void RemoveProvider(string providerName)
        {
            if (providerName == null)
            {
                throw new ArgumentNullException("providerName");
            }

            lock (_lock)
            {
                var provider = GetProviderFromName(providerName);
                var rootNode = (SiteMapNode)ChildProviderTable[provider];

                if (rootNode == null)
                {
                    throw new InvalidOperationException(SR.GetString(SR.XmlSiteMapProviderCannotFindProvider, provider.Name, Name));
                }

                provider.ParentProvider = null;
                ChildProviderTable.Remove(provider);
                _childProviderList = null;

                base.RemoveNode(rootNode);
            }
        }

        // This only returns false if the classKey cannot be found, regardless of resourceKey.
        private static bool ValidateResource(string classKey, string resourceKey)
        {
            try
            {
                HttpContext.GetGlobalResourceObject(classKey, resourceKey);
            }
            catch (MissingManifestResourceException)
            {
                return false;
            }

            return true;
        }

        private class ReadOnlyNameValueCollection : NameValueCollection
        {

            public ReadOnlyNameValueCollection()
            {
                IsReadOnly = true;
            }

            internal void SetReadOnly(bool isReadonly)
            {
                IsReadOnly = isReadonly;
            }
        }

        public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        {
            if (!SecurityTrimmingEnabled)
                return true;

            var newNode = node.Clone(true);

            if (!string.IsNullOrEmpty(node["RouteName"]))
            {
                var r = (System.Web.Routing.Route)System.Web.Routing.RouteTable.Routes[node["routeName"]];

                if (r != null)
                {
                    string s = ((System.Web.Routing.PageRouteHandler)(r.RouteHandler)).VirtualPath;

                    newNode.Url = s;
                }
            }

            var isaccessible = base.IsAccessibleToUser(context, newNode);
            return isaccessible;
        }
    }
}
