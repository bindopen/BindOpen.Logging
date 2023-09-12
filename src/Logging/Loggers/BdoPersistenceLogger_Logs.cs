using BindOpen.Kernel.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public abstract partial class BdoPersistenceLogger : BdoObject, IBdoLogger
    {
        public abstract Task<ITDataPage<IBdoDynamicLog>> ListLogs(ILogsRequestForm requestForm, IBdoLog log = null);

        public abstract Task<ITDataPage<object>> SearchLogs(ILogsRequestForm requestForm, IBdoLog log = null);

        public abstract Task<IBdoDynamicLog> GetLog(string identifiant, QueryResultModes mode = QueryResultModes.Quick, IBdoLog log = null);

        public abstract IResultItem CreateLog(IBdoDynamicLog item, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem UpdateLog(IBdoDynamicLog item, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem DeleteLog(string identifiant, TransactionScope scope = null, IBdoLog log = null);

        public abstract IEnumerable<IResultItem> DeleteLogs(string[] identifiants, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem CloneLog(string identifiant, TransactionScope scope = null, IBdoLog log = null);
    }
}
