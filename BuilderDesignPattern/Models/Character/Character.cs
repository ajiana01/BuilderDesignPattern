using System.Text;
using BuilderDesignPattern.Interface;

namespace BuilderDesignPattern.Models.Character;

/// <summary>
/// Represents a combatant entity on the battle grid.
/// In the Builder Design Pattern, this class serves as the <b>Product</b>.
/// <para>
/// <b>Key Design Characteristics:</b>
/// <list type="bullet">
///   <item><description><b>Immutability:</b> All properties have <c>private set</c>, ensuring the character state remains thread-safe and consistent once created.</description></item>
///   <item><description><b>Controlled Construction:</b> The constructor is marked <c>internal</c> to discourage callers from invoking lengthy telescoping parameter lists directly, delegating creation to <see cref="Builders.CharacterBuilder"/>.</description></item>
/// </list>
/// </para>
/// </summary>
public class Character
{
    /// <summary>
    /// Gets the character's display name or title.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the character's hit points (health).
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Gets the character's Armor Class (AC), determining how difficult they are to hit.
    /// </summary>
    public int ArmorClass { get; private set; }

    /// <summary>
    /// Gets the character's initiative modifier for battle turn order.
    /// </summary>
    public int InitiativeBase { get; private set; }

    /// <summary>
    /// Gets the primary equipped weapon, or <c>null</c> if unarmed.
    /// </summary>
    public IWeapon? MainWeapon { get; private set; }

    /// <summary>
    /// Gets the secondary equipped weapon (off-hand or special ability), or <c>null</c> if none.
    /// </summary>
    public IWeapon? SecondaryWeapon { get; private set; }

    /// <summary>
    /// Gets a value indicating whether this character is classified as a boss monster.
    /// </summary>
    public bool IsBoss { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Character"/> class.
    /// Kept <c>internal</c> to prevent external code from directly invoking the "Telescoping Constructor" anti-pattern.
    /// Creation should be mediated through <see cref="Builders.CharacterBuilder"/>.
    /// </summary>
    /// <param name="name">The name of the character.</param>
    /// <param name="health">Base health points.</param>
    /// <param name="armorClass">Armor class rating.</param>
    /// <param name="initiativeBase">Initiative turn bonus.</param>
    /// <param name="mainWeapon">Primary weapon (optional).</param>
    /// <param name="secondaryWeapon">Secondary weapon or off-hand (optional).</param>
    /// <param name="isBoss">Whether this entity is a boss unit.</param>
    internal Character(string name, int health, int armorClass, int initiativeBase, 
        IWeapon? mainWeapon, IWeapon? secondaryWeapon, bool isBoss)
    {
        Name = name;
        Health = health;
        ArmorClass = armorClass;
        InitiativeBase = initiativeBase;
        MainWeapon = mainWeapon;
        SecondaryWeapon = secondaryWeapon;
        IsBoss = isBoss;
    }

    /// <summary>
    /// Formats and returns a human-readable summary of the character's battle statistics.
    /// </summary>
    /// <returns>A formatted multi-line string containing character statistics.</returns>
    public string GetCharacterStats()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"--- {(IsBoss ? "BOSS: " : "UNIT: ")}{Name} ---");
        sb.AppendLine($"HP: {Health} | AC: {ArmorClass} | Initiative: +{InitiativeBase}");
        sb.AppendLine($"Main Wpn: {(MainWeapon != null ? MainWeapon.Name : "Unarmed")}");
        sb.AppendLine($"Sec Wpn: {(SecondaryWeapon != null ? SecondaryWeapon.Name : "None")}");
        return sb.ToString();
    }
}