using BindOpen.Kernel.Data;
using System.Collections.Generic;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class LogsRequestForm : ILogsRequestForm
    {
        public string Motcle { get; set; }

        public QueryResultModes ResultMode { get; set; }

        public ProcessExecutionState State { get; set; }

        public ProcessExecutionStatus Status { get; set; }

        public int? MaxCount { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public List<string> ColumnNames { get; set; }
        public string Query { get; set; }
        public string OrderBy { get; set; }
        public ExportFormats ExportFormat { get; set; }
        public string FileName { get; set; }
        public string DocumentDisplayName { get; set; }
        public string Culture { get; set; }
    }
}