using BindOpen.Kernel.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace BindOpen.Kernel.Logging.Loggers.LiteDb
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public partial class BdoLiteDbLogger : BdoPersistentLogger
    {
        public override async Task<ITDataPage<IBdoCompleteLog>> ListLogs(ILogsRequestForm requestForm, IBdoLog log = null)
        {
            IList<IBdoCompleteLog> list = Array.Empty<IBdoCompleteLog>();

            var page = list.ToDataPage(null);

            return await Task.FromResult(page);
        }

        public override async Task<ITDataPage<object>> SearchLogs(ILogsRequestForm requestForm, IBdoLog log = null)
        {
            IList<object> ev = Array.Empty<object>();

            var page = ev.ToDataPage(null);

            return await Task.FromResult(page);
        }

        public override async Task<IBdoCompleteLog> GetLog(string identifiant, QueryResultModes mode = QueryResultModes.Quick, IBdoLog log = null)
        {
            IBdoCompleteLog item = null;
            return await Task.FromResult(item);
        }

        public override IResultItem CreateLog(IBdoCompleteLog item, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Created);
        }


        public override IResultItem UpdateLog(IBdoCompleteLog item, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Updated);
        }


        public override IResultItem DeleteLog(string identifiant, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Deleted);
        }


        public override IEnumerable<IResultItem> DeleteLogs(string[] identifiants, TransactionScope scope = null, IBdoLog log = null)
        {
            return Array.Empty<IResultItem>();
        }

        public override IResultItem CloneLog(string identifiant, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Created);
        }
    }
}
