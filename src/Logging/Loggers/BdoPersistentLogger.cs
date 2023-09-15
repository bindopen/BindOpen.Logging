using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;
using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public abstract partial class BdoPersistentLogger : BdoObject, IBdoLogger
    {
        public IBdoConnector Connector { get; set; }

        protected BdoPersistentLogger() : base()
        {
        }

        protected BdoPersistentLogger(IBdoConnector connector) : base()
        {
            Connector = connector;
        }


        protected string _rootLogId;

        public string RootLogId { get => _rootLogId; protected set => _rootLogId = value; }

        public IBdoCompleteLog NewRootLog(string id = null)
        {
            id ??= _rootLogId;

            var log = GetLog(id).Result;
            if (log != null)
            {
                log = BdoData.New<BdoPersistentLog>().WithId(id).WithLogger(this);
                CreateLog(log);
            }
            _rootLogId = log?.Id;

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public void Log(IBdoLog item, IBdoLog log = null)
        {
            if (item is IBdoCompleteLog dynamicLog)
            {
                CreateLog(dynamicLog, null, log);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public void Log(IBdoLogEvent item, IBdoLog log = null)
        {
            CreateEvent(item, null, log);
        }
    }
}
