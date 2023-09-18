using BindOpen.Kernel.Data;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.Kernel.Logging.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoLoggingRepository
    {
        /// <summary>
        /// Lists the specified log.
        /// </summary>
        /// <param name="id">The identifiant to consider.</param>
        /// <returns>Returns the specified log.</returns>
        Task<IBdoCompleteLog> GetLogExecution(
            string logIdentifiant,
            QueryResultModes mode = QueryResultModes.Quick,
            IBdoLog log = null);

        /// <summary>
        /// Updates the specified log.
        /// </summary>
        /// <param name="log">The log to update with.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem UpdateLogExecution(
            string logIdentifiant,
            IBdoProcessExecution item,
            TransactionScope scope = null,
            IBdoLog log = null);
    }
}