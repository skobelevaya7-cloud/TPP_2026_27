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
        get{ return hp; }
    }
    public virtual void Attack(Character target) //атака
    {
        target.TakeDamage(this.power);
        Console.WriteLine($"{this.name} атакует {target.name} на {this.power} урона");
    }
    public override string ToString() //вывод состояния
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
}
class Player: Character
{
    public Player(string name, int hp, int power): base(name, hp, power)
    {
    }
    public override void Attack(Character target)
    {
        base.Attack(target);
        Console.WriteLine($"{this.Name} в борьбе со злом атакует {target.Name} на {this.Power} урона");
        target.IsAlive();
    }
}
class Enemy: Character
{
    public Enemy(string name, int hp, int power): base(name, hp, power)
    {
    }
    public override void Attack(Character target)
    {
        base.Attack(target);
        Console.WriteLine($"{this.Name} идет против света и наносит  {target.Name} на {this.Power} урона");
        target.IsAlive();
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("""Hello, World!""");
        Player hero = new Player("Фродо", 10, 3);
        Enemy enemy = new Enemy("Злобный орк", 8, 2);
        Console.WriteLine($"Кол-во персонажей: {Character.HowMany()}");
        hero.Attack(enemy);
        enemy.Attack(hero);
    }
}
