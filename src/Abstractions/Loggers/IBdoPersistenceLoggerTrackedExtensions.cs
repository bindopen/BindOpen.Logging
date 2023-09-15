namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoPersistenceLoggerTrackedExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T WithLogger<T>(
            this T tracked,
            IBdoPersistenceLogger logger)
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