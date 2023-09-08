using BindOpen.Kernel.Data;
using System;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoEvent :
        IIdentified, INamed,
        IDisplayNamed, IDescribed, IReferenced,
        IDated, IBdoDetailed,
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