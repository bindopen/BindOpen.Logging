using BindOpen.System.Data.Meta;
using System.Collections.Generic;

namespace BindOpen.System.Logging
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

        #endregion

        // ------------------------------------------
        // IBdoChildClonable interface
        // ------------------------------------------

        #region IBdoObject

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns a cloned instance.</returns>
        public override object Clone()
        {
            return Clone(null);
        }

        public IBdoLogEvent Clone(IBdoDynamicLog parent)
        {
            var cloned = base.Clone() as BdoLogEvent;

            cloned.Parent = parent;
            cloned.Log = Log?.Clone(parent) as BdoLog;
            cloned.Detail = Detail?.Clone<BdoMetaSet>();

            return cloned;
        }

        #endregion
    }
}
