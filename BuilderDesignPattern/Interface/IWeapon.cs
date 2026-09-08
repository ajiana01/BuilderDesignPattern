namespace BuilderDesignPattern.Interface;

/// <summary>
/// Represents a weapon component that can be equipped by a <see cref="Models.Character.Character"/>.
/// Demonstrates composition where complex objects can have interchangeable sub-components.
/// </summary>
public interface IWeapon
{
    /// <summary>
    /// Gets the display name of the weapon.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the base attack damage of the weapon.
    /// </summary>
    int DamageBase { get; }
}