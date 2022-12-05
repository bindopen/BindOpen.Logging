﻿using BindOpen.Framework.MetaData;
using BindOpen.Framework.MetaData.Items;
using System;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoEvent :
        ITIdentifiedPoco<IBdoEvent>, ITNamedPoco<IBdoEvent>,
        IDisplayNamed, IDescribed, IReferenced,
        ITStorablePoco<IBdoEvent>, ITDetailedPoco<IBdoEvent>,
        IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        Criticalities Criticality { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criticality"></param>
        /// <returns></returns>
        IBdoEvent WithCriticality(Criticalities criticality);

        /// <summary>
        /// 
        /// </summary>
        DateTime? Date { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        IBdoEvent WithDate(DateTime? date);

        /// <summary>
        /// 
        /// </summary>
        EventKinds Kind { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        IBdoEvent WithKind(EventKinds kind);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IBdoEvent WithDisplayName(string displayName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        IBdoEvent WithDescription(string description);

        /// <summary>
        /// 
        /// </summary>
        string LongDescription { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        IBdoEvent WithLongDescription(string longDescription);
    }
}