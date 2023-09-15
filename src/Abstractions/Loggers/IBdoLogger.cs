using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoLogger : IBdoObject
    {
        string RootLogId { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        void Log(IBdoLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        void Log(IBdoLogEvent item, IBdoLog log = null);
    }
}