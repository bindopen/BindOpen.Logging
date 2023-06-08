using BindOpen.Scoping.Scopes;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Serilog;
using System.Linq;

namespace BindOpen.Logging.Tests
{
    [TestFixture, Order(400)]
    public class BdoLoggerTests
    {
        private readonly string _filePath_serilog = GlobalVariables.WorkingFolder + "Serilog.txt";

        private IBdoDynamicLog _log = null;

        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testData = new
            {
                itemNumber = 1000
            };
        }

        private void Test(IBdoDynamicLog log)
        {
            Assert.That(log.Errors().Count() == _testData.itemNumber, "Bad insertion of errors ({0} expected; {1} found)", _testData.itemNumber, _log.Errors().Count());
            Assert.That(log.Exceptions().Count() == _testData.itemNumber, "Bad insertion of exceptions ({0} expected; {1} found)", _testData.itemNumber, _log.Exceptions().Count());
            Assert.That(log.Messages().Count() == _testData.itemNumber, "Bad insertion of messages ({0} expected; {1} found)", _testData.itemNumber, _log.Messages().Count());
            Assert.That(log.Warnings().Count() == _testData.itemNumber, "Bad insertion of warnings ({0} expected; {1} found)", _testData.itemNumber, _log.Warnings().Count());
            Assert.That(log.Children().Count() == _testData.itemNumber, "Bad insertion of sub logs ({0} expected; {1} found)", _testData.itemNumber, _log.Children().Count());
        }

        [Test, Order(1)]
        public void CreateEventsTest()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(_filePath_serilog, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog(Log.Logger);
            var logger = loggerFactory.CreateLogger<IBdoScope>();

            _log = BdoLogging.NewLog(logger);

            for (int i = 0; i < _testData.itemNumber; i++)
            {
                _log.AddError("Error" + i);
                _log.AddException("Exception" + i);
                _log.AddMessage("Message" + i);
                _log.AddWarning("Warning" + i);
                _log.AddChild(BdoLogging.NewLog());
            }

            Test(_log);
        }
    }
}
