using BindOpen.Framework.MetaData;
using NUnit.Framework;
using System.IO;

namespace BindOpen.Logging.Tests
{
    [TestFixture, Order(400)]
    public class BdoRuntimeLogTests
    {
        private readonly string _filePath_xml = GlobalVariables.WorkingFolder + "Log.xml";
        private readonly string _filePath_json = GlobalVariables.WorkingFolder + "Log.json";

        private IBdoRuntimeLog _log = null;

        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _testData = new
            {
                itemNumber = 1000
            };
        }

        private void Test(IBdoRuntimeLog log)
        {
            Assert.That(log.Errors.Count == _testData.itemNumber, "Bad insertion of errors ({0} expected; {1} found)", _testData.itemNumber, _log.Errors.Count);
            Assert.That(log.Exceptions.Count == _testData.itemNumber, "Bad insertion of exceptions ({0} expected; {1} found)", _testData.itemNumber, _log.Exceptions.Count);
            Assert.That(log.Messages.Count == _testData.itemNumber, "Bad insertion of messages ({0} expected; {1} found)", _testData.itemNumber, _log.Messages.Count);
            Assert.That(log.Warnings.Count == _testData.itemNumber, "Bad insertion of warnings ({0} expected; {1} found)", _testData.itemNumber, _log.Warnings.Count);
            Assert.That(log.SubLogs.Count == _testData.itemNumber, "Bad insertion of sub logs ({0} expected; {1} found)", _testData.itemNumber, _log.SubLogs.Count);
        }

        [Test, Order(1)]
        public void CreateEventsTest()
        {
            _log = BdoLogging.CreateLog();

            for (int i = 0; i < _testData.itemNumber; i++)
            {
                _log.AddError("Error" + i);
                _log.AddException("Exception" + i);
                _log.AddMessage("Message" + i);
                _log.AddWarning("Warning" + i);
                _log.AddSubLog(new BdoRuntimeLog());
            }

            Test(_log);
        }

        // Xml

        [Test, Order(2)]
        public void SaveXmlEventsTest()
        {
            if (_log == null)
            {
                CreateEventsTest();
            }

            var log = BdoLogging.CreateLog();
            _log.ToDto()?.SaveXml(_filePath_xml, log);

            string xml = string.Empty;
            if (log.HasErrorsOrExceptions())
            {
                xml = ". Result was '" + log.ToDto().ToXml() + "'";
            }
            Assert.That(!log.HasErrorsOrExceptions(), "Log saving failed" + xml);
        }

        [Test, Order(3)]
        public void LoadXmlEventsTest()
        {
            if (_log == null || !File.Exists(_filePath_xml))
            {
                SaveXmlEventsTest();
            }

            BdoRuntimeLog log = BdoLogging.CreateLog();
            _log = XmlHelper.LoadXml<BdoRuntimeLogDto>(_filePath_xml, log: log).ToPoco();

            string xml = string.Empty;
            if (log.HasErrorsOrExceptions())
            {
                xml = ". Result was '" + log.ToDto().ToXml() + "'";
            }
            Assert.That(_log.HasErrorsOrExceptions(), "Error while loading log" + xml);

            Test(_log);
        }

        // Json

        [Test, Order(2)]
        public void SaveJsonEventsTest()
        {
            if (_log == null)
            {
                CreateEventsTest();
            }

            var log = BdoLogging.CreateLog();
            _log.ToDto()?.SaveJson(_filePath_json, log);

            string xml = string.Empty;
            if (log.HasErrorsOrExceptions())
            {
                xml = ". Result was '" + log.ToDto().ToJson() + "'";
            }
            Assert.That(!log.HasErrorsOrExceptions(), "Log saving failed" + xml);
        }

        [Test, Order(3)]
        public void LoadJsonEventsTest()
        {
            if (_log == null || !File.Exists(_filePath_json))
            {
                SaveJsonEventsTest();
            }

            BdoRuntimeLog log = BdoLogging.CreateLog();
            _log = JsonHelper.LoadJson<BdoRuntimeLogDto>(_filePath_json, log: log).ToPoco();

            string xml = string.Empty;
            if (log.HasErrorsOrExceptions())
            {
                xml = ". Result was '" + log.ToDto().ToJson() + "'";
            }
            Assert.That(_log.HasErrorsOrExceptions(), "Error while loading log" + xml);

            Test(_log);
        }
    }
}
