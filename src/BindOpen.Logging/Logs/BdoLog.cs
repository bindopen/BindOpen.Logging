using BindOpen.Data;
using BindOpen.Data.Helpers;
using BindOpen.Data.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a logger of tasks.
    /// </summary>
    public class BdoLog : BdoObject, IBdoDynamicLog
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the Log class.
        /// </summary>
        public BdoLog() : base()
        {
        }

        #endregion

        // ------------------------------------------
        // IBdoLog Implementation
        // ------------------------------------------

        #region IBdoLog

        /// <summary>
        /// Execution of this instance.
        /// </summary>
        public string ResultCode { get; set; }

        // Logger ----------------------------------

        /// <summary>
        /// The logger of this instance.
        /// </summary>
        public IBdoLogger Logger { get; set; }

        // Execution ----------------------------------

        /// <summary>
        /// Execution of this instance.
        /// </summary>
        public IProcessExecution Execution { get; set; }

        // Task ----------------------------------

        /// <summary>
        /// The task of this instance.
        /// </summary>
        public IBdoConfiguration TaskConfig { get; set; }

        /// <summary>
        /// Function that filters event.
        /// </summary>
        public Predicate<IBdoLogEvent> EventFilter { get; set; }

        // Events ----------------------------------

        /// <summary>
        /// Events of this instance.
        /// </summary>
        public IList<IBdoLogEvent> Events { get; set; }

        /// <summary>
        /// The event with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        public IBdoLogEvent this[string id] => GetEvent(id, false);

        /// <summary>
        /// The event with the specified ID.
        /// </summary>
        /// <param name="index"></param>
        public IBdoLogEvent this[int index] => Events?.GetAt(index);

        // Tree ----------------------------------

        /// <summary>
        /// Parent of this instance.
        /// </summary>
        public IBdoLog Parent { get; set; }

        /// <summary>
        /// Root of this instance.
        /// </summary>
        public IBdoLog Root
        {
            get => Parent == null ? this : Parent.Root;
        }

        /// <summary>
        /// The level of this instance.
        /// </summary>
        public int Level => Parent == null ? 0 : Parent.Level + 1;

        /// <summary>
        /// 
        /// </summary>
        public void Sanitize()
        {
            if (this.HasErrorsOrExceptionsOrWarnings() == false)
            {
                RemoveEvents(true, q => q.Kind == EventKinds.Checkpoint);
            }
        }

        #endregion

        // ------------------------------------------
        // IBdoLog implementation
        // ------------------------------------------

        #region IBdoLog

        // Children

        public IEnumerable<IBdoLog> Children() => Children(null);

        public IEnumerable<IBdoLog> Children(Predicate<IBdoLogEvent> filter)
            => Events?.Where(p => filter?.Invoke(p) != false && p.Log != null).Select(p => p.Log).Cast<IBdoLog>() ?? Enumerable.Empty<IBdoLog>();

        public bool HasChild()
        {
            return Events?.Where(p => p.Log != null).Any(p => p.Log != null) ?? false;
        }

        public IBdoLog GetChild(string id, bool isRecursive = false)
        {
            if (Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                return this;
            if (isRecursive)
            {
                foreach (var currentChildLog in Children())
                {
                    var log = currentChildLog.GetChild(id, true);
                    if (log != null) return log;
                }
            }

            return null;
        }

        public IBdoLog InsertChild(EventKinds kind = EventKinds.Any, Action<IBdoLogEvent> updater = null)
        {
            var child = NewLog();

            InsertEvent(kind, updater).WithLog(child);

            return child;
        }

        public IBdoLog InsertChild(
            EventKinds kind,
            string title,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
        {
            var child = InsertChild(kind, q => q
                .WithDescription(title)
                .WithLongDescription(description)
                .WithDate(date)
                .WithResultCode(resultCode));

            return child;
        }

        public IBdoLog AddChild(
            IBdoLog child,
            EventKinds kind = EventKinds.Any,
            string title = null,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
        {
            var ev = InsertEvent(kind, q => q
                .WithDescription(title)
                .WithLongDescription(description)
                .WithDate(date)
                .WithResultCode(resultCode)
                .WithLog(child));

            return this;
        }

        // Events

        public IEnumerable<IBdoLogEvent> GetEvents(bool isRecursive = true, Predicate<IBdoLogEvent> filter = null)
        {
            var events = Events?.Where(q => filter?.Invoke(q) == true).ToList() ?? new List<IBdoLogEvent>();

            if (isRecursive)
            {
                foreach (var child in Children())
                {
                    events.AddRange((child as IBdoDynamicLog)?.GetEvents(isRecursive, filter));
                }
            }

            return events;
        }

        /// <summary>
        /// Returns the event of this instance with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the event to return.</param>
        /// <param name="isRecursive">Indicate whether the search is recursive.</param>
        /// <returns>The event of this instance with the specified ID.</returns>
        public IBdoLogEvent GetEvent(string id, bool isRecursive = false)
        {
            if (id == null || Events == null) return null;

            IBdoLogEvent logEvent = Events.FirstOrDefault(q => q.BdoKeyEquals(id));
            if (isRecursive)
            {
                foreach (var child in Children())
                {
                    logEvent = (child as IBdoDynamicLog)?.GetEvent(id, true);
                    if (logEvent != null) return logEvent;
                }
            }

            return logEvent;
        }

        public bool HasEvent(bool isRecursive = true, Predicate<IBdoLogEvent> filter = null)
        {
            if (Events == null) return false;

            bool hasEvent = Events?.Any(q => filter?.Invoke(q) != false) == true;

            var children = Children();
            if (!hasEvent && isRecursive && children != null)
            {
                foreach (var child in children)
                {
                    if (hasEvent = (child as IBdoDynamicLog)?.HasEvent(isRecursive, filter) ?? false)
                    {
                        return true;
                    }
                }
            }

            return hasEvent;
        }

        public bool HasEvent(bool isRecursive = true, params EventKinds[] kinds)
        {
            var any = !kinds.Any() || kinds.Any(q => q == EventKinds.Any);
            return HasEvent(isRecursive, q => any || kinds.Contains(q.Kind));
        }

        public void RemoveEvents(bool isRecursive, Predicate<IBdoLogEvent> filter = null)
        {
            Events = Events?.Where(q => filter?.Invoke(q) != false).ToList();

            if (isRecursive)
            {
                foreach (var child in Children())
                {
                    (child as IBdoDynamicLog)?.RemoveEvents(isRecursive, filter);
                }
            }
        }

        public IBdoLogEvent InsertEvent(
            EventKinds kind = EventKinds.Any,
            Action<IBdoLogEvent> updater = null)
        {
            var ev = new BdoLogEvent();
            updater?.Invoke(ev);
            ev.WithKind(kind);

            AddEvent(ev);

            return ev;
        }

        public IBdoLog AddEvent(
            EventKinds kind,
            string title,
            string description = null,
            DateTime? date = null,
            string resultCode = null)
        {
            InsertEvent(kind, q => q
                .WithDisplayName(title)
                .WithDescription(description)
                .WithDate(date)
                .WithResultCode(resultCode));

            return this;
        }

        public IBdoLog AddEvent(IBdoLogEvent ev)
        {
            if (ev != null && EventFilter?.Invoke(ev) != false)
            {
                ev.WithParent(this);
                Events ??= new List<IBdoLogEvent>();
                Events.Add(ev);
            }

            return this;
        }

        // Tree

        public IBdoDynamicLog NewLog()
        {
            return (this as IBdoLog).NewLog() as IBdoDynamicLog;
        }

        IBdoLog IBdoLog.NewLog()
        {
            return BdoLogging.NewLog(this);
        }

        public void BuildTree()
        {
            foreach (var ev in Events)
            {
                ev.WithParent(this);
                if (ev.Log != null)
                {
                    ev.Log.WithParent(this);
                    ev.Log.BuildTree();
                }
            }
        }

        // Execution

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            Execution ??= new ProcessExecution();
            Execution.Start();
        }

        /// <summary>
        /// Ends this instance specifying the status.
        /// </summary>
        /// <param name="status">The new status to consider.</param>
        public void End(ProcessExecutionStatus status = ProcessExecutionStatus.Completed)
        {
            Execution ??= new ProcessExecution();
            Execution.End(status);
        }

        #endregion

        // ------------------------------------------
        // IReferenced Implementation
        // ------------------------------------------

        #region IReferenced

        /// <summary>
        /// 
        /// </summary>
        public string Key() => Name ?? Id;

        #endregion

        // ------------------------------------------
        // IIdentifiedPoco Implementation
        // ------------------------------------------

        #region IIdentifiedPoco

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        #endregion

        // ------------------------------------------
        // INamedPoco Implementation
        // ------------------------------------------

        #region INamedPoco

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        #endregion

        // ------------------------------------------
        // ITDetailedPoco Implementation
        // ------------------------------------------

        #region ITDetailedPoco

        /// <summary>
        /// 
        /// </summary>
        public IBdoMetaSet Detail { get; set; }

        #endregion

        // ------------------------------------------
        // IDescribed Implementation
        // ------------------------------------------

        #region IDescribed

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        #endregion

        // ------------------------------------------
        // IDisplayNamed Implementation
        // ------------------------------------------

        #region IDisplayNamed

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }

        #endregion

        // ------------------------------------------
        // IBdoObject interface
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

        public IBdoDynamicLog Clone(IBdoDynamicLog parent, params string[] areas)
        {
            var cloned = base.Clone(areas) as BdoLog;

            cloned.Parent = parent;
            cloned.TaskConfig = TaskConfig?.Clone<IBdoConfiguration>();
            cloned.Detail = Detail?.Clone<IBdoMetaSet>();
            cloned.Events = Events?.Select(p => p.Clone(cloned)).ToList();
            cloned.Execution = Execution?.Clone<IProcessExecution>();

            return cloned;
        }

        #endregion

        // ------------------------------------------
        // IDISPOSABLE METHODS
        // ------------------------------------------

        #region IDisposable_Methods

        private bool _isDisposed = false;

        /// <summary>
        /// Disposes this instance. 
        /// </summary>
        /// <param name="isDisposing">Indicates whether this instance is disposing</param>
        protected override void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            TaskConfig?.Dispose();
            Detail?.Dispose();

            _isDisposed = true;

            base.Dispose(isDisposing);
        }

        public void RemoveEvents(bool isRecursive = true, params EventKinds[] kinds)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}