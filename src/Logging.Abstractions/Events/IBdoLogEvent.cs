using BindOpen.System.Data;
using System.Collections.Generic;

namespace BindOpen.System.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoLogEvent : IBdoEvent, ITChild<IBdoDynamicLog>, ITChildClonable<IBdoLogEvent, IBdoDynamicLog>
    {
        /// <summary>
        /// 
        /// </summary>
        IBdoDynamicLog Log { get; set; }

        /// <summary>
        /// The result code.
        /// </summary>
        string ResultCode { get; set; }

        /// <summary>
        /// The source.
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// The stack traces.
        /// </summary>
        IList<IBdoLogEventStackTrace> StackTraces { get; set; }
    }
}