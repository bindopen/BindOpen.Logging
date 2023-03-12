using BindOpen.Data;
using BindOpen.Data.Meta;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents the process execution.
    /// </summary>
    [XmlType("ProcessExecution", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "processExecution", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class ProcessExecutionDto : IDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// The detail DTO of this instance.
        /// </summary>
        [JsonPropertyName("detail")]
        [XmlElement("detail")]
        [DefaultValue(null)]
        public MetaSetDto Detail { get; set; }

        // Location -------------------------------------

        /// <summary>
        /// Location of this instance.
        /// </summary>
        [JsonPropertyName("location")]
        [XmlElement("location")]
        [DefaultValue("")]
        public string Location { get; set; }

        // Progression -------------------------------------

        /// <summary>
        /// Progression index of this instance. By default it is set to 0.
        /// </summary>
        /// <seealso cref="ProgressMax"/>
        [JsonPropertyName("progressIndex")]
        [XmlElement("progressIndex")]
        [DefaultValue(0)]
        public float ProgressIndex { get; set; } = 0;

        /// <summary>
        /// Maximum progression of this instance. By default, it is set to 100.
        /// </summary>
        /// <seealso cref="ProgressIndex"/>
        [JsonPropertyName("progressMax")]
        [XmlElement("progressMax")]
        [DefaultValue(100)]
        public float ProgressMax { get; set; } = 100;

        // States -------------------------------------

        /// <summary>
        /// Status of this instance.
        /// </summary>
        [JsonPropertyName("status")]
        [XmlElement("status")]
        [DefaultValue(ProcessExecutionStatus.None)]
        public ProcessExecutionStatus Status { get; set; } = ProcessExecutionStatus.None;

        /// <summary>
        /// State of this instance.
        /// </summary>
        [JsonPropertyName("state")]
        [XmlElement("state")]
        [DefaultValue(ProcessExecutionState.None)]
        public ProcessExecutionState State { get; set; } = ProcessExecutionState.None;

        /// <summary>
        /// Custom status of this instance.
        /// </summary>
        [JsonPropertyName("customStatus")]
        [XmlElement("customStatus")]
        [DefaultValue(null)]
        public string CustomStatus { get; set; }

        // Time -------------------------------------

        /// <summary>
        /// Start date of this instance.
        /// </summary>
        [JsonPropertyName("startDate")]
        [XmlElement("startDate")]
        [DefaultValue(null)]
        public string StartDate { get; set; }

        /// <summary>
        /// Re-start date of this instance.
        /// </summary>
        [JsonPropertyName("restartDate")]
        [XmlElement("restartDate")]
        [DefaultValue(null)]
        public string RestartDate { get; set; }

        /// <summary>
        /// End date of this instance.
        /// </summary>
        [JsonPropertyName("endDate")]
        [XmlElement("endDate")]
        [DefaultValue(null)]
        public string EndDate { get; set; }

        /// <summary>
        /// End date of this instance.
        /// </summary>
        [JsonPropertyName("duration")]
        [XmlElement("duration")]
        [DefaultValue(null)]
        public string Duration { get; set; }

        // Result -------------------------------------

        /// <summary>
        /// Result level of this instance. Over a certain value the result can be considered 
        /// as satisfying.
        /// </summary>
        [JsonPropertyName("resultLevel")]
        [XmlElement("resultLevel")]
        [DefaultValue(0)]
        public int ResultLevel { get; set; } = 0;

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the ProcessExecutionDto class.
        /// </summary>
        public ProcessExecutionDto()
        {
        }

        #endregion
    }
}