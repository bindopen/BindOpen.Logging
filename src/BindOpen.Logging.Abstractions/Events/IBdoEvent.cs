using BindOpen.Scoping.Data;
using System;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoEvent :
        IIdentified, INamed,
        IDisplayNamed, IDescribed, IReferenced,
        IStorable, IBdoDetailed,
        IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        Criticalities Criticality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime? Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        EventKinds Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string LongDescription { get; set; }
    }
}