using BindOpen.Kernel.Data;

namespace BindOpen.Kernel.Logging.Events
{
    /// <summary>
    /// This interface represents a conditional event.
    /// </summary>
    public interface IBdoConditionalEvent : IBdoEvent, IBdoConditional
    {
    }
}