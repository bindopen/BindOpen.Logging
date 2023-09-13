using BindOpen.Kernel.Data;
using System;

namespace BindOpen.Kernel.Logging.Events
{
    /// <summary>
    /// This static class provides extensions to BdoEvent class.
    /// </summary>
    public static class IBdoEventExtensions
    {
        /// <summary>
        /// Updates the criticality of the specified object.
        /// </summary>
        /// <param name="ev">The event to consider.</param>
        /// <param name="criticality">The criticality to consider.</param>
        /// <returns>Returns the specified object.</returns>
        public static T WithCriticality<T>(
            this T ev,
            Criticalities criticality)
            where T : IBdoEvent
        {
            if (ev != null)
            {
                ev.Criticality = criticality;
            }

            return ev;
        }

        /// <summary>
        /// Updates the date of the specified object.
        /// </summary>
        /// <param name="ev">The event to consider.</param>
        /// <param name="date">The date to consider.</param>
        /// <returns>Returns the specified object.</returns>
        public static T WithDate<T>(
            this T ev,
            DateTime? date)
            where T : IBdoEvent
        {
            if (ev != null)
            {
                ev.Date = date;
            }

            return ev;
        }

        /// <summary>
        /// Updates the kind of the specified object.
        /// </summary>
        /// <param name="ev">The event to consider.</param>
        /// <param name="kind">The kind to consider.</param>
        /// <returns>Returns the specified object.</returns>
        public static T WithKind<T>(
            this T ev,
            EventKinds kind)
            where T : IBdoEvent
        {
            if (ev != null)
            {
                ev.Kind = kind;
            }

            return ev;
        }

        /// <summary>
        /// Updates the long description of the specified object.
        /// </summary>
        /// <param name="ev">The event to consider.</param>
        /// <param name="longDescription">The long description to consider.</param>
        /// <returns>Returns the specified object.</returns>
        public static T WithLongDescription<T>(
            this T ev,
            string longDescription)
            where T : IBdoEvent
        {
            if (ev != null)
            {
                ev.LongDescription = longDescription;
            }

            return ev;
        }
    }
}