using BindOpen.Kernel.Logging.Events;
using System.Diagnostics;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public class TBdoTraceLogger<T> : TBdoLogger<T>
        where T : IBdoLoggerFormater, new()
    {
        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public TBdoTraceLogger() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.Format(item);
            Trace.Write(st);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void LogExecution(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.FormatExecution(item);
            Trace.Write(st);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void LogDetail(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.FormatDetail(item);
            Trace.Write(st);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLogEvent item, IBdoLog log = null)
        {
            var st = _formater?.Format(item);
            Trace.Write(st);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void LogDetail(IBdoLogEvent item, IBdoLog log = null)
        {
            var st = _formater?.FormatDetail(item);
            Trace.Write(st);
        }
    }
}
