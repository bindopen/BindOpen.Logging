﻿using BindOpen.System.Data;
using System;
using System.Collections.Generic;

namespace BindOpen.System.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoDynamicLog : IBdoLog, ITChildClonable<IBdoDynamicLog, IBdoDynamicLog>
    {
        /// <summary>
        /// 
        /// </summary>
        IBdoLogger Logger { get; set; }

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

        new IBdoDynamicLog NewLog();

        // Events

        IList<IBdoLogEvent> _Events { get; set; }

        IBdoLog AddEvent(IBdoLogEvent ev);

        IBdoLogEvent InsertEvent(
            EventKinds kind = EventKinds.Any,
            Action<IBdoLogEvent> updater = null);
    }
}