using BindOpen.Data.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public string ResultCode { get; private set; }

        /// <summary>
        /// Source of this instance.
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// Dto detail of this instance.
        /// </summary>
        public List<IBdoLogEventStackTrace> StackTraces { get; private set; }

        // Tree ----------------------------------

        /// <summary>
        /// The log of this instance.
        /// </summary>
        public IBdoRuntimeLog Log { get; private set; }

        /// <summary>
        /// Parent of this instance.
        /// </summary>
        public IBdoRuntimeLog Parent { get; private set; }

        /// <summary>
        /// Root of this instance.
        /// </summary>
        public IBdoRuntimeLog Root => Log?.Root as IBdoRuntimeLog;

        /// <summary>
        /// The level of this instance.
        /// </summary>
        public int Level => Parent == null ? 0 : Parent.Level + 1;

        // Get methods

        /// <summary>
        /// Gets the warnings, errors or exceptions of this instance.
        /// </summary>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <param name="kinds">The kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public EventKinds GetMaxEventKind(
            bool isRecursive = true,
            params EventKinds[] kinds)
        {
            EventKinds eventKind = EventKinds.None;

            if (Log != null)
            {
                eventKind = Log.GetMaxEventKind(isRecursive, kinds);
            }

            if (eventKind == EventKinds.None)
            {
                eventKind = Kind;
            }

            return eventKind;
        }

        // With methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public IBdoLogEvent WithLog(IBdoRuntimeLog log)
        {
            Log = log;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public IBdoLogEvent WithParent(IBdoRuntimeLog parent)
        {
            Parent = parent;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public IBdoLogEvent WithResultCode(string resultCode)
        {
            ResultCode = resultCode;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IBdoLogEvent WithSource(string source)
        {
            Source = source;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stackTraces"></param>
        /// <returns></returns>
        public IBdoLogEvent WithStackTraces(params IBdoLogEventStackTrace[] stackTraces)
        {
            StackTraces = stackTraces?.ToList();

            return this;
        }

        #endregion

        // ------------------------------------------
        // IBdoItem interface
        // ------------------------------------------

        #region IBdoItem

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns a cloned instance.</returns>
        public override object Clone(params string[] areas)
        {
            return Clone(null, Array.Empty<string>());
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <param name="parent">The log to consider.</param>
        /// <returns>Returns a cloned instance.</returns>
        public IBdoLogEvent Clone(IBdoRuntimeLog parent, params string[] areas)
        {
            var cloned = base.Clone(areas) as BdoLogEvent;

            cloned.Parent = parent;
            cloned.Log = Log?.Clone(parent) as BdoLog;
            cloned.Detail = Detail?.Clone<BdoMetaSet>();
            //cloned.StackTraces = StackTraces?.Select(p=> p.Clone<LogEventStackTrace>()).ToList();

            return cloned;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <param name="parent">The parent to consider.</param>
        /// <returns>Returns a cloned instance.</returns>
        public T Clone<T>(IBdoRuntimeLog parent, params string[] areas) where T : class
        {
            return Clone(parent, areas) as T;
        }

        #endregion
    }
}
