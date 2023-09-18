﻿using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Services;
using BindOpen.Kernel.Logging.Events;
using BindOpen.Kernel.Logging.Repositories;

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

        public IBdoCompleteLog NewRootLog(string id = null)
        {
            id ??= _rootLogId;

            var log = _repository?.GetLog(id).Result;
            if (log != null)
            {
                log = BdoData.New<BdoPersistentLog>().WithId(id).WithLogger(this);
                _repository?.CreateLog(log);
            }
            _rootLogId = log?.Id;

            return log;
        }

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
                        }, log, false);
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
                        }, log, false);
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
                        }, log, false);
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
                    }, log, false);
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
                        }, log, false);
                    }, ResourceStatus.Created, log).Status;
            }

            return result;
        }
    }
}
