using System.Collections.Generic;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoLogEvent : IBdoEvent
    {
        /// <summary>
        /// 
        /// </summary>
        int Level { get; }

        /// <summary>
        /// 
        /// </summary>
        IBdoRuntimeLog Log { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        IBdoLogEvent WithLog(IBdoRuntimeLog log);

        /// <summary>
        /// The parent.
        /// </summary>
        IBdoRuntimeLog Parent { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        IBdoLogEvent WithParent(IBdoRuntimeLog parent);

        /// <summary>
        /// The result code.
        /// </summary>
        string ResultCode { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        IBdoLogEvent WithResultCode(string resultCode);

        /// <summary>
        /// The root.
        /// </summary>
        IBdoRuntimeLog Root { get; }

        /// <summary>
        /// The source.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        IBdoLogEvent WithSource(string source);

        /// <summary>
        /// The stack traces.
        /// </summary>
        List<IBdoLogEventStackTrace> StackTraces { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stackTraces"></param>
        /// <returns></returns>
        IBdoLogEvent WithStackTraces(params IBdoLogEventStackTrace[] stackTraces);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRecursive"></param>
        /// <param name="kinds"></param>
        /// <returns></returns>
        EventKinds GetMaxEventKind(bool isRecursive = true, params EventKinds[] kinds);

        /// <summary>
        /// Clones this instance considering the parent log.
        /// </summary>
        /// <param name="parent"></param>
        IBdoLogEvent Clone(IBdoRuntimeLog parent, params string[] areas);

        /// <summary>
        /// Clones this instance considering the parent log.
        /// </summary>
        /// <param name="parent"></param>
        T Clone<T>(IBdoRuntimeLog parent, params string[] areas) where T : class;
    }
}