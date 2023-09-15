using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoPersistenceLogger : IBdoLogger, IBdoConnected
    {
        ///// <summary>
        ///// Lists the specified log.
        ///// </summary>
        ///// <param name="id">The identifiant to consider.</param>
        ///// <returns>Returns the specified log.</returns>
        //Task<IBdoDynamicLog> GetLogExecution(
        //    string logIdentifiant,
        //    QueryResultModes mode = QueryResultModes.Quick,
        //    IBdoLog log = null);

        ///// <summary>
        ///// Updates the specified log.
        ///// </summary>
        ///// <param name="log">The log to update with.</param>
        ///// <returns>Returns the operation result.</returns>
        //IResultItem UpdateLogExecution(
        //    string logIdentifiant,
        //    IBdoProcessExecution item,
        //    TransactionScope scope = null,
        //    IBdoLog log = null);
    }
}