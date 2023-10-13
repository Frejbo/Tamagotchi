using Raylib_cs;

public class Tamagotchi
{
    private static List<Texture2D> idleAnimation = new List<Texture2D>()
    {
        Raylib.LoadTexture("character/idle1.png"),
        Raylib.LoadTexture("character/idle2.png")
    };
    private Texture2D dead = Raylib.LoadTexture("character/dead.png");

    private float hunger;
    private float boredom;
    private List<string> words = new();
    private bool isAlive = true;
    private Random generator = new();
    public string name;

    public Tamagotchi(string n) {
        name = n;
    }

    public void Feed()
    {
        // Feed() sänker Hunger
        if (!isAlive) {return;}
        hunger = Math.Clamp(hunger-1, 0, 10);
    }
    public string Hi()
    {
        // Hi() skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
        ReduceBoredom();
        string w;
        if (words.Count() > 0) {
            w = words[generator.Next(words.Count())];
        }
        else
        {
            w = "Huuuhhh? I spek no words";
        }
        Console.WriteLine(w);
        return (w);
    }
    public void Teach(string w)
    {
        if (!isAlive) {return;}
        // Teach(string word) lägger till ett ord i words, och anropar ReduceBoredom.
        words.Add(w);
    }
    public void Tick()
    {
        // Tick() ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
        if (isAlive) {
            hunger += (float)generator.NextDouble()/20;
            boredom += (float)generator.NextDouble()/10;
        }
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
        Raylib.DrawText($"Hunger: {Math.Round(hunger).ToString()}", 12, 12, 16, Color.BLACK);
        Raylib.DrawText($"Boredom: {Math.Round(boredom).ToString()}", 12, 12+16, 16, Color.BLACK);
        if (isAlive)
        {
            Raylib.DrawTexture(
                Animate(),
                Raylib.GetScreenWidth()/2-idleAnimation[0].width/2,
                150,
                Color.WHITE
            );
        }
        else
        {
            Raylib.DrawText("DED", Raylib.GetScreenWidth()/3, 150, 48, Color.BLACK);
            Raylib.DrawTexture(
                dead,
                Raylib.GetScreenWidth()/2-idleAnimation[0].width/2,
                150,
                Color.WHITE
            );
        }
    }
    private float animationIndex = 0;
    Texture2D Animate()
    {
        animationIndex+=.1f;
        if ((int)animationIndex>idleAnimation.Count()-1)
        {
            animationIndex = 0;
        }
        return idleAnimation[(int)animationIndex];
    }
    private void ReduceBoredom()
    {
        // ReduceBoredom() sänker boredom.
        boredom = Math.Clamp(boredom-1, 0, 10);
    }
}
