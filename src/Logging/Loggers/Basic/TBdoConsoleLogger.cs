using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;
using System;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public class TBdoConsoleLogger<T> : TBdoLogger<T>
        where T : IBdoLoggerFormater, new()
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
        public override IResultItem Log(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.Format(item);
            Console.Write(st);
            return BdoData.NewResultItem(ResourceStatus.Created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem LogExecution(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.FormatExecution(item);
            Console.Write(st);
            return BdoData.NewResultItem(ResourceStatus.Created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem LogDetail(IBdoLog item, IBdoLog log = null)
        {
            var st = _formater?.FormatDetail(item);
            Console.Write(st);
            return BdoData.NewResultItem(ResourceStatus.Created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem Log(IBdoLogEvent item, IBdoLog log = null)
        {
            var st = _formater?.Format(item);
            Console.Write(st);
            return BdoData.NewResultItem(ResourceStatus.Created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem LogDetail(IBdoLogEvent item, IBdoLog log = null)
        {
            var st = _formater?.FormatDetail(item);
            Console.Write(st);
            return BdoData.NewResultItem(ResourceStatus.Created);
        }
    }
}
