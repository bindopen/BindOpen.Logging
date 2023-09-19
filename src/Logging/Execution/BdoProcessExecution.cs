﻿using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Conditions;
using BindOpen.Kernel.Data.Meta;
using BindOpen.Kernel.Processing;
using System;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// This class represents a job.
    /// </summary>
    public class BdoProcessExecution : BdoObject, IBdoProcessExecution
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        public string CustomStatus { get; set; }

        public TimeSpan? Duration => StartDate == null ? null : (EndDate == null ? DateTime.Now : EndDate.Value).Subtract(StartDate.Value);

        public DateTime? EndDate { get; set; }
        public string Location { get; set; }
        public float ProgressIndex { get; set; }
        public float ProgressMax { get; set; }
        public DateTime? RestartDate { get; set; }
        public int ResultLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public ProcessExecutionState State { get; set; }
        public ProcessExecutionStatus Status { get; set; }
        public string Id { get; set; }
        public IBdoCondition Condition { get; set; }
        public IBdoMetaSet Detail { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoProcessExecution class.
        /// </summary>
        public BdoProcessExecution()
        {
        }

        #endregion

        public string Key() => Id;
    }
}