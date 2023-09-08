using BindOpen.Kernel.Data.Conditions;

namespace BindOpen.Kernel.Logging
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
