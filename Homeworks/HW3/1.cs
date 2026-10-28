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
    public void Attack(Character target)
    {
        target.hp -= this.power;
        Console.WriteLine($"{this.name} атакует {target.name} на {this.power} урона");
    }
    public void GetStatus()
    {
        Console.WriteLine($"{name}: {hp} HP");
    }
    public static int HowMany()
    {
        return count;
    }
    public static bool IsValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }
}
class Player: Character
{
    public Player(string name, int hp, int power): base(name, hp, power)
    {
    }
}
class Enemy: Character
{
    public Enemy(string name, int hp, int power): base(name, hp, power)
    {
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("""Hello, World!""");
        Player hero = new Player("Игрок", 10, 3);
        Enemy enemy = new Enemy("Враг", 8, 2);
        Console.WriteLine($"Кол-во персонажей: {Character.HowMany()}");
        hero.GetStatus();
        enemy.GetStatus();
        hero.Attack(enemy);
        enemy.GetStatus();
        enemy.Attack(hero);
        hero.GetStatus();
    }
}
