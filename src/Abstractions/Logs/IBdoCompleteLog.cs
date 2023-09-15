using BindOpen.Kernel.Logging.Events;
using BindOpen.Kernel.Logging.Loggers;
using System;
using System.Collections.Generic;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoCompleteLog : IBdoLog, ITChildClonable<IBdoCompleteLog, IBdoCompleteLog>, IBdoLoggerTracked
    {
        /// <summary>
        /// 
        /// </summary>
        Predicate<IBdoLogEvent> EventFilter { get; set; }

        // Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IBdoLogEvent this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IBdoLogEvent this[string id] { get; }

        IBdoLog InsertChild(
            EventKinds kind = EventKinds.Any,
            Action<IBdoLogEvent> updater = null);

        /// <summary>
        /// 
        /// </summary>
        void BuildTree();

        new IBdoCompleteLog NewLog();

        // Events

        IList<IBdoLogEvent> _Events { get; }

        IBdoLog AddEvent(IBdoLogEvent ev);

        IBdoLogEvent InsertEvent(
            EventKinds kind = EventKinds.Any,
            Action<IBdoLogEvent> updater = null);

        int RemoveEvents(
            Predicate<IBdoLogEvent> filter = null,
            bool isRecursive = true);
    }
}