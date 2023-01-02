namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBdoConditionalEvent : IBdoEvent
    {
        /// <summary>
        /// 
        /// </summary>
        string ConditionScript { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditionScript"></param>
        /// <returns></returns>
        IBdoConditionalEvent WithCondition(string conditionScript);
    }
}