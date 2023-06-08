using BindOpen.Bpm;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class ProcessExecutionConverter
    {
        // Serialization ----------------------------

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static ProcessExecutionDto ToDto(this IBdoProcessExecution poco)
        {
            if (poco == null) return null;

            ProcessExecutionDto dto = new()
            {
            };

            return dto;
        }

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param name="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static IBdoProcessExecution ToPoco(this ProcessExecutionDto dto)
        {
            if (dto == null) return null;

            ProcessExecution poco = new()
            {
            };

            return poco;
        }
    }
}
