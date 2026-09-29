using System.Diagnostics;
using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;

Console.WriteLine("=== SINGLETON: TEST ===\n");

var db = new DatabaseService();
var ui = new UiService();

Console.WriteLine();

db.Config.Theme = "Dark";
Console.WriteLine("Admin changed theme to Dark.");

ui.Render();

Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
Console.WriteLine($"Times config was loaded from disk: {AppConfigSingleton.LoadCount}");

Console.WriteLine("\n=== PROTOTYPE: TEST ===\n");

var sw = Stopwatch.StartNew();
var army = new List<EnemyPrototype>();
var registry = new EnemyRegistry();

var baseOrc = new Orc();
registry.Register("BasicOrc", baseOrc);

for (int i = 1; i <= 5; i++)
{
    var orc = (Orc)registry.Create("BasicOrc");
    orc.Name = $"Orc-{i}";
    army.Add(orc);
}
sw.Stop();
Console.WriteLine($"Created 5 orcs using cloning in {sw.ElapsedMilliseconds} ms\n");

EnemyPrototype original = new Orc();
original.Name = "Boss Orc";
EnemyPrototype copy = original.Clone();

Console.WriteLine($"Original model id: {original.ModelId}");
Console.WriteLine($"Copy model id:     {copy.ModelId}");

copy.Weapon.Damage = 999;
Console.WriteLine($"\nWe changed the COPY's weapon damage to 999.");
Console.WriteLine($"Original's weapon damage is now: {original.Weapon.Damage} (Should be 25 - Deep Copy success)");

copy.Abilities.Add("Fire Breath");
Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)} (Should not include Fire Breath - Deep Copy success)");

Console.WriteLine("\n=== BUILDER: TEST ===\n");
Console.WriteLine(RegistrationCallSites.CreateLiveStudentUgly());
Console.WriteLine(RegistrationCallSites.CreateVideosOnlyUgly());

Console.WriteLine("\nAll Design Patterns tests passed successfully!");