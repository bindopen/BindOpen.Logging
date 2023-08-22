using BindOpen.System.Data;

namespace BindOpen.System.Logging
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