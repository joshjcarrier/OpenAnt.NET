namespace OpenAnt.Entity
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Types of entity.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Fields are self-explanatory.")]
    public enum EntityType
    {
        Ant,
        Food,
        TerrainSurface,
        TerrainObstacle,
    }
}