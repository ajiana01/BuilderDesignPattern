using BuilderDesignPattern.Interface;
using BuilderDesignPattern.Models.Character;

namespace BuilderDesignPattern.Builders;

/// <summary>
/// Implements the <b>Builder Design Pattern</b> to assemble <see cref="Character"/> instances step-by-step.
/// <para>
/// <b>Benefits of this pattern:</b>
/// <list type="bullet">
///   <item><description><b>Readability:</b> Replaces confusing telescoping constructors with self-documenting method calls.</description></item>
///   <item><description><b>Flexibility:</b> Optional components (e.g. secondary weapons, boss flag) can be omitted without passing <c>null</c> or <c>false</c>.</description></item>
///   <item><description><b>Sensible Defaults:</b> Sensible fallback values are provided for fields that are not explicitly specified.</description></item>
///   <item><description><b>Centralized Validation:</b> Business rules and integrity checks are enforced in <see cref="Build"/> prior to instantiating the immutable product.</description></item>
///   <item><description><b>Fluent Interface:</b> Methods return <c>this</c> to enable seamless method chaining.</description></item>
/// </list>
/// </para>
/// </summary>
public class CharacterBuilder
{
    // Sensible default values
    private string _name = "Unknown Entity";
    private int _health = 10;
    private int _armorClass = 10;
    private int _initiativeBase = 0;
    private IWeapon? _mainWeapon;
    private IWeapon? _secondaryWeapon;
    private bool _isBoss = false;

    /// <summary>
    /// Sets the character's name.
    /// </summary>
    /// <param name="name">The name to assign to the character.</param>
    /// <returns>The builder instance for fluent chaining.</returns>
    public CharacterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    /// <summary>
    /// Sets the character's base hit points.
    /// </summary>
    /// <param name="hp">Base health value (must be > 0).</param>
    /// <returns>The builder instance for fluent chaining.</returns>
    public CharacterBuilder WithBaseHP(int hp)
    {
        _health = hp;
        return this;
    }

    /// <summary>
    /// Sets the character's Armor Class rating.
    /// </summary>
    /// <param name="ac">Armor Class value.</param>
    /// <returns>The builder instance for fluent chaining.</returns>
    public CharacterBuilder WithArmorClass(int ac)
    {
        _armorClass = ac;
        return this;
    }

    /// <summary>
    /// Sets the character's initiative turn bonus.
    /// </summary>
    /// <param name="initiative">The initiative bonus value.</param>
    /// <returns>The builder instance for fluent chaining.</returns>
    public CharacterBuilder SetInitiativeBonus(int initiative)
    {
        _initiativeBase = initiative;
        return this;
    }

    /// <summary>
    /// Equips the primary weapon for the character.
    /// </summary>
    /// <param name="weapon">The primary weapon component.</param>
    /// <returns>The builder instance for fluent chaining.</returns>
    public CharacterBuilder EquipMainWeapon(IWeapon weapon)
    {
        _mainWeapon = weapon;
        return this;
    }

    /// <summary>
    /// Equips an optional secondary weapon or off-hand ability for the character.
    /// </summary>
    /// <param name="weapon">The secondary weapon component.</param>
    /// <returns>The builder instance for fluent chaining.</returns>
    public CharacterBuilder EquipSecondaryWeapon(IWeapon weapon)
    {
        _secondaryWeapon = weapon;
        return this;
    }

    /// <summary>
    /// Designates the character as a boss-tier enemy.
    /// </summary>
    /// <returns>The builder instance for fluent chaining.</returns>
    public CharacterBuilder MakeBoss()
    {
        _isBoss = true;
        return this;
    }

    /// <summary>
    /// Validates gathered configurations and constructs the final immutable <see cref="Character"/> instance.
    /// </summary>
    /// <returns>A fully configured and validated <see cref="Character"/>.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when character data fails business integrity checks (e.g. empty name or non-positive HP).
    /// </exception>
    public Character Build()
    {
        // Centralized validation: Prevents invalid or malformed characters from entering the game
        if (string.IsNullOrWhiteSpace(_name))
            throw new InvalidOperationException("Failed to build character: Name cannot be null or empty.");
        
        if (_health <= 0)
            throw new InvalidOperationException("Failed to build character: HP must be greater than 0.");

        return new Character(_name, _health, _armorClass, _initiativeBase, 
                             _mainWeapon, _secondaryWeapon, _isBoss);
    }
}