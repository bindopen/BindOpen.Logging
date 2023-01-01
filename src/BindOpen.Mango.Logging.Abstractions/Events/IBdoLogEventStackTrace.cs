namespace BindOpen.Mango.Logging
{
    /// <summary>
    /// This interface defines a log event stack trace.
    /// </summary>
    public interface IBdoLogEventStackTrace
    {
        /// <summary>
        /// The name of the full class.
        /// </summary>
        string FullClassName { get; set; }

        /// <summary>
        /// The name of the called method.
        /// </summary>
        string MethodName { get; set; }

        /// <summary>
        /// Parameters of the called method.
        /// </summary>
        string MethodParams { get; set; }

        /// <summary>
        /// Path of the called file.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Called line number.
        /// </summary>
        string LineNumber { get; set; }
    }
}
