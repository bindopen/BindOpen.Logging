using BindOpen.Kernel.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public abstract partial class BdoPersistentLogger : BdoObject, IBdoLogger
    {
        public abstract Task<ITDataPage<IBdoCompleteLog>> ListLogs(ILogsRequestForm requestForm, IBdoLog log = null);

        public abstract Task<ITDataPage<object>> SearchLogs(ILogsRequestForm requestForm, IBdoLog log = null);

        public abstract Task<IBdoCompleteLog> GetLog(string identifiant, QueryResultModes mode = QueryResultModes.Quick, IBdoLog log = null);

        public abstract IResultItem CreateLog(IBdoCompleteLog item, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem UpdateLog(IBdoCompleteLog item, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem DeleteLog(string identifiant, TransactionScope scope = null, IBdoLog log = null);

        public abstract IEnumerable<IResultItem> DeleteLogs(string[] identifiants, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem CloneLog(string identifiant, TransactionScope scope = null, IBdoLog log = null);
    }
}
