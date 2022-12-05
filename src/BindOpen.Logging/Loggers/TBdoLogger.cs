using BindOpen.Framework.MetaData.Items;
using Microsoft.Extensions.Logging;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public class TBdoLogger<T> : DataItem, ITBdoLogger<T>
        where T : IBdoLoggerFormat, new()
    {
        protected ILogger _nativeLogger;
        protected T _formater;

        /// <summary>
        /// The native logger.
        /// </summary>
        public ILogger NativeLogger => _nativeLogger;

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
        /// Sets the native logger.
        /// </summary>
        /// <param name="nativeLogger">The native logger to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public IBdoLogger SetNative(ILogger nativeLogger)
        {
            _nativeLogger = nativeLogger;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public void Log(IBdoLogEvent ev)
        {
            if (ev != null && _nativeLogger != null)
            {
                string st = _formater?.ToString(ev);

                switch (ev?.Kind ?? EventKinds.None)
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
                    case EventKinds.Message:
                        _nativeLogger.LogInformation(st);
                        break;
                    case EventKinds.Warning:
                        _nativeLogger.LogWarning(st);
                        break;
                }

                if (ev?.Log != null)
                {
                    foreach (IBdoLogEvent logEvent in ev.Log.Events)
                    {
                        Log(logEvent);
                    }
                }
            }
        }
    }
}
