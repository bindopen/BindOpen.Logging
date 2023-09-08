using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Helpers;
using System;

namespace BindOpen.Kernel.Logging
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
        public string ToString(IBdoDynamicLog log)
        {
            if (log != null)
            {
                var st = log.DisplayName
                   + (!string.IsNullOrEmpty(log.Description) ? " | " + log.Description + Environment.NewLine : "");
                if (log._Events != null)
                {
                    foreach (var ev in log._Events)
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
                int level = ev.Level();
                var indent = new string(' ', (level < 1 ? 0 : level - 1) * 2);

                var displayName = ev.DisplayName ?? ev.Log?.DisplayName;
                var description = ev.Description ?? ev.Log?.Description;

                var st = ev.Date.ToString(DataValueTypes.Date) ?? "";
                st += displayName == null ? "" : (st == "" ? "" : " | ") + displayName;
                st += description == null ? "" : (st == "" ? "" : " | ") + description;

                return indent + (ev.Log != null ? "o " : "- ") + st;
            }

            return null;
        }
    }
}
