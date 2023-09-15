using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Events;
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
        public abstract Task<ITDataPage<IBdoLogEvent>> ListEvents(ILogEventsRequestForm requestForm, IBdoLog log = null);

        public abstract Task<ITDataPage<object>> SearchEvents(ILogEventsRequestForm requestForm, IBdoLog log = null);

        public abstract Task<IBdoLogEvent> GetEvent(string identifiant, QueryResultModes mode = QueryResultModes.Quick, IBdoLog log = null);

        public abstract IResultItem CreateEvent(IBdoLogEvent item, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem UpdateEvent(IBdoLogEvent item, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem DeleteEvent(string identifiant, TransactionScope scope = null, IBdoLog log = null);

        public abstract IEnumerable<IResultItem> DeleteEvents(string[] identifiants, TransactionScope scope = null, IBdoLog log = null);

        public abstract IResultItem CloneEvent(string identifiant, TransactionScope scope = null, IBdoLog log = null);
    }
}
