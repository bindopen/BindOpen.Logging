using BindOpen.Data;
using System.Collections.Generic;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoLogEvent : IBdoEvent, ITChildClonable<IBdoLogEvent, IBdoDynamicLog>
    {
        /// <summary>
        /// 
        /// </summary>
        int Level { get; }

        /// <summary>
        /// 
        /// </summary>
        IBdoDynamicLog Log { get; set; }

        /// <summary>
        /// The parent.
        /// </summary>
        IBdoDynamicLog Parent { get; set; }

        /// <summary>
        /// The result code.
        /// </summary>
        string ResultCode { get; set; }

        /// <summary>
        /// The root.
        /// </summary>
        IBdoDynamicLog Root { get; }

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