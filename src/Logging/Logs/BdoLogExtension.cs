namespace BindOpen.System.Logging
{
    /// <summary>
    /// This class represents a log extension.
    /// </summary>
    public static class BdoLogExtension
    {
        /// <summary>
        /// Converts the specified log to string.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <returns>The string corresponding to the specified log using the specified formater.</returns>
        public static string ToString<T>(this IBdoDynamicLog log)
            where T : IBdoLoggerFormat, new()
        {
            var formater = new T();
            return formater.ToString(log);
        }
    }
}
