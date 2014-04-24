using System;
using System.IO;

namespace Logger.net
{
    public class Logger
    {
        private StreamWriter streamWriter;
        private const string FileName = "dbDeployLogger.txt";
        private readonly string path;

        public Logger()
        {
            path = Path.GetTempPath();
            CreateLogFile();
        }

        private StreamWriter CreateStream()
        {
            return new StreamWriter(Path.Combine(path, FileName), true);
        }

        private void CreateLogFile()
        {
            if (File.Exists(Path.Combine(path, FileName)))
                return;

            streamWriter = File.CreateText(Path.Combine(path, FileName));
            streamWriter.Close();
        }

        public void Add(string comment, object value)
        {
            if (value == null)
            {
                throw new Exception("@Argument value cannot be null");
            }

            using (streamWriter = CreateStream())
            {
                streamWriter.WriteLine("Time and date: " + DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss"));
                streamWriter.WriteLine(comment + ":");
                streamWriter.WriteLine(value.ToString());
                streamWriter.WriteLine();
            }
        }
    }
}