using BindOpen.Kernel.Data.Meta;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Kernel.Logging.Events
{
    /// <summary>
    /// This class represents an event.
    /// </summary>
    [XmlType("Event", Namespace = "https://storage.bindopen.org/xsd/bindopen/kernel")]
    [XmlRoot(ElementName = "event", Namespace = "https://storage.bindopen.org/xsd/bindopen/kernel", IsNullable = false)]
    [XmlInclude(typeof(ConditionalEventDto))]
    public class EventDto : IBdoDto
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
        [DefaultValue(EventKinds.Any)]
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
        public EventDto()
        {
        }

        #endregion
    }
}
