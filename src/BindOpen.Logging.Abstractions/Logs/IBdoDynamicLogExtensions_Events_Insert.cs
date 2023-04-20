using System;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class IBdoDynamicLogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static IBdoLogEvent InsertCheckpoint(this IBdoLog log, Action<IBdoLogEvent> updater = null)
        {
            return (log as IBdoDynamicLog)?.InsertEvent(EventKinds.Checkpoint, updater);
        }

        /// <summary>
        /// 
        /// </summary>
        public static IBdoLogEvent InsertError(this IBdoLog log, Action<IBdoLogEvent> updater = null)
        {
            return (log as IBdoDynamicLog)?.InsertEvent(EventKinds.Error, updater);
        }

        /// <summary>
        /// 
        /// </summary>
        public static IBdoLogEvent InsertException(this IBdoLog log, Action<IBdoLogEvent> updater = null)
        {
            return (log as IBdoDynamicLog)?.InsertEvent(EventKinds.Exception, updater);
        }

        /// <summary>
        /// 
        /// </summary>
        public static IBdoLogEvent InsertMessage(this IBdoLog log, Action<IBdoLogEvent> updater = null)
        {
            return (log as IBdoDynamicLog)?.InsertEvent(EventKinds.Message, updater);
        }

        /// <summary>
        /// 
        /// </summary>
        public static IBdoLogEvent InsertWarning(this IBdoLog log, Action<IBdoLogEvent> updater = null)
        {
            return (log as IBdoDynamicLog)?.InsertEvent(EventKinds.Warning, updater);
        }
    }
}