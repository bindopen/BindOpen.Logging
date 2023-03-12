using BindOpen.Data;
using BindOpen.Data.Helpers;
using BindOpen.Data.Meta;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a logger of tasks.
    /// </summary>
    public class BdoLog : BdoItem, IBdoRuntimeLog
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the Log class.
        /// </summary>
        public BdoLog() : base()
        {
        }

        #endregion

        // ------------------------------------------
        // IBdoLog Implementation
        // ------------------------------------------

        #region IBdoLog

        // Logger ----------------------------------

        /// <summary>
        /// The logger of this instance.
        /// </summary>
        public IBdoLogger Logger { get; private set; } = null;

        // Execution ----------------------------------

        /// <summary>
        /// Execution of this instance.
        /// </summary>
        public IProcessExecution Execution { get; private set; }

        // Task ----------------------------------

        /// <summary>
        /// The task of this instance.
        /// </summary>
        public IBdoConfiguration TaskConfig { get; private set; }

        /// <summary>
        /// Function that filters event.
        /// </summary>
        public Predicate<IBdoLogEvent> SubLogEventPredicate { get; private set; }

        // Events ----------------------------------

        /// <summary>
        /// Events of this instance.
        /// </summary>
        public List<IBdoLogEvent> Events { get; private set; }

        /// <summary>
        /// The event with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        public IBdoLogEvent this[string id] => id == null ? null : Events?.Find(p => p.BdoKeyEquals(id));

        /// <summary>
        /// The event with the specified ID.
        /// </summary>
        /// <param name="index"></param>
        public IBdoLogEvent this[int index] => Events?.GetAt(index);

        /// <summary>
        /// Errors of this instance.
        /// </summary>
        public List<IBdoLogEvent> Errors => Events?.Where(p => p.Kind == EventKinds.Error).ToList() ?? new List<IBdoLogEvent>();

        /// <summary>
        /// Warnings of this instance.
        /// </summary>
        public List<IBdoLogEvent> Warnings => Events?.Where(p => p.Kind == EventKinds.Warning).ToList() ?? new List<IBdoLogEvent>();

        /// <summary>
        /// Messages of this instance.
        /// </summary>
        public List<IBdoLogEvent> Messages => Events?.Where(p => p.Kind == EventKinds.Message).ToList() ?? new List<IBdoLogEvent>();

        /// <summary>
        /// Exceptions of this instance.
        /// </summary>
        public List<IBdoLogEvent> Exceptions => Events?.Where(p => p.Kind == EventKinds.Exception).ToList() ?? new List<IBdoLogEvent>();

        /// <summary>
        /// Checkpoints of this instance.
        /// </summary>
        public List<IBdoLogEvent> Checkpoints => Events?.Where(p => p.Kind == EventKinds.Checkpoint).ToList() ?? new List<IBdoLogEvent>();

        /// <summary>
        /// Logs of this instance.
        /// </summary>
        public List<IBdoLog> SubLogs => Events?.Where(p => p.Log != null).Select(p => p.Log).Cast<IBdoLog>().ToList() ?? new List<IBdoLog>();

        // Tree ----------------------------------

        /// <summary>
        /// Parent of this instance.
        /// </summary>
        public IBdoLog Parent { get; private set; }

        /// <summary>
        /// Root of this instance.
        /// </summary>
        public IBdoLog Root
        {
            get => Parent == null ? this : Parent.Root;
        }

        /// <summary>
        /// The level of this instance.
        /// </summary>
        public int Level => Parent == null ? 0 : Parent.Level + 1;

        #endregion

        // ------------------------------------------
        // IBdoRuntimeLog implementation
        // ------------------------------------------

        #region IBdoRuntimeLog

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subLogEventPredicate"></param>
        /// <returns></returns>
        public IBdoRuntimeLog WithSubLogEventPredicate(Predicate<IBdoLogEvent> subLogEventPredicate)
        {
            SubLogEventPredicate = subLogEventPredicate;

            return this;
        }

        // Logging ----------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public IBdoRuntimeLog WithLogger(IBdoLogger logger)
        {
            Logger = logger;

            return this;
        }

        /// <summary>
        /// Sets the specified logger.
        /// </summary>
        /// <param name="logger">The logger to add.</param>
        public IBdoLog SetLogger(ILogger logger)
        {
            Logger = BdoLogging.CreateLogger<BdoSnapLoggerFormat>(logger);

            return this;
        }

        /// <summary>
        /// Sets the specified logger.
        /// </summary>
        /// <param name="logger">The logger to add.</param>
        public IBdoLog SetLogger<T>(ILogger logger)
            where T : IBdoLoggerFormat, new()
        {
            Logger = BdoLogging.CreateLogger<T>(logger);

            return this;
        }

        // Events ------------------------------------

        // Insert events

        /// <summary>
        /// Adds the specified log event.
        /// </summary>
        /// <param name="kind">The kind of this instance.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLogEvent InsertEvent(
            EventKinds kind,
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            var ev = BdoLogging.CreateLogEvent(
                    kind,
                    title ?? childLog?.DisplayName,
                    criticality,
                    description,
                    resultCode,
                    source,
                    date);
            AddEvent(ev, childLog, logFinder);

            return ev;
        }

        /// <summary>
        /// Adds the specified warning.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="aSource">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLogEvent InsertWarning(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return InsertEvent(
                EventKinds.Warning,
                title,
                criticality,
                description,
                resultCode,
                source,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified error.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="aSource">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLogEvent InsertError(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string aSource = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return InsertEvent(
                EventKinds.Error,
                title,
                criticality,
                description,
                resultCode,
                aSource,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified checkpoint.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLogEvent InsertCheckpoint(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return InsertEvent(
                EventKinds.Checkpoint,
                title,
                criticality,
                description,
                resultCode,
                source,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Inserts the specified message.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLogEvent InsertMessage(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return InsertEvent(
                EventKinds.Message,
                title,
                criticality,
                description,
                resultCode,
                source,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified exception.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLogEvent InsertException(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return InsertEvent(
                EventKinds.Exception,
                title,
                criticality,
                description,
                resultCode,
                source,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified exception.
        /// </summary>
        /// <param name="exception">The exception to consider.</param>
        /// <param name="criticality">The criticality to consider.</param>
        /// <param name="resultCode">The result code to consider.</param>
        /// <param name="source">The ExtensionDataContext to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLogEvent InsertException(
            Exception exception,
            Criticalities criticality = Criticalities.None,
            string resultCode = null,
            string source = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            var ev = BdoLogging.CreateLogEvent(exception, criticality, resultCode, source);
            AddEvent(ev, childLog, logFinder);

            return ev;
        }

        /// <summary>
        /// Inserts the events of this instance into the specified log.
        /// </summary>
        /// <param name="log">The log whose task results must be added.</param>
        /// <param name="kinds">The event kinds to add.</param>
        /// <returns>Returns the added events.</returns>
        public List<IBdoLogEvent> InsertEventsTo(
            IBdoRuntimeLog log,
            params EventKinds[] kinds)
        {
            return InsertEventsTo(log, null, kinds);
        }

        /// <summary>
        /// Adds the events of this instance to the specified log.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        /// <param name="kinds">The event kinds to add.</param>
        /// <returns>Returns the added events.</returns>
        public List<IBdoLogEvent> InsertEventsTo(
            IBdoRuntimeLog log,
            Predicate<IBdoLog> logFinder = null,
            params EventKinds[] kinds)
        {
            var events = new List<IBdoLogEvent>();

            if (log is IBdoRuntimeLog runtimeLog)
            {
                if ((runtimeLog?.Events != null) && (logFinder?.Invoke(runtimeLog) != false))
                {
                    events = Events?.Where(p => kinds.Length == 0 || kinds.Contains(p.Kind)).ToList<IBdoLogEvent>();
                    if (events != null)
                    {
                        foreach (IBdoLogEvent currentEvent in events)
                        {
                            var clonedEvent = currentEvent.Clone<BdoLogEvent>(this);
                            runtimeLog.AddEvent(clonedEvent);
                        }
                    }
                }
            }

            return events;
        }

        // Add events

        /// <summary>
        /// Adds the specified events to this instance.
        /// </summary>
        /// <param name="events">The events that return events.</param>
        /// <returns></returns>
        public IBdoRuntimeLog AddEvents(params IBdoLogEvent[] events)
        {
            Events?.AddRange(events);

            return this;
        }

        /// <summary>
        /// Adds the events of the specified log.
        /// </summary>
        /// <param name="log">The log whose task results must be added.</param>
        /// <param name="kinds">The event kinds to add.</param>
        /// <returns>Returns the added events.</returns>
        public IBdoLog AddEvents(
            IBdoLog log,
            params EventKinds[] kinds)
        {
            return AddEvents(log, null, kinds);
        }

        /// <summary>
        /// Adds the events of the specified log.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        /// <param name="kinds">The event kinds to add.</param>
        /// <returns>Returns the added events.</returns>
        public IBdoLog AddEvents(
            IBdoLog log,
            Predicate<IBdoLog> logFinder = null,
            params EventKinds[] kinds)
        {
            var events = new List<IBdoLogEvent>();

            if (log is IBdoRuntimeLog runtimeLog)
            {
                if ((runtimeLog?.Events != null) && (logFinder?.Invoke(runtimeLog) != false))
                {
                    events = runtimeLog.Events.Where(p => kinds.Length == 0 || kinds.Contains(p.Kind)).ToList<IBdoLogEvent>();
                    if (events != null)
                    {
                        foreach (IBdoLogEvent currentEvent in events)
                        {
                            var clonedEvent = currentEvent.Clone<BdoLogEvent>(this);
                            AddEvent(clonedEvent);
                        }
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// Inserts the events of this instance into the specified log.
        /// </summary>
        /// <param name="log">The log whose task results must be added.</param>
        /// <param name="kinds">The event kinds to add.</param>
        /// <returns>Returns the added events.</returns>
        public IBdoLog AddEventsTo(
            IBdoLog log,
            params EventKinds[] kinds)
        {
            InsertEventsTo(log as IBdoRuntimeLog, kinds);

            return this;
        }

        /// <summary>
        /// Adds the events of this instance to the specified log.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        /// <param name="kinds">The event kinds to add.</param>
        /// <returns>Returns the added events.</returns>
        public IBdoLog AddEventsTo(
            IBdoLog log,
            Predicate<IBdoLog> logFinder = null,
            params EventKinds[] kinds)
        {
            InsertEventsTo(log as IBdoRuntimeLog, logFinder, kinds);

            return this;
        }

        /// <summary>
        /// Adds a new log event.
        /// </summary>
        /// <param name="logEvent">The log event to add.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoRuntimeLog AddEvent(
        IBdoLogEvent logEvent,
        IBdoLog childLog = null,
        Predicate<IBdoLog> logFinder = null)
        {
            if (logEvent != null)
            {
                if (logFinder == null || (childLog != null && logFinder.Invoke(childLog)))
                {
                    if (childLog != null)
                    {
                        if (logEvent.DisplayName == null && childLog.DisplayName != null) logEvent.WithDisplayName(childLog.DisplayName);
                        if (logEvent.Description == null && childLog.Description != null) logEvent.WithLongDescription(childLog.Description);
                        if (logEvent.Kind == EventKinds.Any) logEvent.WithKind(childLog.GetMaxEventKind());
                        childLog.WithParent(this);

                        if (childLog is IBdoRuntimeLog runtimeChildLog)
                        {
                            runtimeChildLog.WithLogger(Logger);
                            logEvent.WithLog(runtimeChildLog);
                        }
                    }

                    if (SubLogEventPredicate == null || SubLogEventPredicate.Invoke(logEvent))
                    {
                        (Events ??= new List<IBdoLogEvent>()).Add(logEvent);
                        logEvent.WithParent(this);
                        Logger?.Log(logEvent);
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// Adds the specified log event.
        /// </summary>
        /// <param name="kind">The kind of this instance.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLog AddEvent(
            EventKinds kind,
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            InsertEvent(
                kind,
                title,
                criticality,
                description,
                resultCode,
                source,
                date,
                childLog,
                logFinder);

            return this;
        }

        /// <summary>
        /// Adds the specified warning.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="aSource">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLog AddWarning(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string aSource = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return AddEvent(
                EventKinds.Warning,
                title,
                criticality,
                description,
                resultCode,
                aSource,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified error.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="aSource">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLog AddError(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string aSource = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return AddEvent(
                EventKinds.Error,
                title,
                criticality,
                description,
                resultCode,
                aSource,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified checkpoint.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLog AddCheckpoint(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return AddEvent(
                EventKinds.Checkpoint,
                title,
                criticality,
                description,
                resultCode,
                source,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified message.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLog AddMessage(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return AddEvent(
                EventKinds.Message,
                title,
                criticality,
                description,
                resultCode,
                source,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified exception.
        /// </summary>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLog AddException(
            string title,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            return AddEvent(
                EventKinds.Exception,
                title,
                criticality,
                description,
                resultCode,
                source,
                date, childLog, logFinder);
        }

        /// <summary>
        /// Adds the specified exception.
        /// </summary>
        /// <param name="exception">The exception to consider.</param>
        /// <param name="criticality">The criticality to consider.</param>
        /// <param name="resultCode">The result code to consider.</param>
        /// <param name="source">The ExtensionDataContext to consider.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        public IBdoLog AddException(
            Exception exception,
            Criticalities criticality = Criticalities.None,
            string resultCode = null,
            string source = null,
            IBdoLog childLog = null,
            Predicate<IBdoLog> logFinder = null)
        {
            InsertException(exception, criticality, resultCode, source, childLog, logFinder);

            return this;
        }

        /// <summary>
        /// Adds the specified events.
        /// </summary>
        /// <param name="eventFuncs">The functions that return events.</param>
        /// <returns>Returns the added events.</returns>
        public IBdoRuntimeLog WithEvents(params Func<IBdoRuntimeLog, IBdoLogEvent>[] eventFuncs)
        {
            foreach (var fun in eventFuncs)
            {
                AddEvent(fun?.Invoke(this));
            }
            return this;
        }

        /// <summary>
        /// Adds the specified events.
        /// </summary>
        /// <param name="events">The events that return events.</param>
        /// <returns>Returns the added events.</returns>
        public IBdoRuntimeLog WithEvents(params IBdoLogEvent[] events)
        {
            Events = events == null ? null : new List<IBdoLogEvent>(events);

            return this;
        }

        // Clear events

        /// <summary>
        /// Clears the specified events.
        /// </summary>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <param name="kinds">The kinds to consider.</param>
        public IBdoLog ClearEvents(
            bool isRecursive = true,
            params EventKinds[] kinds)
        {
            Events?.RemoveAll(p => kinds.Contains(p.Kind));

            if (isRecursive)
            {
                foreach (BdoLog childLog in SubLogs)
                {
                    childLog.ClearEvents(isRecursive, kinds);
                }
            }

            return this;
        }

        /// <summary>
        /// Sanitize this instance.
        /// </summary>
        public IBdoLog Sanitize()
        {
            // we clear the task check points if there is no special results in load task
            if (!HasErrorsOrExceptionsOrWarnings())
            {
                ClearEvents(true, EventKinds.Checkpoint);
            }

            return this;

        }

        // Sub logs ------------------------------------

        public IBdoRuntimeLog InsertSubLog(
            Predicate<IBdoLog> filterFinder = null,
            EventKinds eventKind = EventKinds.Any,
            string title = null,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null)
        {
            var childLog = BdoLogging.CreateLog();

            AddEvent(
                eventKind,
                title,
                criticality,
                description,
                resultCode,
                source,
                date,
                childLog,
                filterFinder);

            return childLog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterFinder"></param>
        /// <param name="eventKind"></param>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        IBdoLog IBdoLog.InsertSubLog(
            Predicate<IBdoLog> filterFinder,
            EventKinds eventKind,
            string title,
            Criticalities criticality,
            string description,
            string resultCode,
            string source,
            DateTime? date)
        {
            return (this as IBdoRuntimeLog).InsertSubLog(
                filterFinder,
                eventKind,
                title,
                criticality,
                description,
                resultCode,
                source,
                date);
        }

        /// <summary>
        /// Adds the specified warning.
        /// </summary>
        /// <param name="eventKind">The event kind of this instance.</param>
        /// <param name="childLog">The child log of this instance.</param>
        /// <param name="logFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        public IBdoLog AddSubLog(
            IBdoLog childLog,
            Predicate<IBdoLog> logFinder = null,
            EventKinds eventKind = EventKinds.Any,
            string title = null,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null)
        {
            AddEvent(
                eventKind,
                title,
                criticality,
                description,
                resultCode,
                source,
                date,
                childLog,
                logFinder);

            return childLog;
        }

        /// <summary>
        /// Adds the specified warning.
        /// </summary>
        /// <param name="eventKind">The event kind of this instance.</param>
        /// <param name="filterFinder">The filter function to consider. If true then the child log is added otherwise it is not.</param>
        /// <param name="title">The title of this instance.</param>
        /// <param name="description">The description of this instance.</param>
        /// <param name="criticality">The criticality of this instance.</param>
        /// <param name="resultCode">The result code of this instance.</param>
        /// <param name="source">The ExtensionDataContext of this instance.</param>
        /// <param name="date">The date to consider.</param>
        public IBdoLog AddSubLog(
            Predicate<IBdoLog> filterFinder = null,
            EventKinds eventKind = EventKinds.Any,
            string title = null,
            Criticalities criticality = Criticalities.None,
            string description = null,
            string resultCode = null,
            string source = null,
            DateTime? date = null)
        {
            InsertSubLog(
                filterFinder,
                eventKind,
                title,
                criticality,
                description,
                resultCode,
                source,
                date);

            return this;
        }

        /// <summary>
        /// Removes the specified child log.
        /// </summary>
        /// <param name="childLog">The child log to remove.</param>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        public IBdoLog RemoveSubLog(IBdoLog childLog, bool isRecursive = true)
        {
            if (childLog != null)
            {
                RemoveSubLog(childLog.Id, isRecursive);
            }

            return this;
        }

        /// <summary>
        /// Removes the child log with the specified ID.
        /// </summary>
        /// <param name="id">The ID to consider.</param>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        public IBdoLog RemoveSubLog(string id, bool isRecursive = true)
        {
            if ((id != null) && (Events != null) && (Events.RemoveAll(q => q.Log.BdoKeyEquals(id)) == 0))
                foreach (BdoLog subLog in SubLogs)
                {
                    subLog.RemoveSubLog(id, isRecursive);
                }

            return this;
        }

        #endregion

        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors       

        // Events --------------------------------

        /// <summary>
        /// Returns the event of this instance with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the event to return.</param>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <returns>The event of this instance with the specified ID.</returns>
        public IBdoLogEvent GetEventWithId(string id, bool isRecursive = false)
        {
            if (id == null || Events == null) return null;

            IBdoLogEvent logEvent = Events.Find(q => q.BdoKeyEquals(id));
            if (isRecursive)
            {
                foreach (BdoLog childLog in SubLogs)
                {
                    logEvent = childLog.GetEventWithId(id, true);
                    if (logEvent != null) return logEvent;
                }
            }

            return logEvent;
        }

        /// <summary>
        /// Gets the specified events of this instance.
        /// </summary>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <param name="kinds">The kinds to consider.</param>
        /// <returns>Returns the specified events of this instance.</returns>
        public List<IBdoLogEvent> GetEvents(
            bool isRecursive = false,
            params EventKinds[] kinds)
        {
            if (Events == null) return new List<IBdoLogEvent>();

            List<IBdoLogEvent> events = Events.ToList<IBdoLogEvent>().GetEvents(kinds);

            if (isRecursive)
            {
                foreach (BdoLog childLog in SubLogs)
                {
                    events.AddRange(childLog.GetEvents(isRecursive, kinds));
                }
            }

            return events;
        }

        /// <summary>
        /// Returns the number of the specified events of this instance.
        /// </summary>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <param name="kinds">The kinds to consider.</param>
        /// <returns>The number of the specified events of this instance.</returns>
        public int GetEventCount(
            bool isRecursive = false,
            params EventKinds[] kinds)
        {
            if (Events == null) return 0;

            int i = Events.Count(p => kinds.Contains(p.Kind));

            if (isRecursive)
                foreach (IBdoRuntimeLog childLog in SubLogs)
                    i += GetEventCount(isRecursive, kinds);

            return i;
        }

        /// <summary>
        /// Gets the warnings, errors or exceptions of this instance.
        /// </summary>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <param name="kinds">The kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public EventKinds GetMaxEventKind(
            bool isRecursive = true,
            params EventKinds[] kinds)
        {
            return GetEvents(isRecursive, kinds).Select(p => p.Kind).ToList().Max();
        }

        // Has events -----------------------------------

        /// <summary>
        /// Indicates whether this instance has the specified events.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <param name="kinds">The event kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasEvent(
            bool isRecursive = true,
            params EventKinds[] kinds)
        {
            if (Events == null) return false;

            bool hasEvent = Events.ToList<IBdoLogEvent>().Has(kinds);

            if (!hasEvent && isRecursive && SubLogs != null)
            {
                foreach (BdoLog childLog in SubLogs)
                {
                    if (hasEvent = childLog.HasEvent(isRecursive, kinds))
                    {
                        return true;
                    }
                }
            }

            return hasEvent;
        }

        /// <summary>
        /// Indicates whether this instance has the specified events.
        /// </summary>
        /// <param name="kinds">The event kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasEvent(
            params EventKinds[] kinds)
        {
            return HasEvent(false, kinds);
        }

        /// <summary>
        /// Checks this instance has any warnings.
        /// </summary>
        /// <param name="kinds">The event kinds to consider.</param>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasWarnings(
            bool isRecursive = true)
        {
            return HasEvent(isRecursive);
        }

        /// <summary>
        /// Checks this instance has any errors.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasErrors(bool isRecursive = true)
        {
            return HasEvent(isRecursive, EventKinds.Error);
        }

        /// <summary>
        /// Checks this instance has any exceptions.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasExceptions(bool isRecursive = true)
        {
            return HasEvent(isRecursive, EventKinds.Exception);
        }

        /// <summary>
        /// Checks this instance has any messages.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasMessages(bool isRecursive = true)
        {
            return HasEvent(isRecursive, EventKinds.Message);
        }

        /// <summary>
        /// Checks this instance has any errors or exceptions.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasErrorsOrExceptions(bool isRecursive = true)
        {
            return HasEvent(isRecursive, EventKinds.Error, EventKinds.Exception);
        }

        /// <summary>
        /// Checks this instance has any warnings, errors or exceptions.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public bool HasErrorsOrExceptionsOrWarnings(bool isRecursive = true)
        {
            return HasEvent(isRecursive, EventKinds.Warning, EventKinds.Error, EventKinds.Exception);
        }

        // Tree --------------------------------

        /// <summary>
        /// Returns the sub log with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the log to return.</param>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>The child with the specified ID.</returns>
        public IBdoLog GetSubLogWithId(string id, bool isRecursive = false)
        {
            if (Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                return this;
            if (isRecursive)
            {
                foreach (var currentChildLog in SubLogs)
                {
                    IBdoLog log = currentChildLog.GetSubLogWithId(id);
                    if (log != null) return log;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks this instance has child log.
        /// </summary>
        /// <returns>True if this instance has child log. False otherwise.</returns>
        public bool HasSubLog()
        {
            return SubLogs.Count > 0;
        }

        /// <summary>
        /// Builds the tree of this instance.
        /// </summary>
        public IBdoRuntimeLog BuildTree()
        {
            foreach (IBdoLogEvent ev in Events)
            {
                ev.WithParent(this);
                if (ev.Log != null)
                {
                    ev.Log.WithParent(this);
                    ev.Log.BuildTree();
                }
            }

            return this;
        }

        /// <summary>
        /// Creates a new instance of the IBdoLog class.
        /// </summary>
        /// <returns>Returns a new instance of the IBdoLog class.</returns>
        public IBdoLog NewLog()
        {
            return BdoLogging.CreateLog(this);
        }

        // Execution

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public IBdoLog Start()
        {
            Execution ??= new ProcessExecution();
            Execution.Start();

            return this;
        }

        /// <summary>
        /// Ends this instance specifying the status.
        /// </summary>
        /// <param name="status">The new status to consider.</param>
        public IBdoLog End(ProcessExecutionStatus status = ProcessExecutionStatus.Completed)
        {
            Execution ??= new ProcessExecution();
            Execution.End(status);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        public IBdoLog WithExecution(IProcessExecution execution)
        {
            Execution = execution;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public IBdoLog WithTask(IBdoConfiguration task)
        {
            TaskConfig = task;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public IBdoLog WithParent(IBdoLog parent)
        {
            Parent = parent;

            return this;
        }

        #endregion

        // ------------------------------------------
        // IReferenced Implementation
        // ------------------------------------------

        #region IReferenced

        /// <summary>
        /// 
        /// </summary>
        public string Key() => Name ?? Id;

        #endregion

        // ------------------------------------------
        // IIdentifiedPoco Implementation
        // ------------------------------------------

        #region IIdentifiedPoco

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IBdoLog WithId(string id)
        {
            Id = id;
            return this;
        }

        #endregion

        // ------------------------------------------
        // INamedPoco Implementation
        // ------------------------------------------

        #region INamedPoco

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoLog WithName(string name)
        {
            Name = BdoData.NewName(name, "log_");
            return this;
        }

        #endregion

        // ------------------------------------------
        // ITDetailedPoco Implementation
        // ------------------------------------------

        #region ITDetailedPoco

        /// <summary>
        /// 
        /// </summary>
        public IBdoMetaSet Detail { get; set; }

        #endregion

        // ------------------------------------------
        // IDescribed Implementation
        // ------------------------------------------

        #region IDescribed

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        #endregion

        // ------------------------------------------
        // IDisplayNamed Implementation
        // ------------------------------------------

        #region IDisplayNamed

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }

        #endregion

        // ------------------------------------------
        // IBdoItem interface
        // ------------------------------------------

        #region IBdoItem

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns a cloned instance.</returns>
        public override object Clone(params string[] areas)
        {
            return Clone(null, Array.Empty<string>());
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <param name="parent">The log to consider.</param>
        /// <returns>Returns a cloned instance.</returns>
        IBdoLog IBdoLog.Clone(IBdoLog parent, params string[] areas)
        {
            return null;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <param name="parent">The log to consider.</param>
        /// <returns>Returns a cloned instance.</returns>
        public IBdoRuntimeLog Clone(IBdoLog parent, params string[] areas)
        {
            var cloned = base.Clone(areas) as BdoLog;

            cloned.Parent = parent;
            cloned.TaskConfig = TaskConfig?.Clone<IBdoConfiguration>();
            cloned.Detail = Detail?.Clone<IBdoMetaSet>();
            cloned.Events = Events?.Select(p => p.Clone<IBdoLogEvent>(cloned)).ToList();
            cloned.Execution = Execution?.Clone<IProcessExecution>();

            return cloned;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <param name="parent">The parent to consider.</param>
        /// <returns>Returns a cloned instance.</returns>
        public T Clone<T>(IBdoLog parent, params string[] areas) where T : class
        {
            return Clone(parent, areas) as T;
        }

        #endregion

        // ------------------------------------------
        // IDISPOSABLE METHODS
        // ------------------------------------------

        #region IDisposable_Methods

        private bool _isDisposed = false;

        /// <summary>
        /// Disposes this instance. 
        /// </summary>
        /// <param name="isDisposing">Indicates whether this instance is disposing</param>
        protected override void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            TaskConfig?.Dispose();
            Detail?.Dispose();

            _isDisposed = true;

            base.Dispose(isDisposing);
        }

        #endregion
    }
}