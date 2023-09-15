using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;
using BindOpen.Kernel.Scoping.Connectors;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoPersistenceLogger : IBdoLogger, IBdoConnected
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
        Task<ITDataPage<IBdoLogEvent>> ListEvents(
            ILogEventsRequestForm requestForm,
            IBdoLog log = null);

        Task<ITDataPage<object>> SearchEvents(
            ILogEventsRequestForm requestForm,
            IBdoLog log = null);

        /// <summary>
        /// Lists the specified client.
        /// </summary>
        /// <param name="id">The identifiant to consider.</param>
        /// <returns>Returns the specified client.</returns>
        Task<IBdoLogEvent> GetEvent(
            string identifiant,
            QueryResultModes mode = QueryResultModes.Quick,
            IBdoLog log = null);

        /// <summary>
        /// Creates the client with the specified identifiant.
        /// </summary>
        /// <param name="client">The client to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem CreateEvent(
            IBdoLogEvent item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Updates the specified client.
        /// </summary>
        /// <param name="client">The client to update with.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem UpdateEvent(
            IBdoLogEvent item,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified client.
        /// </summary>
        /// <param name="id">The identifiant of the client to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem DeleteEvent(
            string identifiant,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Deletes the specified clients.
        /// </summary>
        /// <param name="identifiants">The identifiants of the clients to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IEnumerable<IResultItem> DeleteEvents(
            string[] identifiants,
            TransactionScope scope = null,
            IBdoLog log = null);

        /// <summary>
        /// Clones the client with the specified identifiant.
        /// </summary>
        /// <param name="id">The client identifier to consider.</param>
        /// <returns>Returns the operation result.</returns>
        IResultItem CloneEvent(
            string identifiant,
            TransactionScope scope = null,
            IBdoLog log = null);
    }
}