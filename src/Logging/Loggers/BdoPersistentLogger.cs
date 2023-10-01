using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Services;
using BindOpen.Kernel.Logging.Events;
using BindOpen.Kernel.Logging.Repositories;
using System.Linq;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public abstract partial class BdoPersistentLogger : BdoDataService, IBdoPersistentLogger
    {
        private IBdoLoggingRepository _repository;

        public IBdoLoggingRepository Repository { get => _repository; protected set { _repository = value; } }

        protected BdoPersistentLogger() : base()
        {
        }

        protected BdoPersistentLogger(IBdoLoggingRepository repo) : base()
        {
            Repository = repo;
        }


        protected string _rootLogId;

        public string RootLogId { get => _rootLogId; protected set => _rootLogId = value; }

        public IBdoCompleteLog NewRootLog(string id = null, ILogsRequestForm requestForm = null, IBdoLog log = null)
        {
            id ??= _rootLogId;

            var rootLog = _repository?.GetLog(id).Result;
            if (rootLog == null)
            {
                rootLog = BdoData.New<BdoPersistentLog>().WithId(id);
                _repository?.CreateLog(rootLog);
            }

            if (rootLog != null)
            {
                rootLog?.WithLogger(this);

                var children = _repository.ListLogs(requestForm, log).Result?.Items?.ToArray();
                rootLog.WithChildren(children);
            }

            _rootLogId = rootLog?.Id;

            return rootLog;
        }

        public IBdoCompleteLog NewRootLog(ILogsRequestForm requestForm, IBdoLog log = null)
            => NewRootLog(null, requestForm);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public IResultItem Log(IBdoLog item, IBdoLog log = null)
        {
            var result = BdoData.NewResultItem(item?.Id);

            if (item is IBdoCompleteLog dynamicLog)
            {
                result.Status = ExecuteScoped(
                    null,
                    (s, r) =>
                    {
                        _repository.UsingConnection((conn, l) =>
                        {
                            r = _repository?.CreateLog(dynamicLog, null, log);
                        }, false, log);
                    }, ResourceStatus.Created, log).Status;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public IResultItem LogExecution(IBdoLog item, IBdoLog log = null)
        {
            var result = BdoData.NewResultItem(item?.Id);

            if (item?.Execution != null)
            {
                result.Status = ExecuteScoped(
                    null,
                    (s, r) =>
                    {
                        _repository.UsingConnection((conn, l) =>
                        {
                            r = _repository?.UpdateLogExecution(item.Id, item.Execution, null, log);
                        }, false, log);
                    }, ResourceStatus.Created, log).Status;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public IResultItem LogDetail(IBdoLog item, IBdoLog log = null)
        {
            var result = BdoData.NewResultItem(item?.Id);

            if (item?.Detail != null)
            {
                result.Status = ExecuteScoped(
                    null,
                    (s, r) =>
                    {
                        _repository.UsingConnection((conn, l) =>
                        {
                            r = _repository?.UpdateLogDetail(item.Id, item.Detail, null, log);
                        }, false, log);
                    }, ResourceStatus.Created, log).Status;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public IResultItem Log(IBdoLogEvent item, IBdoLog log = null)
        {
            var result = BdoData.NewResultItem(item?.Id);

            result.Status = ExecuteScoped(
                null,
                (s, r) =>
                {
                    _repository.UsingConnection((conn, l) =>
                    {
                        r = _repository?.CreateEvent(item, null, log);
                    }, false, log);
                }, ResourceStatus.Created, log).Status;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public IResultItem LogDetail(IBdoLogEvent item, IBdoLog log = null)
        {
            var result = BdoData.NewResultItem(item?.Id);

            if (item?.Detail != null)
            {
                result.Status = ExecuteScoped(
                    null,
                    (s, r) =>
                    {
                        _repository.UsingConnection((conn, l) =>
                        {
                            r = _repository?.UpdateEventDetail(item.Parent?.Id, item.Detail, null, log);
                        }, false, log);
                    }, ResourceStatus.Created, log).Status;
            }

            return result;
        }
    }
}
