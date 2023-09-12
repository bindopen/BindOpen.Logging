using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;
using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public abstract partial class BdoPersistenceLogger : BdoObject, IBdoLogger
    {
        public IBdoConnector Connector { get; set; }

        public IBdoDynamicLog NewLog() => BdoData.New<BdoLog>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public void Log(IBdoDynamicLog item, IBdoLog log = null)
        {
            CreateLog(item, null, log);
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
