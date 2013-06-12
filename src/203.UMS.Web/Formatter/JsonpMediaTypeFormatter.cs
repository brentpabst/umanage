using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace _203.UMS.Web.Formatter
{
    /// <summary>
    /// <see cref="MediaTypeFormatter"/> class to handle JSONP.
    /// </summary>
    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public string JsonpParameterName { get; set; }
        private string _jsonpCallbackFunction;

        public JsonpMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("text/json"));
            JsonpParameterName = "callback";
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            var formatter = new JsonpMediaTypeFormatter
                {
                    _jsonpCallbackFunction = GetJsonCallbackFunction(request)
                };

            formatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            if (HttpContext.Current.IsDebuggingEnabled)
            formatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            return formatter;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, System.Net.TransportContext transportContext)
        {
            if (string.IsNullOrWhiteSpace(_jsonpCallbackFunction))
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);

            StreamWriter writer = null;

            // Write pre-amble
            try
            {
                writer = new StreamWriter(writeStream);
                writer.Write(_jsonpCallbackFunction + "(");
                writer.Flush();
            }
            catch (Exception ex)
            {
                try
                {
                    if (writer != null) writer.Dispose();
                }
                catch
                { }
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }

            return base.WriteToStreamAsync(type, value, writeStream, content, transportContext)
                       .ContinueWith(innerTask =>
                           {
                               if (innerTask.Status != TaskStatus.RanToCompletion) return;
                               writer.Write(")");
                               writer.Flush();
                           }, TaskContinuationOptions.ExecuteSynchronously)
                       .ContinueWith(innerTask =>
                           {
                               writer.Dispose();
                               return innerTask;
                           }, TaskContinuationOptions.ExecuteSynchronously)
                       .Unwrap();
        }

        private string GetJsonCallbackFunction(HttpRequestMessage request)
        {
            if (request.Method != HttpMethod.Get) return null;

            var query = HttpUtility.ParseQueryString(request.RequestUri.Query);
            var queryVal = query[JsonpParameterName];

            return string.IsNullOrWhiteSpace(queryVal) ? null : queryVal;
        }
    }
}