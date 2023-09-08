using BindOpen.Kernel.Logging;
using System;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class IBdoDynamicLogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T AddEvent<T>(this T log, EventKinds eventKind, Action<IBdoLogEvent> updater = null)
            where T : IBdoLog
        {
            (log as IBdoDynamicLog)?.InsertEvent(eventKind, updater);
            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T AddCheckpoint<T>(this T log, Action<IBdoLogEvent> updater = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Checkpoint, updater);
            return default;
        }

        public static T AddCheckpoint<T>(
            this T log,
            string title,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Checkpoint, title, description, date, resultCode);
            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T AddError<T>(this T log, Action<IBdoLogEvent> updater = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Error, updater);
            return log;
        }

        public static T AddError<T>(
            this T log,
            string title,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Error, title, description, date, resultCode);
            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T AddException<T>(this T log, Action<IBdoLogEvent> updater = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Exception, updater);
            return log;
        }

        public static T AddException<T>(
            this T log,
            string title,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Exception, title, description, date, resultCode);
            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T AddMessage<T>(this T log, Action<IBdoLogEvent> updater = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Message, updater);
            return log;
        }

        public static T AddMessage<T>(
            this T log,
            string title,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Message, title, description, date, resultCode);
            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        public static T AddWarning<T>(this T log, Action<IBdoLogEvent> updater = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Warning, updater);
            return log;
        }

        public static T AddWarning<T>(
            this T log,
            string title,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
            where T : IBdoLog
        {
            log?.AddEvent(EventKinds.Warning, title, description, date, resultCode);
            return log;
        }
    }
}