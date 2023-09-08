using System;

namespace BindOpen.Kernel.Logging.Events
{
    /// <summary>
    /// 
    /// </summary>
    public static class IBdoEventExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criticality"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
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