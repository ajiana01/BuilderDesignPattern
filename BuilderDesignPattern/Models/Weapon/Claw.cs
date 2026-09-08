using BuilderDesignPattern.Interface;

namespace BuilderDesignPattern.Models.Weapon;

/// <summary>
/// Represents a natural claw weapon, typically equipped by beasts or dragon bosses.
/// </summary>
public class Claw : IWeapon
{
    public string Name => "Dragon Claw";
    public int DamageBase => 8; // 1d8 damage
}