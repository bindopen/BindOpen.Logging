using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Mango.Logging
{
    /// <summary>
    /// This class represents a conditional event.
    /// </summary>
    [XmlType("ConditionalEvent", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "event", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class BdoConditionalEventDto : BdoEventDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Condition script of this instance.
        /// </summary>
        [JsonPropertyName("conditionScript")]
        [XmlElement("conditionScript")]
        public string ConditionScript { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoConditionalEventDto class.
        /// </summary>
        public BdoConditionalEventDto() : base()
        {
        }

        #endregion
    }
}
