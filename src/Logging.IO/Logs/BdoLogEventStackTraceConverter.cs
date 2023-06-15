﻿namespace BindOpen.System.Logging
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class BdoLogEventStackTraceConverter
    {
        // Serialization ----------------------------

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static BdoLogEventStackTraceDto ToDto(this IBdoLogEventStackTrace poco)
        {
            if (poco == null) return null;

            BdoLogEventStackTraceDto dto = new()
            {
                FilePath = poco.FilePath,
                FullClassName = poco.FullClassName,
                LineNumber = poco.LineNumber,
                MethodName = poco.MethodName,
                MethodParams = poco.MethodParams
            };

            return dto;
        }

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param name="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static IBdoLogEventStackTrace ToPoco(this BdoLogEventStackTraceDto dto)
        {
            if (dto == null) return null;

            BdoLogEventStackTrace poco = new()
            {
                FilePath = dto.FilePath,
                FullClassName = dto.FullClassName,
                LineNumber = dto.LineNumber,
                MethodName = dto.MethodName,
                MethodParams = dto.MethodParams
            };

            return poco;
        }
    }
}