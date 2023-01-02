using BindOpen.Data;
using System;
using System.Collections.Generic;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoRuntimeLog : IBdoLog
    {
        // Logger

        /// <summary>
        /// 
        /// </summary>
        IBdoLogger Logger { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        IBdoRuntimeLog WithLogger(IBdoLogger logger);

        // Logs

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
        new IBdoRuntimeLog InsertSubLog(Predicate<IBdoLog> filterFinder = null, EventKinds eventKind = EventKinds.Any, string title = null, Criticalities criticality = Criticalities.None, string description = null, string resultCode = null, string source = null, DateTime? date = null);

        // Get events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IBdoLogEvent this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IBdoLogEvent this[string id] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> GetEvents(bool isRecursive = false, params EventKinds[] kinds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        IBdoLogEvent GetEventWithId(string id, bool isRecursive = false);

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Events { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Checkpoints { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Errors { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Exceptions { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Messages { get; }

        /// <summary>
        /// 
        /// </summary>
        List<IBdoLogEvent> Warnings { get; }

        // Insert events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent InsertEvent(EventKinds kind, string title, Criticalities criticality = Criticalities.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent InsertCheckpoint(string title, Criticalities criticality = Criticalities.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent InsertError(string title, Criticalities criticality = Criticalities.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="criticality"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent InsertException(Exception exception, Criticalities criticality = Criticalities.None, string resultCode = null, string source = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent InsertException(string title, Criticalities criticality = Criticalities.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent InsertWarning(string title, Criticalities criticality = Criticalities.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="criticality"></param>
        /// <param name="description"></param>
        /// <param name="resultCode"></param>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoLogEvent InsertMessage(string title, Criticalities criticality = Criticalities.None, string description = null, string resultCode = null, string source = null, DateTime? date = null, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// Adds the events of this instance to the specified log.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="logFinder"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> InsertEventsTo(IBdoRuntimeLog log, Predicate<IBdoLog> logFinder = null, params EventKinds[] kinds);

        /// <summary>
        /// Adds the events of this instance to the specified log.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        List<IBdoLogEvent> InsertEventsTo(IBdoRuntimeLog log, params EventKinds[] kinds);

        // Add events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="childLog"></param>
        /// <param name="logFinder"></param>
        /// <returns></returns>
        IBdoRuntimeLog AddEvent(IBdoLogEvent logEvent, IBdoLog childLog = null, Predicate<IBdoLog> logFinder = null);

        /// <summary>
        /// Adds the specified events to this instance.
        /// </summary>
        /// <param name="events">The events that return events.</param>
        /// <returns></returns>
        IBdoRuntimeLog AddEvents(params IBdoLogEvent[] events);

        /// <summary>
        /// Adds the specified events.
        /// </summary>
        /// <param name="events">The events that return events.</param>
        /// <returns>Returns the added events.</returns>
        IBdoRuntimeLog WithEvents(params IBdoLogEvent[] events);

        /// <summary>
        /// Adds the specified events.
        /// </summary>
        /// <param name="eventFuncs">The functions that return events.</param>
        /// <returns>Returns the added events.</returns>
        IBdoRuntimeLog WithEvents(params Func<IBdoRuntimeLog, IBdoLogEvent>[] eventFuncs);

        // Has events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasErrors(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasErrorsOrExceptions(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasErrorsOrExceptionsOrWarnings(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasExceptions(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        bool HasMessages(bool isRecursive = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        bool HasWarnings(bool isRecursive = true);

        // Tree

        /// <summary>
        /// 
        /// </summary>
        Predicate<IBdoLogEvent> SubLogEventPredicate { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logEvent"></param>
        /// <returns></returns>
        IBdoRuntimeLog WithSubLogEventPredicate(Predicate<IBdoLogEvent> logEvent);

        /// <summary>
        /// 
        /// </summary>
        IBdoRuntimeLog BuildTree();

        // Clone

        /// <summary>
        /// Clones this instance considering the parent log.
        /// </summary>
        /// <param name="parent"></param>
        new IBdoRuntimeLog Clone(IBdoLog parent, params string[] areas);
    }
}