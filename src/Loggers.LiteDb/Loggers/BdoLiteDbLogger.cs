using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Kernel.Logging.Loggers.LiteDb
{
    /// <summary>
    /// This class represents a logger.
    /// </summary>
    public partial class BdoLiteDbLogger : BdoPersistenceLogger
    {

        public BdoLiteDbLogger() : base()
        {
        }

        public BdoLiteDbLogger(IBdoConnector connector) : base(connector)
        {
            Connector = connector;
        }
    }
}
