using BindOpen.Kernel.Data;
using BindOpen.Kernel.Logging.Loggers;

namespace BindOpen.Kernel.Logging
{
    /// <summary>
    /// This class represents a log extension.
    /// </summary>
    public static class BdoLogExtension
    {
        /// <summary>
        /// Converts the specified log to string.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <returns>The string corresponding to the specified log using the specified formater.</returns>
        public static string ToString<T>(this IBdoCompleteLog log)
            where T : IBdoLoggerFormater, new()
        {
            var formater = new T();
            return formater.Format(log);
        }
        /// <summary>
        /// 
        /// </summary>
        public static T WithChildren<T>(
            this T log,
            params IBdoLog[] children)
            where T : IBdoLog
        {
            if (log != null)
            {
                log._Children = BdoData.NewItemSet(children);
            }

            return log;
        }

        public static T AddChildren<T>(this T log, params IBdoLog[] children) where T : IBdoLog
        {
            if (log != null)
            {
                log._Children ??= BdoData.NewItemSet<IBdoLog>();
                foreach (var child in children)
                {
                    log._Children.Add(child);
                }
            }

            return log;
        }

        // Execution

        public static void WithExecutionAsStarted(this IBdoCompleteLog log)
        {
            if (log == null) return;

            log.Execution ??= BdoLogging.NewExecution();

            log.Execution.SetAsStarted();

            log.WithExecution(log.Execution);
        }

        /// <summary>
        /// Restarts this instance.
        /// </summary>
        public static void WithExecutionAsRestarted(this IBdoCompleteLog log)
        {
            if (log == null) return;

            log.Execution ??= BdoLogging.NewExecution();

            log.Execution.SetAsRestarted();

            log.WithExecution(log.Execution);
        }

        /// <summary>
        /// Resumes this instance.
        /// </summary>
        public static void WithExecutionAsResumed(this IBdoCompleteLog log)
        {
            if (log == null) return;

            log.Execution ??= BdoLogging.NewExecution();

            log.Execution.SetAsResumed();

            log.WithExecution(log.Execution);
        }

        /// <summary>
        /// Resumes this instance.
        /// </summary>
        public static void WithExecutionAsPaused(this IBdoCompleteLog log)
        {
            if (log == null) return;

            log.Execution ??= BdoLogging.NewExecution();

            log.Execution.SetAsPaused();

            log.WithExecution(log.Execution);
        }

        public static void WithExecutionAsEnded(
            this IBdoCompleteLog log,
            ProcessExecutionStatus status = ProcessExecutionStatus.Completed,
            float? progressIndex = null)
        {
            if (log == null) return;

            log.Execution ??= BdoLogging.NewExecution();

            log.Execution.SetAsEnded(status);

            if (progressIndex != null) log?.Execution.WithProgressIndex(progressIndex.Value);

            log.WithExecution(log.Execution);
        }
    }
}
