using System.IO;
using System.Web;

namespace UMS.Core.Logic.Config
{
    public class System
    {
        public void TakeOffline(string message)
        {
            try
            {
                var file = HttpContext.Current.Server.MapPath("~/App_Data/Templates/Offline.htm");
                var objReader = File.OpenText(file);
                var objWriter = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Offline.htm"), true);
                objWriter.Write(objReader.ReadToEnd().Replace("$Message$", message));
                objReader.Close();
                objWriter.Close();
            }
            catch
            {
                throw new IOException("Failed to read template file or create new file");
            }
        }
    }
}
