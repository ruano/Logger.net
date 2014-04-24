using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace Logger.net.test
{
    class LoggerTest
    {
        private Logger log;

        [SetUp]
        public void SetUp()
        {
            log = new Logger();
        }

        [Test]
        public void create_log_file_once()
        {
            log.Add("Pass for here", "test");
            var path = new FileInfo((Path.Combine(Path.GetTempPath(), "dbDeployLogger.txt")));
            var file = File.ReadAllText(path.FullName);
            Assert.IsTrue(file.Contains("Pass for here"));
        }

        [Test]
        public void create_log_file_more()
        {
            for (int i = 0; i < 5; i++)
                log.Add("Pass for here index: " + i, i);

            var path = new FileInfo((Path.Combine(Path.GetTempPath(), "dbDeployLogger.txt")));
            var file = File.ReadAllText(path.FullName);
            Assert.IsTrue(file.Contains("Pass for here"));
        }
    }
}