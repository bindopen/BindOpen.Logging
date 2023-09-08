using BindOpen.Kernel.Data;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public abstract class TBdoLogger<T> : BdoObject, ITBdoLogger<T>
        where T : IBdoLoggerFormat, new()
    {
        protected T _formater;

        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public T Formater => _formater;

        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public TBdoLogger()
        {
            _formater = new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void Log(IBdoLogEvent ev);
    }
}
