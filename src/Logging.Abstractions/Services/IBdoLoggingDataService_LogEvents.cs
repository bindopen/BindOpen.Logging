using BindOpen.System.Data;
using BindOpen.System.Data.Services;
using BindOpen.System.Logging;
using BindOpen.System.Logging.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.System.Eventging.Services
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoLogEventgingDataService : IBdoDataService
    {
        Task<ITDataPageDto<IBdoLogEvent>> ListLogEvents(
            ILogEventsRequestDto requestForm,
            IBdoLog log = null);

        Task<ITDataPageDto<object>> SearchLogEvents(
            ILogEventsRequestDto requestForm,
            IBdoLog log = null);

        /// <summary>
        /// Lists the specified item.
        /// </summary>
        /// <param name="id">The id to consider.</param>
        /// <returns>Returns the specified item.</returns>
        Task<IBdoLogEvent> GetLogEvent(
            string id,
            QueryResultModes mode = QueryResultModes.Quick,
            IBdoLog log = null);

        /// <summary>
        /// Creates the item with the specified id.
        /// </summary>
        /// <param name="item">The item to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto CreateLogEvent(
            IBdoLogEvent item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item to update with.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto UpdateLogEvent(
            IBdoLogEvent item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="id">The id of the item to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto DeleteLogEvent(
            string id,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified items.
        /// </summary>
        /// <param name="ids">The ids of the items to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IEnumerable<IResultItemDto> DeleteLogEvents(
            string[] ids,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Clones the item with the specified id.
        /// </summary>
        /// <param name="id">The item identifier to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItemDto CloneLogEvent(
            string id,
            TransactionScope scope = null,
            IBdoLog log = null);
    }
}