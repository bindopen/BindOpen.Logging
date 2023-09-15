using BindOpen.Kernel.Logging.Events;
using Microsoft.Extensions.Logging;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public class TBdoExternalLogger<T> : TBdoLogger<T>, ITBdoExternalLogger<T>
        where T : IBdoLoggerFormat, new()
    {
        protected ILogger _nativeLogger;

        /// <summary>
        /// The native logger.
        /// </summary>
        public ILogger ExternalLogger => _nativeLogger;

        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public TBdoExternalLogger() : base()
        {
        }

        /// <summary>
        /// Sets the native logger.
        /// </summary>
        /// <param name="nativeLogger">The native logger to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public IBdoLogger SetExternal(ILogger nativeLogger)
        {
            _nativeLogger = nativeLogger;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLog item, IBdoLog log = null)
        {
            if (item is IBdoCompleteLog dynamicLog && _nativeLogger != null)
            {
                string st = _formater?.ToString(item);

                var kind = dynamicLog.GetMaxEventKind();

                LogExternal(kind, st);

                var events = item.Events();

                if (events != null)
                {
                    foreach (IBdoLogEvent ev in events)
                    {
                        Log(ev);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override void Log(IBdoLogEvent item, IBdoLog log = null)
        {
            if (item != null && _nativeLogger != null)
            {
                string st = _formater?.ToString(item);

                LogExternal(item.Kind, st);

                if (item.Log != null)
                {
                    Log(item.Log);
                }
            }
        }

        private void LogExternal(EventKinds kind, string st)
        {
            if (!string.IsNullOrEmpty(st))
            {
                switch (kind)
                {
                    case EventKinds.Checkpoint:
                        _nativeLogger.LogTrace(st);
                        break;
                    case EventKinds.Error:
                        _nativeLogger.LogError(st);
                        break;
                    case EventKinds.Exception:
                        _nativeLogger.LogCritical(st);
                        break;
                    case EventKinds.Warning:
                        _nativeLogger.LogWarning(st);
                        break;
                    default:
                        _nativeLogger.LogInformation(st);
                        break;
                }
            }
        }
    }
}
