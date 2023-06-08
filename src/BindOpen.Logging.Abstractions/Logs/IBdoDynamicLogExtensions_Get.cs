using System;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class IBdoLogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IBdoLogEvent> Checkpoints(
            this IBdoLog log,
            bool isRecursive = true,
            Predicate<IBdoLogEvent> filter = null)
        {
            return (log as IBdoDynamicLog)?.Events(q => q.Kind == EventKinds.Checkpoint && (filter?.Invoke(q) != false), isRecursive) ?? Enumerable.Empty<IBdoLogEvent>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IBdoLogEvent> Errors(
            this IBdoLog log,
            bool isRecursive = true,
            Predicate<IBdoLogEvent> filter = null)
        {
            return (log as IBdoDynamicLog)?.Events(q => q.Kind == EventKinds.Error && (filter?.Invoke(q) != false), isRecursive) ?? Enumerable.Empty<IBdoLogEvent>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IBdoLogEvent> Exceptions(
            this IBdoLog log,
            bool isRecursive = true,
            Predicate<IBdoLogEvent> filter = null)
        {
            return (log as IBdoDynamicLog)?.Events(q => q.Kind == EventKinds.Exception && (filter?.Invoke(q) != false), isRecursive) ?? Enumerable.Empty<IBdoLogEvent>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IBdoLogEvent> Messages(
            this IBdoLog log,
            bool isRecursive = true,
            Predicate<IBdoLogEvent> filter = null)
        {
            return (log as IBdoDynamicLog)?.Events(q => q.Kind == EventKinds.Message && (filter?.Invoke(q) != false), isRecursive) ?? Enumerable.Empty<IBdoLogEvent>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IBdoLogEvent> Warnings(
            this IBdoLog log,
            bool isRecursive = true,
            Predicate<IBdoLogEvent> filter = null)
        {
            return (log as IBdoDynamicLog)?.Events(q => q.Kind == EventKinds.Warning && (filter?.Invoke(q) != false), isRecursive) ?? Enumerable.Empty<IBdoLogEvent>();
        }
    }
}