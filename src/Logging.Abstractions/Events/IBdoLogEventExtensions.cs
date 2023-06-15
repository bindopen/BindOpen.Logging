using BindOpen.System.Logging;

namespace BindOpen.System.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoLogEventExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static T WithLog<T>(
            this T ev,
            IBdoLog log)
            where T : IBdoLogEvent
        {
            if (ev != null)
            {
                ev.Log = log as IBdoDynamicLog;
            }

            return ev;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static T WithParent<T>(
            this T ev,
            IBdoDynamicLog parent)
            where T : IBdoLogEvent
        {
            if (ev != null)
            {
                ev.Parent = parent;
            }

            return ev;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public static T WithResultCode<T>(
            this T ev,
            string resultCode)
            where T : IBdoLogEvent
        {
            if (ev != null)
            {
                ev.ResultCode = resultCode;
            }

            return ev;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T WithSource<T>(
            this T ev,
            string source)
            where T : IBdoLogEvent
        {
            if (ev != null)
            {
                ev.Source = source;
            }

            return ev;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stackTraces"></param>
        /// <returns></returns>
        public static T WithStackTraces<T>(
            this T ev,
            params IBdoLogEventStackTrace[] stackTraces)
            where T : IBdoLogEvent
        {
            if (ev != null)
            {
                ev.StackTraces = stackTraces;
            }

            return ev;
        }

        /// <summary>
        /// Gets the warnings, errors or exceptions of this instance.
        /// </summary>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <param name="kinds">The kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static EventKinds GetMaxEventKind<T>(
            this T ev,
            bool isRecursive = true,
            params EventKinds[] kinds)
            where T : IBdoLogEvent
        {
            EventKinds eventKind = EventKinds.None;

            if (ev?.Log != null)
            {
                eventKind = ev.Log.GetMaxEventKind(isRecursive, kinds);
            }

            if (eventKind == EventKinds.None)
            {
                eventKind = ev?.Kind ?? EventKinds.None;
            }

            return eventKind;
        }
    }
}