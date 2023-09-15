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
    public partial class BdoLiteDbLogger : BdoPersistenceLogger
    {
        public override async Task<ITDataPage<IBdoDynamicLog>> ListLogs(ILogsRequestForm requestForm, IBdoLog log = null)
        {
            IList<IBdoDynamicLog> list = Array.Empty<IBdoDynamicLog>();

            var page = list.ToDataPage(null);

            return await Task.FromResult(page);
        }

        public override async Task<ITDataPage<object>> SearchLogs(ILogsRequestForm requestForm, IBdoLog log = null)
        {
            IList<object> ev = Array.Empty<object>();

            var page = ev.ToDataPage(null);

            return await Task.FromResult(page);
        }

        public override async Task<IBdoDynamicLog> GetLog(string identifiant, QueryResultModes mode = QueryResultModes.Quick, IBdoLog log = null)
        {
            IBdoDynamicLog item = null;
            return await Task.FromResult(item);
        }

        public override IResultItem CreateLog(IBdoDynamicLog item, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Created);
        }


        public override IResultItem UpdateLog(IBdoDynamicLog item, TransactionScope scope = null, IBdoLog log = null)
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
