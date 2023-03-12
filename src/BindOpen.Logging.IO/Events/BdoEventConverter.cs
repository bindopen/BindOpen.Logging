using BindOpen.Data;
using BindOpen.Data.Helpers;
using BindOpen.Data.Meta;

namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class BdoEventConverter
    {
        // Serialization ----------------------------

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static BdoEventDto ToDto(this IBdoEvent poco)
        {
            if (poco == null) return null;

            BdoEventDto dto = new()
            {
                Criticality = poco.Criticality,
                Date = poco.Date.ToString(),
                Description = poco.Description,
                Detail = poco.Detail.ToDto(),
                DisplayName = poco.DisplayName,
                Kind = poco.Kind,
                LongDescription = poco.LongDescription
            };

            return dto;
        }

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param name="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static IBdoEvent ToPoco(this BdoEventDto dto)
        {
            if (dto == null) return null;

            BdoEvent poco = new()
            {
                Criticality = dto.Criticality,
                Date = dto.Date.ToDateTime(),
                Description = dto.Description,
                Detail = dto.Detail.ToPoco(),
                DisplayName = dto.DisplayName,
                Kind = dto.Kind,
                LongDescription = dto.LongDescription
            };

            return poco;
        }
    }
}
