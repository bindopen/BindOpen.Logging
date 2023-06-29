using BindOpen.System.Data;

namespace BindOpen.System.Logging.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogsRequestDto : IDataPageRequestDto
    {
        /// <summary>
        /// The result mode.
        /// </summary>
        QueryResultModes ResultMode { get; set; }

        /// <summary>
        /// The parent identifier.
        /// </summary>
        string ParentId { get; set; }

        /// <summary>
        /// The search word.
        /// </summary>
        string Searchword { get; set; }
    }
}
