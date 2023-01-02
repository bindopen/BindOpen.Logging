namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoLoggerFormat
    {
        /// <summary>
        /// Converts the log to the string.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <returns>Returns the string that converts the specified log.</returns>
        string ToString(IBdoRuntimeLog log);

        /// <summary>
        /// Converts the log event to the string.
        /// </summary>
        /// <param name="ev">The event to consider.</param>
        /// <returns>Returns the string that converts the specified log event.</returns>
        string ToString(IBdoLogEvent ev);
    }
}