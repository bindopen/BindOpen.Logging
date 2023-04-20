using BindOpen.Data.Meta;
using System;
using System.Collections.Generic;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a log event.
    /// </summary>
    public class BdoLogEvent : BdoEvent, IBdoLogEvent
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the LogEvent class.
        /// </summary>
        public BdoLogEvent() : base()
        {
        }

        #endregion

        // ------------------------------------------
        // IBdoLogEvent Implementation
        // ------------------------------------------

        #region IBdoLogEvent

        // Properties

        /// <summary>
        /// Result code of this instance.
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// Source of this instance.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Dto detail of this instance.
        /// </summary>
        public IList<IBdoLogEventStackTrace> StackTraces { get; set; }

        // Tree ----------------------------------

        /// <summary>
        /// The log of this instance.
        /// </summary>
        public IBdoDynamicLog Log { get; set; }

        /// <summary>
        /// Parent of this instance.
        /// </summary>
        public IBdoDynamicLog Parent { get; set; }

        /// <summary>
        /// Root of this instance.
        /// </summary>
        public IBdoDynamicLog Root => Log?.Root as IBdoDynamicLog;

        /// <summary>
        /// The level of this instance.
        /// </summary>
        public int Level => Parent == null ? 0 : Parent.Level + 1;

        #endregion

        // ------------------------------------------
        // IBdoChildClonable interface
        // ------------------------------------------

        #region IBdoObject

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns a cloned instance.</returns>
        public override object Clone(params string[] areas)
        {
            return Clone(null, Array.Empty<string>());
        }

        public IBdoLogEvent Clone(IBdoDynamicLog parent, params string[] areas)
        {
            var cloned = base.Clone(areas) as BdoLogEvent;

            cloned.Parent = parent;
            cloned.Log = Log?.Clone(parent) as BdoLog;
            cloned.Detail = Detail?.Clone<BdoMetaSet>();

            return cloned;
        }

        #endregion
    }
}
