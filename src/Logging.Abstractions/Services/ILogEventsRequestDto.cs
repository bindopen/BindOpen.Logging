using BindOpen.System.Data;

namespace BindOpen.System.Logging.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogEventsRequestDto : IDataPageRequestDto
    {
        /// <summary>
        /// The result mode.
        /// </summary>
        QueryResultModes ResultMode { get; set; }

        /// <summary>
        /// The search word.
        /// </summary>
        string LogId { get; set; }

        /// <summary>
        /// The search word.
        /// </summary>
        string Searchword { get; set; }
    }
}
