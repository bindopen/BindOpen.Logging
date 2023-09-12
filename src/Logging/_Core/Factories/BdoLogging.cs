using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Conditions;
using BindOpen.Kernel.Data.Meta;
using BindOpen.Kernel.Logging.Events;
using BindOpen.Kernel.Logging.Loggers;
using BindOpen.Kernel.Scoping;
using BindOpen.Kernel.Scoping.Connectors;
using Microsoft.Extensions.Logging;
using System;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// This class represents a logging factory.
    /// </summary>
    public static class BdoLogging
    {
        // Log --------------

        /// <summary>
        /// Creates a new instance of the BdoLog class.
        /// </summary>
        /// <param name="logger">The logger to consider.</param>
        public static BdoLog NewLog()
        {
            return new BdoLog();
        }

        /// <summary>
        /// Creates a new instance of the BdoLog class.
        /// </summary>
        /// <param name="eventFilter">The function that filters events.</param>
        /// <param name="logger">The logger to consider.</param>
        public static BdoLog NewLog(Predicate<IBdoLogEvent> eventFilter)
        {
            return NewLog()
                .WithEventFilter(eventFilter);
        }

        /// <summary>
        /// Creates a new instance of the BdoLog class.
        /// </summary>
        /// <param name="task">The task to consider.</param>
        /// <param name="eventFilter">The function that filters events.</param>
        /// <param name="logger">The logger to consider.</param>
        public static BdoLog NewLog(
            IBdoConfiguration task,
            Predicate<IBdoLogEvent> eventFilter = null)
        {
            return NewLog(eventFilter)
                .WithTask(task);
        }

        /// <summary>
        /// Creates a new instance of the BdoLog class specifying parent.
        /// </summary>
        /// <param name="parent">The parent log to consider.</param>
        /// <param name="task">The task to consider.</param>
        /// <param name="eventFilter">The function that filters events.</param>
        public static BdoLog NewLog(
            IBdoDynamicLog parent,
            IBdoConfiguration task = null,
            Predicate<IBdoLogEvent> eventFilter = null)
        {
            return NewLog(eventFilter)
                .WithTask(task)
                .WithParent(parent);
        }

        // Events --------------

        /// <summary>
        /// Instantiates a new instance of the BdoEvent class.
        /// </summary>
        /// <param name="kind">The kind of this instance.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static BdoEvent NewEvent(
            EventKinds kind,
            Action<BdoEvent> updater = null)
        {
            var ev = NewEvent<BdoEvent>(kind, updater);

            return ev;
        }

        /// <summary>
        /// Instantiates a new instance of the LogEvent class.
        /// </summary>
        /// <param name="kind">The kind of this instance.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static BdoLogEvent NewLogEvent(
            EventKinds kind,
            Action<BdoLogEvent> updater = null)
        {
            var ev = NewEvent(kind, updater);

            return ev;
        }

        /// <summary>
        /// Instantiates a new instance of the ConditionalEvent class.
        /// </summary>
        /// <param name="conditionScript">The condition script of this instance.</param>
        /// <param name="kind">The kind of this instance.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static BdoConditionalEvent NewConditionalEvent(
            IBdoCondition condition,
            EventKinds kind,
            Action<BdoConditionalEvent> updater)
        {
            var ev = NewEvent(kind, updater)
                .WithCondition(condition);

            return ev;
        }

        /// <summary>
        /// Instantiates a new instance of the BdoEvent class.
        /// </summary>
        /// <param name="kind">The kind of this instance.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static T NewEvent<T>(
            EventKinds kind,
            Action<T> updater)
            where T : class, IBdoEvent, new()
        {
            var ev = new T();

            updater?.Invoke(ev);

            ev.Kind = kind;

            return ev;
        }

        // Logger --------------

        /// <summary>
        /// Creates a new instance of a ITBdoLogger instance.
        /// </summary>
        /// <param name="logger">The logger to consider.</param>
        /// <returns>Returns the created BDO logger.</returns>
        public static T NewLogger<T>()
            where T : IBdoLogger, new()
        {
            var logger = BdoData.New<T>();

            return logger;
        }

        /// <summary>
        /// Creates a new instance of a ITBdoLogger instance.
        /// </summary>
        /// <param name="logger">The logger to consider.</param>
        /// <returns>Returns the created BDO logger.</returns>
        public static TBdoLogger<T> NewLogger<T>(ILogger logger)
            where T : IBdoLoggerFormat, new()
        {
            var bdoLogger = BdoData.New<TBdoExternalLogger<T>>();
            bdoLogger.SetExternal(logger);

            return bdoLogger;
        }

        /// <summary>
        /// Creates a new instance of a ITBdoLogger instance.
        /// </summary>
        /// <param name="logger">The logger to consider.</param>
        /// <returns>Returns the created BDO logger.</returns>
        public static TBdoLogger<BdoSnapLoggerFormat> NewLogger(ILogger logger)
        {
            var bdoLogger = BdoData.New<TBdoExternalLogger<BdoSnapLoggerFormat>>();
            bdoLogger.SetExternal(logger);

            return bdoLogger;
        }

        /// <summary>
        /// Creates a new instance of a ITBdoLogger instance.
        /// </summary>
        /// <param name="logger">The logger to consider.</param>
        /// <returns>Returns the created BDO logger.</returns>
        public static TBdoLogger<BdoSnapLoggerFormat> NewLogger(ILoggerFactory factory)
        {
            var logger = factory.CreateLogger<IBdoScope>();

            var bdoLogger = NewLogger(logger);

            return bdoLogger;
        }

        /// <summary>
        /// Creates a new instance of a ITBdoLogger instance.
        /// </summary>
        /// <param name="logger">The logger to consider.</param>
        /// <returns>Returns the created BDO logger.</returns>
        public static T NewLogger<T>(IBdoConnector connector)
            where T : IBdoPersistencegger, new()
        {
            var logger = BdoData.New<T>()
                .WithConnector(connector);

            return logger;
        }
    }
}
