using BindOpen.System.Data;
using BindOpen.System.Data.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.System.Logging.Services
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoLoggingDataService : IBdoDataService
    {
        Task<ITDataPageDto<IBdoLog>> ListLogs(
            ILogsRequestDto requestForm,
            IBdoLog log = null);

        Task<ITDataPageDto<object>> SearchLogs(
            ILogsRequestDto requestForm,
            IBdoLog log = null);

        /// <summary>
        /// Lists the specified item.
        /// </summary>
        /// <param name="id">The id to consider.</param>
        /// <returns>Returns the specified item.</returns>
        Task<IBdoLog> GetLog(
            string id,
            QueryResultModes mode = QueryResultModes.Quick,
            IBdoLog log = null);

        /// <summary>
        /// Creates the item with the specified id.
        /// </summary>
        /// <param name="item">The item to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto CreateLog(
            IBdoLog item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item to update with.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto UpdateLog(
            IBdoLog item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="id">The id of the item to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto DeleteLog(
            string id,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified items.
        /// </summary>
        /// <param name="ids">The ids of the items to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IEnumerable<IResultItemDto> DeleteLogs(
            string[] ids,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Clones the item with the specified id.
        /// </summary>
        /// <param name="id">The item identifier to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto CloneLog(
            string id,
            TransactionScope scope = null,
            IBdoLog log = null);
    }
}