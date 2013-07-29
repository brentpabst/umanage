//------------------------------------------------------------------------------
// <copyright file="SR.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace THS.UMS.AO.Providers
{
    internal static class SR
    {
        internal const string AuthRuleNamesCantContainChar =
            "Authorization rule names cannot contain the '{0}' character.";

        internal const string ConnectionNameNotSpecified = "The attribute 'connectionStringName' is missing or empty.";

        internal const string ConnectionStringNotFound =
            "The connection name '{0}' was not found in the applications configuration or the connection string is empty.";

        internal const string MembershipAccountLockOut = "The user account has been locked out.";
        internal const string MembershipCustomPasswordValidationFailure = "The custom password validation failed.";
        internal const string MembershipInvalidAnswer = "The password-answer supplied is invalid.";
        internal const string MembershipInvalidEmail = "The E-mail supplied is invalid.";

        internal const string MembershipInvalidPassword =
            "The password supplied is invalid.  Passwords must conform to the password strength requirements configured for the default provider.";

        internal const string MembershipInvalidProviderUserKey =
            "The provider user key supplied is invalid.  It must be of type System.Guid.";

        internal const string MembershipInvalidQuestion =
            "The password-question supplied is invalid.  Note that the current provider configuration requires a valid password question and answer.  As a result, a CreateUser overload that accepts question and answer parameters must also be used.";

        internal const string MembershipMoreThanOneUserWithEmail =
            "More than one user has the specified e-mail address.";

        internal const string MembershipPasswordTooLong =
            "The password is too long: it must not exceed 128 chars after encrypting.";

        internal const string MembershipPasswordRetrievalNotSupported =
            "This Membership Provider has not been configured to support password retrieval.";

        internal const string MembershipUserNotFound = "The user was not found.";
        internal const string MembershipWrongAnswer = "The password-answer supplied is wrong.";
        internal const string MembershipWrongPassword = "The password supplied is wrong.";
        internal const string PageIndexBad = "The pageIndex must be greater than or equal to zero.";

        internal const string PageIndexPageSizeBad =
            "The combination of pageIndex and pageSize cannot exceed the maximum value of System.Int32.";

        internal const string PageSizeBad = "The pageSize must be greater than zero.";
        internal const string ParameterArrayEmpty = "The array parameter '{0}' should not be empty.";
        internal const string ParameterCanNotBeEmpty = "The parameter '{0}' must not be empty.";
        internal const string ParameterCanNotContainComma = "The parameter '{0}' must not contain commas.";
        internal const string ParameterDuplicateArrayElement = "The array '{0}' should not contain duplicate values.";

        internal const string ParameterTooLong =
            "The parameter '{0}' is too long: it must not exceed {1} chars in length.";

        internal const string PasswordDoesNotMatchRegularExpression =
            "The parameter '{0}' does not match the regular expression specified in config file.";

        internal const string PasswordNeedMoreNonAlphaNumericChars =
            "Non alpha numeric characters in '{0}' needs to be greater than or equal to '{1}'.";

        internal const string PasswordTooShort =
            "The length of parameter '{0}' needs to be greater or equal to '{1}'.";

        internal const string PersonalizationProviderApplicationNameExceedMaxLength =
            "The ApplicationName cannot exceed character length {0}.";

        internal const string PersonalizationProviderBadConnection =
            "The specified connectionStringName, '{0}', was not registered.";

        internal const string PersonalizationProviderCantAccess =
            "A connection could not be made by the {0} personalization provider using the specified registration.";

        internal const string PersonalizationProviderNoConnection =
            "The connectionStringName attribute must be specified when registering a personalization provider.";

        internal const string PersonalizationProviderUnknownProp =
            "Invalid attribute '{0}', specified in the '{1}' personalization provider registration.";

        internal const string ProfileSqlProviderDescription = "SQL profile provider.";
        internal const string PropertyHadMalformedUrl = "The '{0}' property had a malformed URL: {1}.";
        internal const string ProviderApplicationNameTooLong = "The application name is too long.";
        internal const string ProviderBadPasswordFormat = "Password format specified is invalid.";

        internal const string ProviderCanNotRetrieveHashedPassword =
            "Configured settings are invalid: Hashed passwords cannot be retrieved. Either set the password format to different type, or set supportsPasswordRetrieval to false.";

        internal const string ProviderError = "The Provider encountered an unknown error.";
        internal const string ProviderNotFound = "Provider '{0}' was not found.";
        internal const string ProviderRoleAlreadyExists = "The role '{0}' already exists.";
        internal const string ProviderRoleNotFound = "The role '{0}' was not found.";

        internal const string ProviderSchemaVersionNotMatch =
            "The '{0}' requires a database schema compatible with schema version '{1}'.  However, the current database schema is not compatible with this version.  You may need to either install a compatible schema with aspnet_regsql.exe (available in the framework installation directory), or upgrade the provider to a newer version.";

        internal const string ProviderThisUserAlreadyInRole = "The user '{0}' is already in role '{1}'.";
        internal const string ProviderThisUserNotFound = "The user '{0}' was not found.";
        internal const string ProviderUnknownFailure = "Stored procedure call failed.";
        internal const string ProviderUnrecognizedAttribute = "Attribute not recognized '{0}'";
        internal const string ProviderUserNotFound = "The user was not found in the database.";
        internal const string RoleIsNotEmpty = "This role cannot be deleted because there are users present in it.";
        internal const string RoleSqlProviderDescription = "SQL role provider.";

        internal const string SiteMapProviderCannotRemoveRootNode =
            "Root node cannot be removed from the providers, use RemoveProvider(string providerName) instead.";

        internal const string SqlErrorConnectionString =
            "An error occurred while attempting to initialize a System.Data.SqlClient.SqlConnection object. The value that was provided for the connection string may be wrong, or it may contain an invalid syntax.";

        internal const string SqlExpressFileNotFoundInConnectionString =
            "SQL Express filename was not found in the connection string.";

        internal const string SqlPersonalizationProviderDescription =
            "Personalization provider that stores data in a SQL Server database.";

        internal const string ValueMustBeBoolean = "The value must be boolean (true or false) for property '{0}'.";

        internal const string ValueMustBeNonNegativeInteger =
            "The value must be a non-negative 32-bit integer for property '{0}'.";

        internal const string ValueMustBePositiveInteger =
            "The value must be a positive 32-bit integer for property '{0}'.";

        internal const string ValueTooBig = "The value '{0}' can not be greater than '{1}'.";

        internal const string XmlSiteMapProviderCannotAddNode =
            "SiteMapNode {0} cannot be found in current provider, only nodes in the same provider can be added.";

        internal const string XmlSiteMapProviderCannotBeInitedTwice =
            "XmlSiteMapProvider cannot be initialized twice.";

        internal const string XmlSiteMapProviderCannotFindProvider =
            "Provider {0} cannot be found inside XmlSiteMapProvider {1}.";

        internal const string XmlSiteMapProviderCannotRemoveNode =
            "SiteMapNode {0} does not exist in provider {1}, it must be removed from provider {2}.";

        internal const string XmlSiteMapProviderDescription = "SiteMap provider which reads in .sitemap XML files.";

        internal const string XmlSiteMapProviderErrorLoadingConfigFile =
            "The XML sitemap config file {0} could not be loaded.  {1}";

        internal const string XmlSiteMapProviderFileNameAlreadyInUse =
            "The sitemap config file {0} is already used by other nodes or providers.";

        internal const string XmlSiteMapProviderFileNameDoesNotExist =
            "The file {0} required by XmlSiteMapProvider does not exist.";

        internal const string XmlSiteMapProviderInvalidExtension =
            "The file {0} has an invalid extension, only .sitemap files are allowed in XmlSiteMapProvider.";

        internal const string XmlSiteMapProviderInvalidGetRootNodeCore =
            "GetRootNode is returning null from Provider {0}, this method must return a non-empty sitemap node.";

        internal const string XmlSiteMapProviderInvalidResourceKey =
            "Resource key {0} is not valid, it must contain a valid class name and key pair. For example, $resources:'className','key'";

        internal const string XmlSiteMapProviderInvalidSitemapnodeReturned =
            "Provider {0} must return a valid sitemap node.";

        internal const string XmlSiteMapProviderMissingSiteMapFile =
            "The {0} attribute must be specified on the XmlSiteMapProvider.";

        internal const string XmlSiteMapProviderMultipleNodesWithIdenticalKey =
            "Multiple nodes with the same key '{0}' were found. XmlSiteMapProvider requires that sitemap nodes have unique keys.";

        internal const string XmlSiteMapProviderMultipleNodesWithIdenticalUrl =
            "Multiple nodes with the same URL '{0}' were found. XmlSiteMapProvider requires that sitemap nodes have unique URLs.";

        internal const string XmlSiteMapProviderMultipleResourceDefinition =
            "Cannot have more than one resource binding on attribute '{0}'. Ensure that this attribute is not bound through an implicit expression, for example, {0}=\"$resources:key\".";

        internal const string XmlSiteMapProviderNotInitialized =
            "XmlSiteMapProvider is not initialized. Call Initialize() method first.";

        internal const string XmlSiteMapProviderOnlyOneSiteMapNodeRequiredAtTop =
            "Exactly one <siteMapNode> element is required directly inside the <siteMap> element.";

        internal const string XmlSiteMapProviderOnlySiteMapNodeAllowed =
            "Only <siteMapNode> elements are allowed at this location.";

        internal const string XmlSiteMapProviderResourceKeyCannotBeEmpty = "Resource key cannot be empty.";
        internal const string XmlSiteMapProviderTopElementMustBeSiteMap = "Top element must be siteMap.";

        internal const string PersonalizationProviderHelperTrimmedEmptyString =
            "Input parameter '{0}' cannot be an empty string.";

        internal const string StringUtilTrimmedStringExceedMaximumLength =
            "Trimmed string value '{0}' of input parameter '{1}' cannot exceed character length {2}.";

        internal const string MembershipSqlProviderDescription = "SQL membership provider.";

        internal const string MinRequiredNonalphanumericCharactersCanNotBeMoreThanMinRequiredPasswordLength =
            "The minRequiredNonalphanumericCharacters can not be greater than minRequiredPasswordLength.";

        internal const string PersonalizationProviderHelperEmptyCollection =
            "Input parameter '{0}' cannot be an empty collection.";

        internal const string PersonalizationProviderHelperNullOrEmptyStringEntries =
            "Input parameter '{0}' cannot contain null or empty string entries.";

        internal const string PersonalizationProviderHelperCannotHaveCommaInString =
            "Input parameter '{0}' cannot have comma in string value '{1}'.";

        internal const string PersonalizationProviderHelperTrimmedEntryValueExceedMaximumLength =
            "Trimmed entry value '{0}' of input parameter '{1}' cannot exceed character length {2}.";

        internal const string PersonalizationProviderHelperMoreThanOnePath =
            "Input parameter '{0}' cannot contain more than one entry when '{1}' contains some entries.";

        internal const string PersonalizationProviderHelperNegativeInteger = "The input parameter cannot be negative.";

        internal const string PersonalizationAdminUnexpectedPersonalizationProviderReturnValue =
            "The negative value '{0}' is returned when calling provider's '{1}' method.  The method should return non-negative integer.";

        internal const string PersonalizationProviderHelperNullEntries =
            "Input parameter '{0}' cannot contain null entries.";

        internal const string PersonalizationProviderHelperInvalidLessThanParameter =
            "Input parameter '{0}' must be greater than or equal to {1}.";

        internal const string PersonalizationProviderHelperNoUsernamesSetInSharedScope =
            "Input parameter '{0}' cannot be provided when '{1}' is set to '{2}'.";

        internal const string ProviderThisUserAlreadyNotInRole = "The user '{0}' is already not in role '{1}'.";

        internal const string NotConfiguredToSupportPasswordResets =
            "This provider is not configured to allow password resets. To enable password reset, set enablePasswordReset to \"true\" in the configuration file.";

        internal const string ParameterCollectionEmpty = "The collection parameter '{0}' should not be empty.";
        internal const string ProviderCanNotDecodeHashedPassword = "Hashed passwords cannot be decoded.";

        internal const string DbFileNameCanNotContainInvalidChars =
            "The database filename can not contain the following 3 characters: [ (open square brace), ] (close square brace) and ' (single quote)";

        internal const string SqlServicesErrorDeletingSessionJob =
            "The attempt to remove the Session State expired sessions job from msdb did not succeed.  This can occur either because the job no longer exists, or because the job was originally created with a different user account than the account that is currently performing the uninstall.  You will need to manually delete the Session State expired sessions job if it still exists.";

        internal const string SqlServicesErrorExecutingCommand =
            "An error occurred during the execution of the SQL file '{0}'. The SQL error number is {1} and the SqlException message is: {2}";

        internal const string SqlServicesInvalidFeature = "An invalid feature is requested.";

        internal const string SqlServicesDatabaseEmptyOrSpaceOnlyArg =
            "The database name cannot be empty or contain only white space characters.";

        internal const string SqlServicesDatabaseContainsInvalidChars =
            "The custom database name cannot contain the following three characters: single quotation mark ('), left bracket ([) or right bracket (]).";

        internal const string SqlServicesErrorCantUninstallNonexistingDatabase =
            "Cannot uninstall the specified feature(s) because the SQL database '{0}' does not exist.";

        internal const string SqlServicesErrorCantUninstallNonemptyTable =
            "Cannot uninstall the specified feature(s) because the SQL table '{0}' in the database '{1}' is not empty. You must first remove all rows from the table.";

        internal const string SqlServicesErrorMissingCustomDatabase =
            "The database name cannot be null or empty if the session state type is SessionStateType.Custom.";

        internal const string SqlServicesErrorCantUseCustomDatabase =
            "You cannot specify the database name because it is allowed only if the session state type is SessionStateType.Custom.";

        internal const string SqlServicesCantConnectSqlDatabase = "Unable to connect to SQL Server database.";

        internal const string ErrorParsingSqlPartitionResolverString =
            "Error parsing the SQL connection string returned by an instance of the IPartitionResolver type '{0}': {1}";

        internal const string ErrorParsingSessionSqlConnectionString =
            "Error parsing <sessionState> sqlConnectionString attribute: {0}";

        internal const string NoDatabaseAllowedInSqlConnectionString =
            "The sqlConnectionString attribute or the connection string it refers to cannot contain the connection options 'Database', 'Initial Catalog' or 'AttachDbFileName'. In order to allow this, allowCustomSqlDatabase attribute must be set to true and the application needs to be granted unrestricted SqlClientPermission. Please check with your administrator if the application does not have this permission.";

        internal const string NoDatabaseAllowedInSqlPartitionResolverString =
            "The SQL connection string (server='{1}', database='{2}') returned by an instance of the IPartitionResolver type '{0}' cannot contain the connection options 'Database', 'Initial Catalog' or 'AttachDbFileName'. In order to allow this, allowCustomSqlDatabase attribute must be set to true and the application needs to be granted unrestricted SqlClientPermission. Please check with your administrator if the application does not have this permission.";

        internal const string CantConnectSqlSessionDatabase = "Unable to connect to SQL Server session database.";

        internal const string CantConnectSqlSessionDatabasePartitionResolver =
            "Unable to connect to SQL Server session database. The connection string (server='{1}', database='{2}') was returned by an instance of the IPartitionResolver type '{0}'.";

        internal const string LoginFailedSqlSessionDatabase =
            "Failed to login to session state SQL server for user '{0}'.";

        internal const string NeedV2SqlServer =
            "Unable to use SQL Server because ASP.NET version 2.0 Session State is not installed on the SQL server. Please install ASP.NET Session State SQL Server version 2.0 or above.";

        internal const string NeedV2SqlServerPartitionResolver =
            "Unable to use SQL Server because ASP.NET version 2.0 Session State is not installed on the SQL server. Please install ASP.NET Session State SQL Server version 2.0 or above. The connection string (server='{1}', database='{2}') was returned by an instance of the IPartitionResolver type '{0}'.";

        internal const string InvalidSessionState = "The session state information is invalid and might be corrupted.";

        internal const string MissingRequiredAttribute = "The '{0}' attribute must be specified on the '{1}' tag.";
        internal const string InvalidBooleanAttribute = "The '{0}' attribute must be set to 'true' or 'false'.";
        internal const string EmptyAttribute = "The '{0}' attribute cannot be an empty string.";

        internal const string ConfigBaseUnrecognizedAttribute =
            "Unrecognized attribute '{0}'. Note that attribute names are case-sensitive.";

        internal const string ConfigBaseNoChildNodes = "Child nodes are not allowed.";

        internal const string UnexpectedProviderAttribute =
            "The attribute '{0}' is unexpected in the configuration of the '{1}' provider.";

        internal const string OnlyOneConnectionStringAllowed =
            "SqlWebEventProvider: Specify either a connectionString or connectionStringName, not both.";

        internal const string CannotUseIntegratedSecurity =
            "SqlWebEventProvider: connectionString can only contain connection strings that use Sql Server authentication.  Trusted Connection security is not supported.";

        internal const string MustSpecifyConnectionStringOrName =
            "SqlWebEventProvider: Either a connectionString or connectionStringName must be specified.";

        internal const string InvalidMaxEventDetailsLength =
            "The value '{1}' specified for the maxEventDetailsLength attribute of the '{0}' provider is invalid. It should be between 0 and 1073741823.";

        internal const string SqlWebeventProviderEventsDropped =
            "{0} events were discarded since last notification was made at {1} because the event buffer capacity was exceeded.";

        internal const string InvalidProviderPositiveAttributes =
            "The attribute '{0}' is invalid in the configuration of the '{1}' provider. The attribute must be set to a non-negative integer.";

        internal static string GetString(string strString)
        {
            return strString;
        }

        internal static string GetString(string strString, string param1)
        {
            return string.Format(strString, param1);
        }

        internal static string GetString(string strString, string param1, string param2)
        {
            return string.Format(strString, param1, param2);
        }

        internal static string GetString(string strString, string param1, string param2, string param3)
        {
            return string.Format(strString, param1, param2, param3);
        }
    }
}