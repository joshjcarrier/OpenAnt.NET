namespace OpenAnt.World
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The available actions to request when manipulating the world.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "The field names are self-explanatory.")]
    public enum ActionType
    {
        PrecisionMove,
        Move,
        Interact
    }
}