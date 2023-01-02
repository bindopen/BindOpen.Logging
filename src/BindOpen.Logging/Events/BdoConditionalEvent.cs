namespace BindOpen.Logging
{
    /// <summary>
    /// This class represents a conditional event.
    /// </summary>
    public class BdoConditionalEvent : BdoEvent, IBdoConditionalEvent
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Condition script of this instance.
        /// </summary>
        public string ConditionScript { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoConditionalEvent class.
        /// </summary>
        public BdoConditionalEvent()
        {
        }

        #endregion

        // ------------------------------------------
        // MUTATORS
        // ------------------------------------------

        #region Mutators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditionScript"></param>
        /// <returns></returns>
        public IBdoConditionalEvent WithCondition(string conditionScript)
        {
            ConditionScript = conditionScript;

            return this;
        }

        #endregion
    }
}
