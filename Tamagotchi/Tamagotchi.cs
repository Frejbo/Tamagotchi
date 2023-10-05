public class Tamagotchi
{
    private int hunger;
    private int boredom;
    private List<string> words;
    private bool isAlive;
    private Random generator;
    public string name;

    public void Feed()
    {
        // Feed() sänker Hunger

    }
    public void Hi()
    {
        // Hi() skriver ut ett slumpat ord från words, och anropar ReduceBoredom.

    }
    public void Teach(string w)
    {
        // Teach(string word) lägger till ett ord i words, och anropar ReduceBoredom.

    }
    public void Tick()
    {
        // Tick() ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.

    }
    public void PrintStats()
    {
        // PrintStats() skriver ut nuvarande hunger och boredom, och meddelar också huruvida tamagotchin lever.
        System.Console.WriteLine($"Hunger: {hunger}");
        System.Console.WriteLine($"boredom: {boredom}");
        System.Console.WriteLine($"isAlive: {isAlive}");
    }
    public bool GetAlive()
    {
        // GetAlive() returnerar värdet som isAlive har.
        return isAlive;
    }
    private void ReduceBoredom()
    {
        // ReduceBoredom() sänker boredom.

    }
}
