namespace OpenAnt
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The direction an entity is facing.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Field names are self-explanatory.")] 
    public enum Orientation
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
}