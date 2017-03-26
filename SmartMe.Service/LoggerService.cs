using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartMe.Service
{
    public class LoggerService
    {
        private static LoggerService instance = null;
        private static string Source = "SmartMe";

        private LoggerService()
        {
        }

        public static LoggerService GetInstance()
        {
            if(instance == null)
            {
                instance = new LoggerService();
            }
            return instance;
        }

        public void Error(Exception exception)
        {
            try
            {
                EventLog.WriteEntry(Source, BuildErrorMessage(exception), EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                // Nothing can be done here
            }
        }

        public void Error(string message, Exception exception)
        {
            try
            {
                EventLog.WriteEntry(Source, message + "\n" + BuildErrorMessage(exception), EventLogEntryType.Error);
            }
            catch(Exception ex)
            {
                // Nothing can be done here
            }
        }

        public void Warning(string message, Exception ex)
        {

        }

        public void Info(string message)
        {

        }

        public void Debug(string message)
        {

        }

        public string BuildErrorMessage(Exception exception)
        {
            StringBuilder errorMessage = new StringBuilder();
            errorMessage.AppendLine(Environment.MachineName);
            errorMessage.AppendLine(exception.Message);
            errorMessage.AppendLine(exception.StackTrace);
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                errorMessage.AppendLine(exception.Message);
                errorMessage.AppendLine(exception.StackTrace);
            }
            return Sanitize(errorMessage.ToString());
        }

        private string Sanitize(string input)
        {
            if (input == null)
            {
                return input;
            }

            string output = input;

            string pattern = @"password=[^ ]*";
            string replacement = "PASSWORD=*";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            output = rgx.Replace(output, replacement);

            return output;

        }

    }
}
