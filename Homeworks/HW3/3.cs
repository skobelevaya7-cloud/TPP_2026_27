using Microsoft.Win32.SafeHandles;

class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count = 0;
    public Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;
    }
    public string Name
    {
        get{ return name; }
    }
    public int Hp
    {
        get{ return hp; }
    }
    public int Power
    {
        get{ return power; }
    }
    public virtual void Attack(Character target)
    {
        target.TakeDamage(this.power);
        Console.WriteLine($"{this.name} атакует {target.name} на {this.power} урона");
    }
    public override string ToString()
    {
        return $"{Name} (HP: {Hp})";
    }
    public static int HowMany()
    {
        return count;
    }
    public static bool IsValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }
    public int TakeDamage(int damage)
    {
        this.hp -= damage;
        return hp;
    }
    public bool IsAlive()
    {
        bool isAlive = true;
        if (this.hp > 0){ isAlive = true; }
        else {isAlive = false;}
        return isAlive;
    }
    public override bool Equals(object obj)
    {
        if (obj is Character other)
        {
            return this.name == other.name;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return name != null ? name.GetHashCode() : 0;
    }
}
class Player: Character
{
    public Player(string name, int hp, int power): base(name, hp, power)
    {
    }
    public override void Attack(Character target)
    {
        Console.WriteLine($"{this.Name} совершает выпад мечом против {target.Name} на {this.Power} урона");
        target.TakeDamage(this.Power);
    }
}
class Enemy: Character
{
    public Enemy(string name, int hp, int power): base(name, hp, power){ }
    public override void Attack(Character target)
    {
        Console.WriteLine($"{this.Name} яростно кусает {target.Name} на {this.Power} урона");
        target.TakeDamage(this.Power);
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("""Hello, World!""");
        Player hero = new Player("Фродо", 10, 3);
        Enemy enemy = new Enemy("Злобный орк", 8, 2);
        Console.WriteLine($"Создан боец: {hero}");
        Console.WriteLine($"Создан боец: {enemy}");
        Player clone = new Player("Фродо", 50, 8);
        Console.WriteLine($"Проверка Equals: {hero.Equals(clone)}");
        List<Character> battlefield = new List<Character> {hero, enemy};
        Console.WriteLine($"Кол-во персонажей: {Character.HowMany()}");
        Console.WriteLine($"Бой начинается!");
        int round = 1;
        while (hero.IsAlive() && enemy.IsAlive())
        {
            Console.WriteLine($"Раунд {round}");
            hero.Attack(enemy);
            Console.WriteLine(enemy);
            if (!enemy.IsAlive()) break;
            Console.WriteLine();
            enemy.Attack(hero);
            Console.WriteLine(hero);
            round++;
            Console.WriteLine();
        }
        Console.WriteLine("Конец игры");
        if (hero.IsAlive())
        {
            Console.WriteLine($"Победа зафиксирована! {hero.Name} выжил!");
        }
        else
            Console.WriteLine($"{enemy.Name} победилю Тьма опустилась на Средиземье...");
    }
}

