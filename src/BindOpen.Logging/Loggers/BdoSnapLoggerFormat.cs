using System;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a logger format.
    /// </summary>
    public class BdoSnapLoggerFormat : IBdoLoggerFormat
    {
        /// <summary>
        /// Converts the log to the string.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <returns>Returns the string that converts the specified log.</returns>
        public string ToString(IBdoRuntimeLog log)
        {
            if (log != null)
            {
                var st = log.DisplayName
                   + (!string.IsNullOrEmpty(log.Description) ? " | " + log.Description + Environment.NewLine : "");
                if (log.Events != null)
                {
                    foreach (var ev in log.Events)
                    {
                        st += ToString(ev) + Environment.NewLine;
                    }
                }
                return st;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public string ToString(IBdoLogEvent ev)
        {
            if (ev != null)
            {
                int level = ev.Level;
                string indent = new string(' ', (level < 0 ? 0 : level - 1) * 2);

                return indent + (ev.Log != null ? "o " : "- ")
                   + ev.DisplayName
                   + (!string.IsNullOrEmpty(ev.Description) ? " | " + ev.Description : "");
            }

            return null;
        }
    }
}
