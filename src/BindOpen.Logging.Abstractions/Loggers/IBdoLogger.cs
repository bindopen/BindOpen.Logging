using BindOpen.Data.Items;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoLogger : IBdoItem
    {
        ///// <summary>
        ///// Sets the native logger.
        ///// </summary>
        ///// <param name="nativeLogger">The native logger to consider.</param>
        ///// <returns>True if this instance has the specified events. False otherwise.</returns>
        //IBdoLogger SetNative(ILogger nativeLogger);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        void Log(IBdoLogEvent ev);
    }
}