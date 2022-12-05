using BindOpen.Framework.MetaData;
using BindOpen.Framework.MetaData.Elements;
using System.Linq;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class BdoLogEventConverter
    {
        // Serialization ----------------------------

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static BdoLogEventDto ToDto(this IBdoLogEvent poco)
        {
            if (poco == null) return null;

            BdoLogEventDto dto = new()
            {
                Criticality = poco.Criticality,
                Date = poco.Date?.ToString(),
                Description = poco.Description,
                Detail = poco.Detail.ToDto(),
                DisplayName = poco.DisplayName,
                Kind = poco.Kind,
                Log = poco.Log.ToDto(),
                LongDescription = poco.LongDescription,
                ResultCode = poco.ResultCode,
                Source = poco.Source,
                StackTraces = poco.StackTraces?.Select(q => q.ToDto()).ToList()
            };

            return dto;
        }

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param name="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static IBdoLogEvent ToPoco(this BdoLogEventDto dto)
        {
            if (dto == null) return null;

            BdoLogEvent poco = new()
            {
                Criticality = dto.Criticality,
                Date = dto.Date.ToDateTime(),
                Description = dto.Description,
                Detail = dto.Detail.ToPoco(),
                DisplayName = dto.DisplayName,
                Kind = dto.Kind,
                LongDescription = dto.LongDescription
            };
            poco
                .WithLog(dto.Log.ToPoco())
                .WithResultCode(dto.ResultCode)
                .WithSource(dto.Source)
                .WithStackTraces(dto.StackTraces?.Select(q => q.ToPoco()).ToArray());

            return poco;
        }
    }
}
