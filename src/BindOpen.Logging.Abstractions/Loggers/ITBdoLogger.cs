namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITBdoLogger<T> : IBdoLogger
        where T : IBdoLoggerFormat, new()
    {
        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public T Formater { get; }
    }
}