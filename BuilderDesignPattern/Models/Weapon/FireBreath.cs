using BuilderDesignPattern.Interface;

namespace BuilderDesignPattern.Models.Weapon;

/// <summary>
/// Represents an area-of-effect (AoE) breath attack weapon, typically equipped by boss monsters.
/// </summary>
public class FireBreath : IWeapon
{
    public string Name => "Fire Breath";
    public int DamageBase => 20; // High-damage AoE
}