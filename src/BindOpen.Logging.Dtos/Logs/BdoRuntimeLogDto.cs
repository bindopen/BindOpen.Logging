using BindOpen.Data;
using BindOpen.Data.Configuration;
using BindOpen.Data.Meta;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a logger of tasks.
    /// </summary>
    [XmlType("Log", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "log", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class BdoRuntimeLogDto : IDto
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

        // Execution ----------------------------------

        /// <summary>
        /// The execution of this instance.
        /// </summary>
        [JsonPropertyName("execution")]
        [XmlElement("execution")]
        public ProcessExecutionDto Execution { get; set; }

        // Task ----------------------------------

        /// <summary>
        /// The task of this instance.
        /// </summary>
        [JsonPropertyName("task")]
        [XmlElement("task")]
        public BdoConfigurationDto Task { get; set; }

        // Detail ----------------------------------

        /// <summary>
        /// Detail of this instance.
        /// </summary>
        [JsonPropertyName("detail")]
        [XmlElement("detail")]
        public MetaListDto Detail { get; set; }

        // Events ----------------------------------

        /// <summary>
        /// Events of this instance.
        /// </summary>
        /// <seealso cref="Errors"/>
        /// <seealso cref="Warnings"/>
        /// <seealso cref="Messages"/>
        /// <seealso cref="Exceptions"/>
        /// <seealso cref="Checkpoints"/>
        /// <seealso cref="SubLogs"/>
        [JsonPropertyName("events")]
        [XmlArray("events")]
        [XmlArrayItem("event")]
        public List<BdoLogEventDto> Events { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoRuntimeLogDto class.
        /// </summary>
        public BdoRuntimeLogDto()
        {
        }

        #endregion
    }
}