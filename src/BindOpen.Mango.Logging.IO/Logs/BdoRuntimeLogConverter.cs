using BindOpen.Mango.Extensions.Processing;
using BindOpen.Mango.MetaData.Elements;
using System.Linq;

namespace BindOpen.Mango.Logging
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class BdoRuntimeLogConverter
    {
        // Serialization ----------------------------

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static BdoRuntimeLogDto ToDto(this IBdoRuntimeLog poco)
        {
            if (poco == null) return null;

            BdoRuntimeLogDto dto = new()
            {
                Description = poco.Description,
                Detail = poco.Detail.ToDto(),
                DisplayName = poco.DisplayName,
                Events = poco.Events?.Select(q => q.ToDto()).ToList(),
                Execution = poco.Execution.ToDto(),
                Task = poco.Task.ToDto()
            };

            return dto;
        }

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param name="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static IBdoRuntimeLog ToPoco(this BdoRuntimeLogDto dto)
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
