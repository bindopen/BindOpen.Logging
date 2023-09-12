using BindOpen.Kernel.Logging.Events;
using System;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public class TBdoConsoleLogger<T> : TBdoLogger<T>
        where T : IBdoLoggerFormat, new()
    {
        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public TBdoConsoleLogger() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.ToString(item);
            Console.WriteLine(st);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLogEvent item, IBdoLog log = null)
        {
            var st = _formater?.ToString(item);
            Console.WriteLine(st);
        }
    }
}
