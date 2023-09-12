using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;

namespace BindOpen.Kernel.Logging.Loggers
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

        public IBdoDynamicLog NewLog() => BdoData.New<BdoLog>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void Log(IBdoDynamicLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void Log(IBdoLogEvent item, IBdoLog log = null);
    }
}
