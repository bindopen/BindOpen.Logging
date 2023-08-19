namespace BindOpen.System.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoTrackedExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T WithLogger<T>(
            this T tracked,
            IBdoLogger logger)
            where T : IBdoTracked
        {
            if (tracked != null)
            {
                tracked.Logger = logger;
            }

            return tracked;
        }
    }
}