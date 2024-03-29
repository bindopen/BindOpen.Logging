﻿namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class IBdoCompleteLogExtensions
    {
        /// <summary>
        /// Indicates whether this instance has the specified events.
        /// </summary>
        /// <param name="kinds">The event kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasEvent(this IBdoLog log, params EventKinds[] kinds)
        {
            return log.HasEvent(false, kinds);
        }

        /// <summary>
        /// Indicates whether this instance has the specified events.
        /// </summary>
        /// <param name="kinds">The event kinds to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasEvent(this IBdoLog log, bool isRecursive = true, params EventKinds[] kinds)
        {
            return log?.HasEvent(isRecursive, kinds) ?? false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HasCheckpoint(this IBdoLog log, bool isRecursive = true)
        {
            return log.HasEvent(isRecursive, EventKinds.Checkpoint);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HasError(this IBdoLog log, bool isRecursive = true)
        {
            return log.HasEvent(isRecursive, EventKinds.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HasException(this IBdoLog log, bool isRecursive = true)
        {
            return log.HasEvent(isRecursive, EventKinds.Exception);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HasMessage(this IBdoLog log, bool isRecursive = true)
        {
            return log.HasEvent(isRecursive, EventKinds.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HasWarning(this IBdoLog log, bool isRecursive = true)
        {
            return log.HasEvent(isRecursive, EventKinds.Warning);
        }

        /// <summary>
        /// Checks this instance has any errors or exceptions.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasErrorOrException(this IBdoLog log, bool isRecursive = true)
        {
            return log.HasEvent(isRecursive, EventKinds.Error, EventKinds.Exception);
        }

        /// <summary>
        /// Checks this instance has any warnings, errors or exceptions.
        /// </summary>
        /// <param name="isRecursive">Indicates whether the search must be recursive.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        public static bool HasErrorOrExceptionOrWarning(this IBdoLog log, bool isRecursive = true)
        {
            return log.HasEvent(isRecursive, EventKinds.Warning, EventKinds.Error, EventKinds.Exception);
        }

    }
}