using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Conditions;
using BindOpen.Kernel.Data.Meta;
using BindOpen.Kernel.Scoping;

namespace BindOpen.Kernel.Logging.Events
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

        /// <summary>
        /// The item requirement level of this instance.
        /// </summary>
        public bool GetConditionValue(
            IBdoScope scope = null,
            IBdoMetaSet varSet = null,
            IBdoLog log = null)
        {
            if (Condition != null)
            {
                var localVarSet = BdoData.NewSet(varSet?.ToArray());
                localVarSet.Add(BdoData.__VarName_This, this);

                var b = scope?.Interpreter?.Evaluate(Condition, localVarSet, log) == true;

                return b;
            }

            return true;
        }

        #endregion
    }
}
