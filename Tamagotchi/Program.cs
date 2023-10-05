using Raylib_cs;

Raylib.InitWindow(500, 500, "Tamagotchi");
Raylib.SetTargetFPS(5);

Tamagotchi ta = new("Erik. A");
ta.Teach("no.");

while (!Raylib.WindowShouldClose())
{
    ta.Tick();
    ta.Feed();
    ta.Hi();
    Draw();
}

void Draw()
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BEIGE);

    Raylib.DrawText("Tamagotchi", 20, 50, 24, Color.BLACK);

    Raylib.EndDrawing();
}


// ta.Feed();
// ta.Teach("FUCK U");
// ta.Hi();

Console.ReadLine();