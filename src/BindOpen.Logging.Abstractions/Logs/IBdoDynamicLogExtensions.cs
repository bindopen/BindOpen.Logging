using System;
using System.Linq;

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
            IProcessExecution execution)
            where T : IBdoLog
        {
            if (log is IBdoDynamicLog dynamicLog)
            {
                dynamicLog.Execution = execution;
            }

            return log;
        }

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
            if (log is IBdoDynamicLog dynamicLog)
            {
                dynamicLog.Events = events;
            }

            return log;
        }


        public static EventKinds GetMaxEventKind<T>(
            this T log,
            bool isRecursive = true,
            params EventKinds[] kinds)
            where T : IBdoLog
        {
            return log?.GetEvents(isRecursive, kinds).Select(p => p.Kind).ToList().Max() ?? EventKinds.None;
        }
    }
}