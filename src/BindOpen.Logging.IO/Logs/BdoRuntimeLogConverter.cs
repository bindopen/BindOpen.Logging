using BindOpen.Scoping.Data;
using BindOpen.Scoping.Data.Meta;
using System.Linq;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class BdoLogConverter
    {
        // Serialization ----------------------------

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static BdoLogDto ToDto(this IBdoDynamicLog poco)
        {
            if (poco == null) return null;

            BdoLogDto dto = new()
            {
                Description = poco.Description,
                Detail = poco.Detail.ToDto(),
                DisplayName = poco.DisplayName,
                Events = poco._Events?.Select(q => q.ToDto()).ToList(),
                Execution = poco.Execution.ToDto(),
                Task = poco.TaskConfig.ToDto()
            };

            return dto;
        }

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param name="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static IBdoDynamicLog ToPoco(this BdoLogDto dto)
        {
            if (dto == null) return null;

            BdoLog poco = new();
            poco
                .WithEvents(dto.Events?.Select(q => q.ToPoco()).ToArray())
                .WithExecution(dto.Execution.ToPoco())
                .WithTask(dto.Task.ToPoco())
                .WithDescription(dto.Description)
                .WithDetail(dto.Detail.ToPoco())
                .WithDisplayName(dto.DisplayName);

            return poco;
        }
    }
}
