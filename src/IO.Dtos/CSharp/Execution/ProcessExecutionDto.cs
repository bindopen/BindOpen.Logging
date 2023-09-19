using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Conditions;
using BindOpen.Kernel.Data.Meta;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// This class represents a job.
    /// </summary>
    public class ProcessExecutionDto : IBdoDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        [JsonPropertyName("custom.status")]
        [XmlElement("custom.status")]
        public string CustomStatus { get; set; }

        [JsonPropertyName("end.date")]
        [XmlElement("end.date")]
        public string EndDate { get; set; }

        [JsonPropertyName("location")]
        [XmlElement("location")]
        public string Location { get; set; }

        [JsonPropertyName("progressIndex")]
        [XmlElement("progressIndex")]
        public float ProgressIndex { get; set; }

        [JsonPropertyName("progressMax")]
        [XmlElement("progressMax")]
        public float ProgressMax { get; set; }

        [JsonPropertyName("restartDate")]
        [XmlElement("restartDate")]
        public string RestartDate { get; set; }

        [JsonPropertyName("resultLevel")]
        [XmlElement("resultLevel")]
        public int ResultLevel { get; set; }

        [JsonPropertyName("startDate")]
        [XmlElement("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("date")]
        [XmlElement("date")]
        public ProcessExecutionState State { get; set; }

        [JsonPropertyName("status")]
        [XmlElement("status")]
        public ProcessExecutionStatus Status { get; set; }

        [JsonPropertyName("id")]
        [XmlAttribute("id")]
        public string Id { get; set; }

        [JsonPropertyName("conditiion")]
        [XmlElement("conditiion")]
        public ConditionDto Condition { get; set; }

        [JsonPropertyName("detail")]
        [XmlElement("detail")]
        public MetaSetDto Detail { get; set; }

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
