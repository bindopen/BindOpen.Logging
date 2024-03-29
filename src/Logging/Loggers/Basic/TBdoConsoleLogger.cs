﻿using BindOpen.Data;
using BindOpen.Logging.Events;
using System;

namespace BindOpen.Logging.Loggers
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public class TBdoConsoleLogger<T> : TBdoLogger<T>
        where T : IBdoLoggerFormater, new()
    {
        /// <summary>
        /// Initializes a new instance of the BdoLogger class.
        /// </summary>
        public TBdoConsoleLogger() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem Log(IBdoLog item, IBdoLog log = null)
        {
            if (item != null)
            {
                var st = _formater?.Format(item);
                Console.Write(st);
                return BdoData.NewResultItem(ResourceStatus.Created);
            }

            return BdoData.NewResultItem(ResourceStatus.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem LogExecution(IBdoLog item, IBdoLog log = null)
        {
            if (item?.Execution != null)
            {
                var st = _formater?.FormatExecution(item);
                Console.Write(st);
                return BdoData.NewResultItem(ResourceStatus.Created);
            }

            return BdoData.NewResultItem(ResourceStatus.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem LogDetail(IBdoLog item, IBdoLog log = null)
        {
            if (item?.Detail != null)
            {
                var st = _formater?.FormatDetail(item);
                Console.Write(st);
                return BdoData.NewResultItem(ResourceStatus.Created);
            }

            return BdoData.NewResultItem(ResourceStatus.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem Log(IBdoLogEvent item, IBdoLog log = null)
        {
            if (item != null)
            {
                var st = _formater?.Format(item);
                Console.Write(st);
                return BdoData.NewResultItem(ResourceStatus.Created);
            }

            return BdoData.NewResultItem(ResourceStatus.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ev"></typeparam>
        public override IResultItem LogDetail(IBdoLogEvent item, IBdoLog log = null)
        {
            if (item?.Detail != null)
            {
                var st = _formater?.FormatDetail(item);
                Console.Write(st);
                return BdoData.NewResultItem(ResourceStatus.Created);
            }

            return BdoData.NewResultItem(ResourceStatus.None);
        }
    }
}
