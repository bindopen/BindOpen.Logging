using BindOpen.System.Data.Helpers;
using BindOpen.System.Processing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.System.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class IBdoDynamicLogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        public static T WithLogger<T>(
            this T log,
            IBdoLogger logger)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                dynamicLog.Logger = logger;
            }

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        public static T WithEventFilter<T>(
            this T log,
            Predicate<IBdoLogEvent> filter)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                dynamicLog.EventFilter = filter;
            }

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        public static T WithExecution<T>(
            T log,
            IBdoProcessExecution execution)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                dynamicLog.Execution = execution;
            }

            return log;
        }

        // Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        public static T WithEvents<T>(
            this T log,
            params IBdoLogEvent[] events)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog && events != null)
            {
                dynamicLog.RemoveEvents();

                foreach (var ev in events)
                {
                    dynamicLog.AddEvent(ev);
                }
            }

            return log;
        }


        public static EventKinds GetMaxEventKind<T>(
            this T log,
            bool isRecursive = true,
            params EventKinds[] kinds)
            where T : IBdoDynamicLog
        {
            return log?.Events(isRecursive, kinds).Select(p => p.Kind).ToList().Max() ?? EventKinds.None;
        }


        public static IEnumerable<IBdoLogEvent> Events<T>(
            this T log,
            Predicate<IBdoLogEvent> filter = null,
            bool isRecursive = true)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                var events = dynamicLog._Events?.Where(q => filter == null || filter?.Invoke(q) == true).ToList() ?? new List<IBdoLogEvent>();

                if (dynamicLog._Children != null && isRecursive)
                {
                    foreach (var child in dynamicLog._Children)
                    {
                        events.AddRange((child as IBdoDynamicLog)?.Events(filter, isRecursive));
                    }
                }

                return events;
            }

            return Enumerable.Empty<IBdoLogEvent>();
        }

        public static IEnumerable<IBdoLogEvent> Events<T>(
            this T log,
            bool isRecursive = true,
            params EventKinds[] kinds)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                return dynamicLog.Events(q => kinds.Has(q.Kind), isRecursive);
            }

            return null;
        }

        /// <summary>
        /// Returns the event of this instance with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the event to return.</param>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <returns>The event of this instance with the specified ID.</returns>
        public static IBdoLogEvent Event<T>(
            this T log,
            Predicate<IBdoLogEvent> filter = null,
            bool isRecursive = false)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                IBdoLogEvent ev = dynamicLog._Events?.FirstOrDefault(q => filter == null || filter?.Invoke(q) != false);

                if (isRecursive)
                {
                    foreach (var child in dynamicLog._Children)
                    {
                        ev = (child as IBdoDynamicLog)?.Event(filter, true);
                        if (ev != null) return ev;
                    }
                }

                return ev;
            }

            return null;
        }

        /// <summary>
        /// Returns the event of this instance with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the event to return.</param>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <returns>The event of this instance with the specified ID.</returns>
        public static IBdoLogEvent Event<T>(
            this T log,
            string id,
            bool isRecursive = false)
            where T : IBdoLog
        {
            if (!string.IsNullOrEmpty(id) && log is IBdoDynamicLog dynamicLog)
            {
                return dynamicLog.Event(q => q.BdoKeyEquals(id), isRecursive);
            }

            return null;
        }

        public static bool HasEvent<T>(
            this T log,
            Predicate<IBdoLogEvent> filter = null,
            bool isRecursive = true)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                bool hasEvent = dynamicLog._Events?.Any(q => filter == null || filter?.Invoke(q) != false) == true;

                if (!hasEvent && isRecursive && dynamicLog._Children != null)
                {
                    foreach (var child in dynamicLog._Children)
                    {
                        if (hasEvent = (child as IBdoDynamicLog)?.HasEvent(filter, isRecursive) ?? false)
                        {
                            return true;
                        }
                    }
                }

                return hasEvent;
            }

            return false;
        }

        public static bool HasEvent<T>(
            this T log,
            bool isRecursive = true,
            params EventKinds[] kinds)
            where T : IBdoLog
            => log.HasEvent(q => kinds.Has(q.Kind), isRecursive);
    }
}