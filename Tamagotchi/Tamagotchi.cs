using Raylib_cs;

public class Tamagotchi
{
    private static List<Texture2D> idleAnimation = new List<Texture2D>()
    {
        Raylib.LoadTexture("character/idle1.png"),
        Raylib.LoadTexture("character/idle2.png")
    };

    private int hunger;
    private int boredom;
    private List<string> words = new();
    private bool isAlive;
    private Random generator = new();
    public string name;

    public Tamagotchi(string n) {
        name = n;
    }

    public void Feed()
    {
        // Feed() sänker Hunger
        hunger--;
    }
    public void Hi()
    {
        // Hi() skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
        ReduceBoredom();
        if (words.Count() > 0) {
            System.Console.WriteLine(words[generator.Next(words.Count())]);
        }
    }
    public void Teach(string w)
    {
        // Teach(string word) lägger till ett ord i words, och anropar ReduceBoredom.
        words.Add(w);
    }
    public void Tick()
    {
        // Tick() ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
        hunger++;
        boredom++;
        if (hunger > 10 || boredom > 10)
        {
            isAlive = false;
        }
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
    public void Draw() {
        System.Console.WriteLine(Animate());
        Raylib.DrawTexture(
            Animate(),
            Raylib.GetScreenWidth()/2-idleAnimation[0].width/2,
            150,
            Color.WHITE
        );
    }
    private float animationIndex = 0;
    Texture2D Animate()
    {
        System.Console.WriteLine(animationIndex);
        animationIndex+=.5f;
        if ((int)animationIndex>idleAnimation.Count()-1)
        {
            animationIndex = 0;
        }
        return idleAnimation[(int)animationIndex];
    }
    private void ReduceBoredom()
    {
        // ReduceBoredom() sänker boredom.
        boredom--;
    }
}
