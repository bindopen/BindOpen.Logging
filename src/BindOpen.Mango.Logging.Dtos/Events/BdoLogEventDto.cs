using BindOpen.Mango.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Mango.Logging
{
    /// <summary>
    /// This class represents a log event.
    /// </summary>
    [XmlType("LogEvent", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "logEvent", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class BdoLogEventDto : BdoEventDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        // ----------------------------------

        /// <summary>
        /// Result code of this instance.
        /// </summary>
        [JsonPropertyName("resultCode")]
        [XmlElement("resultCode")]
        [DefaultValue(null)]
        public string ResultCode { get; set; }

        /// <summary>
        /// Source of this instance.
        /// </summary>
        [JsonPropertyName("source")]
        [XmlElement("source")]
        public string Source { get; set; }

        /// <summary>
        /// Stack traces of this instance.
        /// </summary>
        [JsonPropertyName("stack.trace")]
        [XmlArray("stack.traces")]
        [XmlArrayItem("stack.trace")]
        public List<BdoLogEventStackTraceDto> StackTraces { get; set; }

        /// <summary>
        /// The log of this instance.
        /// </summary>
        [JsonPropertyName("log")]
        [XmlElement("log")]
        public BdoRuntimeLogDto Log { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoLogEventDto class.
        /// </summary>
        public BdoLogEventDto()
        {
        }

        #endregion
    }
}
