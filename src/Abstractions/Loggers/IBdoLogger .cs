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

        IBdoDynamicLog NewRootLog(string id = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        void Log(IBdoDynamicLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        void Log(IBdoLogEvent item, IBdoLog log = null);
    }
}