using BindOpen.Data;
using BindOpen.Logging.Events;

namespace BindOpen.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoLogger : IBdoObject
    {
        string RootLogId { get; }

        IBdoCompleteLog NewRootLog(string id = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        IResultItem Log(IBdoLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        IResultItem LogExecution(IBdoLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        IResultItem LogDetail(IBdoLog item, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        IResultItem Log(IBdoLogEvent ev, IBdoLog log = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        IResultItem LogDetail(IBdoLogEvent ev, IBdoLog log = null);
    }
}