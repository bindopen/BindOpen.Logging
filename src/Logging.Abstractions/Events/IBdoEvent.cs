using BindOpen.System.Data;
using System;

namespace BindOpen.System.Logging
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