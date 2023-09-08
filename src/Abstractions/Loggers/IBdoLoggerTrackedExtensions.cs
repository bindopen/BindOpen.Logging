namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoLoggerTrackedExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T WithLogger<T>(
            this T tracked,
            IBdoLogger logger)
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