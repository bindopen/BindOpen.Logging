namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoPersistentLoggerTrackedExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T WithLogger<T>(
            this T tracked,
            IBdoPersistentLogger logger)
            where T : IBdoLoggerTracked
        {
            if (tracked != null)
            {
                tracked.Logger = logger;
            }

            return tracked;
        }
    }
}