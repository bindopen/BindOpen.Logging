using BindOpen.Data;

namespace BindOpen.Logging.Events
{
    /// <summary>
    /// This interface represents a conditional event.
    /// </summary>
    public interface IBdoConditionalEvent : IBdoEvent, IBdoConditional
    {
    }
}