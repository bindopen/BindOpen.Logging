using BindOpen.Kernel.Logging.Events;
using System.Diagnostics;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public class TBdoDebugLogger<T> : TBdoLogger<T>
        where T : IBdoLoggerFormat, new()
    {
        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public TBdoDebugLogger() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.ToString(item);
            Debug.WriteLine(st);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLogEvent item, IBdoLog log = null)
        {
            var st = _formater?.ToString(item);
            Debug.WriteLine(st);
        }
    }
}
