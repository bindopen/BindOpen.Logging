﻿using Microsoft.Extensions.Logging;

namespace BindOpen.System.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITBdoNativeLogger<T> : ITBdoLogger<T>
        where T : IBdoLoggerFormat, new()
    {
        /// <summary>
        /// Sets the native logger.
        /// </summary>
        /// <param name="nativeLogger">The native logger to consider.</param>
        /// <returns>True if this instance has the specified events. False otherwise.</returns>
        IBdoLogger SetNative(ILogger nativeLogger);
    }
}