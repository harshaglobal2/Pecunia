using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capgemini.Inventory.Exceptions
{
    /// <summary>
    /// Logs exception details in CSV format
    /// </summary>
    public static class ExceptionLogger
    {
        public static void LogException(Exception ex)
        {
            //before your loop
            StringBuilder stringBuilder = new StringBuilder();

            string logLine = $"\"{DateTime.Now}\",\"{ex.GetType()}\",\"{ex.Message}\",\"{ex.StackTrace}\",\"{ex.InnerException?.GetType()}\",\"{ex.InnerException?.Message}\"";
            stringBuilder.AppendLine(logLine);

            //after your loop
            File.AppendAllText("ErrorLog.csv", stringBuilder.ToString());
        }
    }
}



