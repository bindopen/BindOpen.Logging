using BindOpen.Scoping.Data;
using BindOpen.Scoping.Data.Meta;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents an event.
    /// </summary>
    [XmlType("Event", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "event", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    [XmlInclude(typeof(BdoConditionalEventDto))]
    public class BdoEventDto : IDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        // General ----------------------------------

        /// <summary>
        /// The display name of this instance.
        /// </summary>
        [JsonPropertyName("displayName")]
        [XmlElement("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The description of this instance.
        /// </summary>
        [JsonPropertyName("description")]
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Kind of this instance.
        /// </summary>
        [JsonPropertyName("kind")]
        [XmlAttribute("kind")]
        [DefaultValue(EventKinds.None)]
        public EventKinds Kind { get; set; } = EventKinds.Other;

        /// <summary>
        /// Creation date of this instance.
        /// </summary>
        [JsonPropertyName("date")]
        [XmlAttribute("date")]
        [DefaultValue("")]
        public string Date { get; set; }

        /// <summary>
        /// Long description of this instance.
        /// </summary>
        [JsonPropertyName("longDescription")]
        [XmlElement("longDescription")]
        public string LongDescription { get; set; }

        /// <summary>
        /// Detail of this instance.
        /// </summary>
        [JsonPropertyName("detail")]
        [XmlElement("detail")]
        public MetaSetDto Detail { get; set; }

        /// <summary>
        /// Criticality of this instance.
        /// </summary>
        [JsonPropertyName("criticality")]
        [XmlElement("criticality")]
        [DefaultValue(Criticalities.None)]
        public Criticalities Criticality { get; set; } = Criticalities.None;

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoEventDto class.
        /// </summary>
        public BdoEventDto()
        {
        }

        #endregion
    }
}
