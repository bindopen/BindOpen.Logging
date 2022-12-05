using BindOpen.Framework.Extensions.Processing;
using BindOpen.Framework.MetaData;
using BindOpen.Framework.MetaData.Elements;
using Microsoft.Extensions.Logging;
using System;

namespace BindOpen.Logging
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
        public static BdoRuntimeLog CreateLog(IBdoLogger logger = null)
        {
            return new BdoRuntimeLog().WithLogger(logger) as BdoRuntimeLog;
        }

        /// <summary>
        /// Creates a new instance of the BdoLog class.
        /// </summary>
        /// <param name="eventFilter">The function that filters events.</param>
        /// <param name="logger">The logger to consider.</param>
        public static BdoRuntimeLog CreateLog(
            Predicate<IBdoLogEvent> eventFilter,
            IBdoLogger logger)
        {
            return CreateLog(logger)
                .WithSubLogEventPredicate(eventFilter) as BdoRuntimeLog;
        }

        /// <summary>
        /// Creates a new instance of the BdoLog class.
        /// </summary>
        /// <param name="task">The task to consider.</param>
        /// <param name="eventFilter">The function that filters events.</param>
        /// <param name="logger">The logger to consider.</param>
        public static BdoRuntimeLog CreateLog(
            IBdoTaskConfiguration task,
            Predicate<IBdoLogEvent> eventFilter = null,
            IBdoLogger logger = null)
        {
            return CreateLog(eventFilter, logger)
                .WithTask(task) as BdoRuntimeLog;
        }

        /// <summary>
        /// Creates a new instance of the BdoLog class specifying parent.
        /// </summary>
        /// <param name="parent">The parent log to consider.</param>
        /// <param name="task">The task to consider.</param>
        /// <param name="eventFilter">The function that filters events.</param>
        public static BdoRuntimeLog CreateLog(
            IBdoRuntimeLog parent,
            IBdoTaskConfiguration task = null,
            Predicate<IBdoLogEvent> eventFilter = null)
        {
            return CreateLog(eventFilter, parent?.Logger)
                .WithParent(parent)
                .WithTask(task) as BdoRuntimeLog;
        }

        // LogEvent --------------

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
        public static BdoLogEvent CreateLogEvent(
            EventKinds kind,
            string title = null,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            string id = null)
        {
            var ev = new BdoLogEvent()
                .WithSource(source)
                .WithResultCode(resultCode)
                .WithCriticality(criticality)
                .WithLongDescription(description)
                .WithDate(date)
                .WithKind(kind) as BdoLogEvent;

            if (string.IsNullOrEmpty(id))
            {
                ev.WithId(id);
            }
            ev.WithDisplayName(title);

            return ev;
        }

        /// <summary>
        /// Instantiates a new instance of the LogEvent class.
        /// </summary>
        /// <param name="exception">The exception to consider.</param>
        /// <param name="criticality">The criticality to consider.</param>
        /// <param name="resultCode">The result code to consider.</param>
        /// <param name="source">The ExtensionDataContext to consider.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static BdoLogEvent CreateLogEvent(
            Exception exception,
            Criticalities criticality = Criticalities.None,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            string id = null)
        {
            var ev = CreateLogEvent(
                EventKinds.Exception,
                exception?.Message,
                criticality,
                exception?.ToString(),
                resultCode, source,
                date, id);

            return ev;
        }

        /// <summary>
        /// Instantiates a new instance of the LogEvent class.
        /// </summary>
        /// <param name="event1">The event to consider.</param>
        public static BdoLogEvent CreateLogEvent(BdoEvent ev)
        {
            var logEvent = new BdoLogEvent()
                .WithCriticality(ev?.Criticality ?? Criticalities.None)
                .WithKind(ev?.Kind ?? EventKinds.None)
                .WithDetail(ev?.Detail?.Clone<DataElementSet>()) as BdoLogEvent;

            return logEvent;
        }

        // Event --------------

        /// <summary>
        /// Instantiates a new instance of the BdoEvent class.
        /// </summary>
        /// <param name="kind">The kind of this instance.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static BdoEvent CreateEvent(
            EventKinds kind,
            string title = null,
            Criticalities criticality = Criticalities.None,
            string description = null,
            DateTime? date = null,
            string id = null)
        {
            var ev = new BdoEvent()
                .WithCriticality(criticality)
                .WithLongDescription(description)
                .WithDate(date)
                .WithKind(kind) as BdoEvent;

            if (string.IsNullOrEmpty(id))
            {
                ev.WithId(id);
            }
            ev.WithDisplayName(title);

            return ev;
        }

        /// <summary>
        /// Instantiates a new instance of the BdoEvent class.
        /// </summary>
        /// <param name="exception">The exception to consider.</param>
        /// <param name="criticality">The criticality to consider.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static BdoEvent CreateEvent(
            Exception exception,
            Criticalities criticality = Criticalities.None,
            DateTime? date = null,
            string id = null)
        {
            var ev = CreateEvent(
                EventKinds.Exception,
                exception?.Message,
                criticality,
                exception?.ToString(),
                date, id);

            return ev;
        }

        // Conditional event --------------

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
        public static BdoConditionalEvent CreateConditionalEvent(
            string conditionScript,
            EventKinds kind,
            string title = null,
            Criticalities criticality = Criticalities.None,
            string description = null,
            DateTime? date = null,
            string id = null)
        {
            var ev = new BdoConditionalEvent()
                .WithCondition(conditionScript)
                .WithCriticality(criticality)
                .WithLongDescription(description)
                .WithDate(date)
                .WithKind(kind) as BdoConditionalEvent;

            if (string.IsNullOrEmpty(id))
            {
                ev.WithId(id);
            }
            ev.WithDisplayName(title);

            return ev;
        }

        /// <summary>
        /// Instantiates a new instance of the ConditionalEvent class.
        /// </summary>
        /// <param name="conditionScript">The condition script of this instance.</param>
        /// <param name="exception">The exception to consider.</param>
        /// <param name="criticality">The criticality to consider.</param>
        /// <param name="date">The date of this instance.</param>
        /// <param name="id">The ID of this instance.</param>
        public static BdoConditionalEvent CreateConditionalEvent(
            string conditionScript,
            Exception exception,
            Criticalities criticality = Criticalities.None,
            DateTime? date = null,
            string id = null)
        {
            var ev = CreateConditionalEvent(
                conditionScript,
                EventKinds.Exception,
                exception?.Message,
                criticality,
                exception?.ToString(),
                date, id);

            return ev;
        }

        // Logger --------------

        /// <summary>
        /// Creates a new instance of a ITBdoLogger instance.
        /// </summary>
        /// <param name="logger">The logger to consider.</param>
        /// <returns>Returns the created BDO logger.</returns>
        public static TBdoLogger<T> CreateLogger<T>(ILogger logger)
            where T : IBdoLoggerFormat, new()
        {
            var bdoLogger = new TBdoLogger<T>();
            bdoLogger.SetNative(logger);

            return bdoLogger;
        }
    }
}
