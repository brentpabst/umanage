namespace THS.UMS.AO
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class EmailReplacements
    {
        /// <summary>
        /// Gets the replacement dictionary.
        /// </summary>
        /// <param name="e">The object to get a dictionary for.</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetReplacementDictionary(object e)
        {
            var r = new Dictionary<string, string>();

            var t = e.GetType();
            foreach (var p in t.GetProperties())
            {
                var v = t.InvokeMember(p.Name, BindingFlags.GetProperty, null, e, null);
                r.Add("$" + t.Name + "." + p.Name + "$", v != null ? v.ToString() : "");
            }

            return r;
        }

        /// <summary>
        /// Merges a dictionary with a new object.
        /// </summary>
        /// <param name="e">The new object to merge.</param>
        /// <param name="dic">The existing dictionary.</param>
        /// <returns></returns>
        public static Dictionary<string, string> MergeDictionaries(object e, Dictionary<string, string> dic)
        {
            foreach (var v in GetReplacementDictionary(e))
            {
                dic.Add(v.Key, v.Value);
            }
            return dic;
        }

        /// <summary>
        /// Merges two dictionary objects together
        /// </summary>
        /// <param name="dic1">Dictionary 1.</param>
        /// <param name="dic2">Dictionary 2.</param>
        /// <returns></returns>
        public static Dictionary<string, string> MergeDictionaries(Dictionary<string, string> dic1, Dictionary<string, string> dic2)
        {
            foreach (var v in dic2)
            {
                dic1.Add(v.Key, v.Value);
            }
            return dic1;
        }

        /// <summary>
        /// Replaces the template with dictionary values.
        /// </summary>
        /// <param name="text">The text to parse and replace.</param>
        /// <param name="dic">The dictionary to use and replace values.</param>
        /// <returns></returns>
        public static string ReplaceTemplateWithDictionary(string text, Dictionary<string, string> dic)
        {
            var re = new Regex(@"\$\w+(?:\.\w+)*\$", RegexOptions.Compiled);
            return re.Replace(text, match => dic[match.Groups[0].Value]);
        }
    }
}
