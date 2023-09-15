using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;
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
        public override async Task<ITDataPage<IBdoLogEvent>> ListEvents(ILogEventsRequestForm requestForm, IBdoLog log = null)
        {
            IList<IBdoLogEvent> list = Array.Empty<IBdoLogEvent>();

            var page = list.ToDataPage(null);

            return await Task.FromResult(page);
        }

        public override async Task<ITDataPage<object>> SearchEvents(ILogEventsRequestForm requestForm, IBdoLog log = null)
        {
            IList<object> ev = Array.Empty<object>();

            var page = ev.ToDataPage(null);

            return await Task.FromResult(page);
        }

        public override async Task<IBdoLogEvent> GetEvent(string identifiant, QueryResultModes mode = QueryResultModes.Quick, IBdoLog log = null)
        {
            IBdoLogEvent ev = null;
            return await Task.FromResult(ev);
        }

        public override IResultItem CreateEvent(IBdoLogEvent item, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Created);
        }

        public override IResultItem UpdateEvent(IBdoLogEvent item, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Updated);
        }

        public override IResultItem DeleteEvent(string identifiant, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Created);
        }

        public override IEnumerable<IResultItem> DeleteEvents(string[] identifiants, TransactionScope scope = null, IBdoLog log = null)
        {
            return Array.Empty<IResultItem>();
        }

        public override IResultItem CloneEvent(string identifiant, TransactionScope scope = null, IBdoLog log = null)
        {
            return BdoData.NewResultItem(ResourceStatus.Created);
        }
    }
}
