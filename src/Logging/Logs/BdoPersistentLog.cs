using BindOpen.Kernel.Logging.Loggers;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// This class represents a logger of tasks.
    /// </summary>
    public class BdoPersistentLog : BdoLog, IBdoPersistentLog
    {
        public new IBdoPersistentLogger Logger { get; set; }

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoPersistentLog class.
        /// </summary>
        public BdoPersistentLog() : base()
        {
        }

        #endregion
    }
}