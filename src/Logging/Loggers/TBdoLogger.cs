using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public abstract class TBdoLogger<T> : BdoObject, ITBdoLogger<T>
        where T : IBdoLoggerFormater, new()
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

        public string _rootLogId;

        public string RootLogId { get => _rootLogId; protected set => _rootLogId = value; }

        public IBdoCompleteLog NewRootLog(string id = null)
        {
            id ??= _rootLogId;

            var log = BdoData.New<BdoLog>().WithId(id).WithLogger(this);
            _rootLogId = log?.Id;

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void Log(IBdoLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void LogExecution(IBdoLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void LogDetail(IBdoLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void Log(IBdoLogEvent ev, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public abstract void LogDetail(IBdoLogEvent ev, IBdoLog log = null);
    }
}
