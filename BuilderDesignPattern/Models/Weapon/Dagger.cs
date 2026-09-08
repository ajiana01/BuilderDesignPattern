using BuilderDesignPattern.Interface;

namespace BuilderDesignPattern.Models.Weapon;

/// <summary>
/// Represents a basic lightweight dagger weapon, typically equipped by grunts or stealth units.
/// </summary>
public class Dagger : IWeapon
{
    public string Name => "Rusty Dagger";
    public int DamageBase => 4; // 1d4 damage
}