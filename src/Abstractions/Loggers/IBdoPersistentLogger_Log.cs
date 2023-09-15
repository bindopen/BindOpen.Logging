using BindOpen.Kernel.Data;
using BindOpen.Kernel.Scoping.Connectors;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoPersistentLogger : IBdoLogger, IBdoConnected
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="motcle"></param>
        /// <param name="personneType"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageOffset"></param>
        /// <returns></returns>
        Task<ITDataPage<IBdoCompleteLog>> ListLogs(
            ILogsRequestForm requestForm,
            IBdoLog log = null);

        Task<ITDataPage<object>> SearchLogs(
            ILogsRequestForm requestForm,
            IBdoLog log = null);

        /// <summary>
        /// Lists the specified log.
        /// </summary>
        /// <param name="id">The identifiant to consider.</param>
        /// <returns>Returns the specified log.</returns>
        Task<IBdoCompleteLog> GetLog(
            string identifiant,
            QueryResultModes mode = QueryResultModes.Quick,
            IBdoLog log = null);

        /// <summary>
        /// Creates the log with the specified identifiant.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem CreateLog(
            IBdoCompleteLog item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Updates the specified log.
        /// </summary>
        /// <param name="log">The log to update with.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem UpdateLog(
            IBdoCompleteLog item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified log.
        /// </summary>
        /// <param name="id">The identifiant of the log to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem DeleteLog(
            string identifiant,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified logs.
        /// </summary>
        /// <param name="identifiants">The identifiants of the logs to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IEnumerable<IResultItem> DeleteLogs(
            string[] identifiants,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Clones the log with the specified identifiant.
        /// </summary>
        /// <param name="id">The log identifier to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem CloneLog(
            string identifiant,
            TransactionScope scope = null,
            IBdoLog log = null);
    }
}