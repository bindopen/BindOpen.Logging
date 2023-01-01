namespace BindOpen.Mango.Logging
{
    /// <summary>
    /// This class represents a Xml helper.
    /// </summary>
    public static class BdoConditionalEventConverter
    {
        // Serialization ----------------------------

        /// <summary>
        /// Converts to DTO.
        /// </summary>
        /// <param name="poco">The poco to consider.</param>
        /// <returns>The DTO object.</returns>
        public static BdoConditionalEventDto ToDto(this IBdoConditionalEvent poco)
        {
            if (poco == null) return null;

            BdoConditionalEventDto dto = new()
            {
            };

            return dto;
        }

        /// <summary>
        /// Converts to POCO.
        /// </summary>
        /// <param name="dto">The dto to consider.</param>
        /// <returns>The POCO object.</returns>
        public static IBdoConditionalEvent ToPoco(this BdoConditionalEventDto dto)
        {
            if (dto == null) return null;

            BdoConditionalEvent poco = new()
            {
            };

            return poco;
        }
    }
}
