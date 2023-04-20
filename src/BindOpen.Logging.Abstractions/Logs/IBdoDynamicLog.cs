using BindOpen.Data;
using System;
using System.Collections.Generic;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoDynamicLog : IBdoLog, ITChildClonable<IBdoDynamicLog, IBdoDynamicLog>
    {
        IEnumerable<IBdoLog> Children(Predicate<IBdoLogEvent> filter);

        /// <summary>
        /// 
        /// </summary>
        IBdoLogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Predicate<IBdoLogEvent> EventFilter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IList<IBdoLogEvent> Events { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        IEnumerable<IBdoLogEvent> GetEvents(bool isRecursive, Predicate<IBdoLogEvent> filter = null);

        bool HasEvent(bool isRecursive = true, Predicate<IBdoLogEvent> filter = null);

        void RemoveEvents(bool isRecursive = true, Predicate<IBdoLogEvent> filter = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        IBdoLogEvent GetEvent(string id, bool isRecursive = false);

        IBdoLog InsertChild(
            EventKinds kind = EventKinds.Any,
            Action<IBdoLogEvent> updater = null);

        IBdoLog AddEvent(IBdoLogEvent ev);

        IBdoLogEvent InsertEvent(
            EventKinds kind = EventKinds.Any,
            Action<IBdoLogEvent> updater = null);

        /// <summary>
        /// 
        /// </summary>
        void BuildTree();

        new IBdoDynamicLog NewLog();
    }
}