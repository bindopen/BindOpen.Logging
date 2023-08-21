﻿using BindOpen.System.Data;

namespace BindOpen.System.Logging
{
    /// <summary>
    /// This class represents a log extension.
    /// </summary>
    public static class BdoLogExtension
    {
        /// <summary>
        /// Converts the specified log to string.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <returns>The string corresponding to the specified log using the specified formater.</returns>
        public static string ToString<T>(this IBdoDynamicLog log)
            where T : IBdoLoggerFormat, new()
        {
            var formater = new T();
            return formater.ToString(log);
        }
        /// <summary>
        /// 
        /// </summary>
        public static T WithChildren<T>(
            this T log,
            params IBdoLog[] children)
            where T : IBdoLog
        {
            if (log != null)
            {
                log._Children = BdoData.NewSet<IBdoLog>(children);
            }

            return log;
        }

        public static T AddChildren<T>(this T log, params IBdoLog[] children) where T : IBdoLog
        {
            if (log != null)
            {
                log._Children ??= BdoData.NewSet<IBdoLog>();
                foreach (var child in children)
                {
                    log._Children.Add(child);
                }
            }

            return log;
        }


    }
}
