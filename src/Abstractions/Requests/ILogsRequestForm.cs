using BindOpen.Kernel.Data;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogsRequestForm : IDataPageRequest, ISearchRequest, IExportRequest
    {
        /// <summary>
        /// Le mot clé.
        /// </summary>
        string Motcle { get; set; }

        /// <summary>
        /// Le type de résultat de requête.
        /// </summary>
        QueryResultModes ResultMode { get; set; }

        ProcessExecutionState State { get; set; }

        ProcessExecutionStatus Status { get; set; }
    }
}