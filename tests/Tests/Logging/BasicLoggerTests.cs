using BindOpen.Kernel.Logging.Tests;
using NUnit.Framework;

namespace BindOpen.Kernel.Logging.Loggers
{
    [TestFixture, Order(400)]
    public class BasicLoggerTests
    {
        private readonly string _filePath_serilog = GlobalVariables.WorkingFolder + "Debug.txt";

        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testData = new
            {
                itemNumber = 1000
            };
        }

        private void PopulateLog(IBdoDynamicLog log)
        {
            if (log != null)
            {
                for (int i = 0; i < _testData.itemNumber; i++)
                {
                    log.AddError("Error" + i);
                    log.AddException("Exception" + i);
                    log.AddMessage("Message" + i);
                    log.AddWarning("Warning" + i);
                    log.InsertChild(q => q.WithDisplayName("Child" + i))
                        .AddError("Error" + i + "-1");
                }
            }
        }

        [Test, Order(1)]
        public void DebugLoggerTest()
        {
            var logger = BdoLogging.NewLogger<BdoDebugLogger>();

            var log = logger.NewRootLog();
            PopulateLog(log);

            logger.Log(log);
        }

        [Test, Order(2)]
        public void ConsoleLoggerTest()
        {
            var logger = BdoLogging.NewLogger<BdoConsoleLogger>();

            var log = logger.NewRootLog();
            PopulateLog(log);

            logger.Log(log);
        }
    }
}
