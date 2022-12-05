﻿using BindOpen.Framework.MetaData;
using BindOpen.Framework.MetaData.Elements;
using BindOpen.Framework.MetaData.Items;
using System;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents an event.
    /// </summary>
    public class BdoEvent : IdentifiedNamedDataItem, IBdoEvent
    {
        // ------------------------------------------
        // CONVERTERS
        // ------------------------------------------

        #region Converters

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="st">The string to consider.</param>
        public static implicit operator BdoEvent(string st)
        {
            return BdoLogging.CreateEvent(EventKinds.Message, st);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="ev">The event to consider.</param>
        public static implicit operator string(BdoEvent ev)
        {
            return ev?.DisplayName;
        }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoEvent class.
        /// </summary>
        public BdoEvent() : base(null, "event_")
        {
        }

        #endregion

        // ------------------------------------------
        // IBdoEvent implementation
        // ------------------------------------------

        #region IBdoEvent

        // General ----------------------------------

        /// <summary>
        /// The display name of this instance.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The description of this instance.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Kind of this instance.
        /// </summary>
        public EventKinds Kind { get; set; } = EventKinds.Other;

        /// <summary>
        /// Creation date of this instance.
        /// </summary>
        public DateTime? Date
        {
            get { return CreationDate; }
            set
            {
                CreationDate = value;
            }
        }

        /// <summary>
        /// Creation date of this instance.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Last modification date of this instance.
        /// </summary>
        public DateTime? LastModificationDate { get; set; }

        /// <summary>
        /// Long description of this instance.
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        /// Detail of this instance.
        /// </summary>
        public IDataElementSet Detail { get; set; }

        /// <summary>
        /// Criticality of this instance.
        /// </summary>
        public Criticalities Criticality { get; set; } = Criticalities.None;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IBdoEvent WithId(string id)
        {
            Id = id;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IBdoEvent WithName(string name)
        {
            Name = name;

            return this;
        }

        #endregion

        // ------------------------------------------
        // IDetailedDataItem implementation
        // ------------------------------------------

        #region IDetailedDataItem

        /// <summary>
        /// 
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public IBdoEvent WithDetail(IDataElementSet detail)
        {
            Detail = detail;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        public IBdoEvent WithDetail(params IDataElement[] elements)
        {
            return WithDetail(BdoElements.CreateSet(elements));
        }

        #endregion

        // ------------------------------------------
        // IStorable implementation
        // ------------------------------------------

        #region IStorable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IBdoEvent WithCreationDate(DateTime? date)
        {
            CreationDate = date;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IBdoEvent WithLastModificationDate(DateTime? date)
        {
            LastModificationDate = date;
            return this;
        }

        #endregion

        // ------------------------------------------
        // MUTATORS
        // ------------------------------------------

        #region Mutators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criticality"></param>
        /// <returns></returns>
        public IBdoEvent WithCriticality(Criticalities criticality)
        {
            Criticality = criticality;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IBdoEvent WithDate(DateTime? date)
        {
            Date = date;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public IBdoEvent WithKind(EventKinds kind)
        {
            Kind = kind;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="longDescription"></param>
        /// <returns></returns>
        public IBdoEvent WithLongDescription(string longDescription)
        {
            LongDescription = longDescription;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public IBdoEvent WithDisplayName(string displayName)
        {
            DisplayName = displayName;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public IBdoEvent WithDescription(string description)
        {
            Description = description;

            return this;
        }

        #endregion

        // ------------------------------------------
        // IDataItem interface
        // ------------------------------------------

        #region IDataItem

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns a cloned instance.</returns>
        public override object Clone(params string[] areas)
        {
            var cloned = base.Clone(areas) as BdoEvent;

            cloned.Detail = Detail?.Clone<DataElementSet>();

            return cloned;
        }

        #endregion
    }
}
