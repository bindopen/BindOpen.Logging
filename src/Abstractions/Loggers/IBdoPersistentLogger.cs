using BindOpen.Kernel.Data.Services;
using BindOpen.Kernel.Logging.Repositories;

namespace BindOpen.Kernel.Logging.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBdoPersistentLogger : IBdoLogger, IBdoDataService
    {
        IBdoLoggingRepository Repository { get; }
    }
}