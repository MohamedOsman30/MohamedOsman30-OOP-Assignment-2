namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon DeepCopy() => new Weapon { Name = Name, Damage = Damage };
}

public abstract class EnemyPrototype
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();
    public string ModelId => _modelData;

    protected EnemyPrototype()
    {
        Console.WriteLine("   ...loading 3D model (slow)...");
        Thread.Sleep(500);
        _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }

    protected EnemyPrototype(EnemyPrototype source)
    {
        _modelData = source._modelData;
        Name = source.Name;
        Health = source.Health;
        Weapon = source.Weapon?.DeepCopy();
        Abilities = new List<string>(source.Abilities);
    }

    public abstract EnemyPrototype Clone();
}

public class Orc : EnemyPrototype
{
    public Orc()
    {
        Name = "Orc";
        Health = 100;
        Weapon = new Weapon { Name = "Axe", Damage = 25 };
        Abilities.Add("Rage");
    }

    protected Orc(Orc source) : base(source) { }

    public override EnemyPrototype Clone() => new Orc(this);
}

public class Elf : EnemyPrototype
{
    public Elf()
    {
        Name = "Elf";
        Health = 70;
        Weapon = new Weapon { Name = "Bow", Damage = 18 };
        Abilities.Add("Stealth");
    }

    protected Elf(Elf source) : base(source) { }

    public override EnemyPrototype Clone() => new Elf(this);
}

public class EnemyRegistry
{
    private readonly Dictionary<string, EnemyPrototype> _prototypes = new();

    public void Register(string key, EnemyPrototype prototype)
    {
        _prototypes[key] = prototype;
    }

    public EnemyPrototype Create(string key)
    {
        if (_prototypes.TryGetValue(key, out var prototype))
        {
            return prototype.Clone();
        }
        throw new KeyNotFoundException($"Prototype '{key}' not found.");
    }
}