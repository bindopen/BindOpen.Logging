using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoPersistenceLogger : IBdoLogger, IBdoConnected
    {
        IBdoDynamicLog NewRootLog(string id = null);
    }
}