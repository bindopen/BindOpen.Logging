using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoLogger : IBdoObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        void Log(IBdoLogEvent ev);
    }
}