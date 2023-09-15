using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoPersistentLogger : IBdoLogger, IBdoConnected
    {
        ///// <summary>
        ///// Lists the specified log.
        ///// </summary>
        ///// <param name="id">The identifiant to consider.</param>
        ///// <returns>Returns the specified log.</returns>
        //Task<IBdoCompleteLog> GetEventDetail(
        //    string eventIdentifiant,
        //    QueryResultModes mode = QueryResultModes.Quick,
        //    IBdoLog log = null);

        ///// <summary>
        ///// Updates the specified log.
        ///// </summary>
        ///// <param name="log">The log to update with.</param>
        ///// <returns>Returns the operation result.</returns>
        //IResultItem UpdateEventDetail(
        //    string eventIdentifiant,
        //    IBdoMetaSet item,
        //    TransactionScope scope = null,
        //    IBdoLog log = null);
    }
}