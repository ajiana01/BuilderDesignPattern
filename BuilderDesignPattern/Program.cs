using BuilderDesignPattern.Builders;
using BuilderDesignPattern.Models.Character;
using BuilderDesignPattern.Models.Weapon;

#region Without Builder Pattern
{
    Console.WriteLine("================================================================");
    Console.WriteLine(" 1. WITHOUT BUILDER PATTERN (Telescoping Constructor Anti-Pattern)");
    Console.WriteLine("================================================================\n");

    // Problems with direct constructor instantiation:
    // 1. Unclear semantics: What do '15', '12', '2', 'null', and 'false' represent at a glance?
    // 2. High error risk: Easy to accidentally swap adjacent arguments of the same type (e.g., HP vs AC).
    // 3. Cluttered signatures: Callers must supply boilerplate literals like 'null' and 'false' for optional fields.
    Character goblin = new Character("Goblin Grunt", 15, 12, 2, new Dagger(), null, false);

    Character dragon = new Character("Ancient Red Dragon", 300, 18, 5, new Claw(), new FireBreath(), true);

    Console.WriteLine(goblin.GetCharacterStats());
    Console.WriteLine(dragon.GetCharacterStats());
}
#endregion

#region Using Builder Pattern
{
    Console.WriteLine("================================================================");
    Console.WriteLine(" 2. USING BUILDER PATTERN (Fluent Step-by-Step Construction)");
    Console.WriteLine("================================================================\n");

    // Benefits of the Builder Pattern:
    // 1. Self-documenting & expressive: Method names clearly describe the role of each argument.
    // 2. Optional values handled gracefully: No need to pass 'null' for secondary weapon or 'false' for IsBoss.
    // 3. Sensible defaults & centralized validation: Handled internally inside the builder.
    Character goblin = new CharacterBuilder()
        .WithName("Goblin Grunt")
        .WithBaseHP(15)
        .WithArmorClass(12)
        .SetInitiativeBonus(2)
        .EquipMainWeapon(new Dagger())
        .Build();

    // Fluent interface allows natural, readable construction of complex objects with optional components
    Character dragon = new CharacterBuilder()
        .WithName("Ancient Red Dragon")
        .WithBaseHP(300)
        .WithArmorClass(18)
        .SetInitiativeBonus(5)
        .EquipMainWeapon(new Claw())
        .EquipSecondaryWeapon(new FireBreath())
        .MakeBoss()
        .Build();

    Console.WriteLine(goblin.GetCharacterStats());
    Console.WriteLine(dragon.GetCharacterStats());
}
#endregion
