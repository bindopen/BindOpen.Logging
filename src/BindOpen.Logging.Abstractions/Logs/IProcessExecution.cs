using BindOpen.Framework.MetaData.Elements;
using BindOpen.Framework.MetaData.Items;

namespace BindOpen.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProcessExecution : IDataItem
    {
        /// <summary>
        /// 
        /// </summary>
        string CustomStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IDataElementSet Detail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Duration { get; }

        /// <summary>
        /// 
        /// </summary>
        string EndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        float ProgressIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        float ProgressMax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string RestartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int ResultLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ProcessExecutionState State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ProcessExecutionStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void AddDetail(string name, object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        void End(ProcessExecutionStatus status = ProcessExecutionStatus.Completed);

        /// <summary>
        /// 
        /// </summary>
        void Restart();

        /// <summary>
        /// 
        /// </summary>
        void Resume();

        /// <summary>
        /// 
        /// </summary>
        void Start();
    }
}