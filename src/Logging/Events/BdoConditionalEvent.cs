using BindOpen.System.Data.Conditions;

namespace BindOpen.System.Logging
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
        public IBdoCondition Condition { get; set; }

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
    }
}
