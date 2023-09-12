using BindOpen.Kernel.Data.Helpers;
using BindOpen.Kernel.Logging.Events;
using System;

namespace BindOpen.Kernel.Logging.Loggers
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
        public string ToString(IBdoLog log, string indent = "")
        {
            if (log != null)
            {
                var st = log.Title
                   + (!string.IsNullOrEmpty(log.Description) ? " | " + log.Description : "");

                st += Environment.NewLine;

                if (log is IBdoDynamicLog dynamicLog && dynamicLog._Events != null)
                {
                    foreach (var ev in dynamicLog._Events)
                    {
                        var stEv = ToString(ev, indent + " ");
                        st += string.IsNullOrEmpty(stEv) ? "" : stEv;
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
        public string ToString(IBdoLogEvent ev, string indent = "")
        {
            if (ev != null)
            {
                var displayName = ev.Title;
                var description = ev.Description;

                var st = ev.Date.ToString(DataValueTypes.Date) ?? "";
                st += displayName == null ? "" : (st == "" ? "" : " | ") + displayName;
                st += description == null ? "" : (st == "" ? "" : " | ") + description;

                if (ev.Log != null)
                {
                    st = indent + "o " + (string.IsNullOrEmpty(st) ? "" : st + Environment.NewLine + indent);
                    st += ToString(ev.Log, indent);
                }
                else
                {
                    st = string.IsNullOrEmpty(st) ? "" : (indent + "- " + st + Environment.NewLine);
                }

                return st;
            }

            return null;
        }
    }
}
