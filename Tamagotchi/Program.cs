using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(500, 500, "Tamagotchi");
Raylib.SetTargetFPS(5);

Tamagotchi ta = new("Erik. A");
ta.Teach("no.");

while (!Raylib.WindowShouldClose())
{
    GetInput();

    ta.Tick();
    ta.Feed();
    ta.Hi();
    Draw();
}

void GetInput() {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_KP_1)) {
        ta.Hi();
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_KP_2)) {
        ta.Feed();
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_KP_3)) {
        ta.Teach("word");
    }
}

void Draw()
{
    int menuBeginY = Raylib.GetScreenHeight()/4*3;

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BEIGE);

    ta.Draw();

    Rectangle bg = new Rectangle(10, menuBeginY, Raylib.GetScreenWidth()-20, Raylib.GetScreenHeight()-10-menuBeginY);
    Raylib.DrawRectangle((int)bg.x, (int)bg.y, (int)bg.width, (int)bg.height, Color.WHITE);
    Raylib.DrawRectangleLinesEx(bg, 3f, Color.BLACK);

    Raylib.DrawText("1. Say hi", 50, menuBeginY + (int)bg.height/5, 24, Color.BLACK);
    Raylib.DrawText("2. Feed", 50, menuBeginY + (int)(bg.height/1.75f), 24, Color.BLACK);
    Raylib.DrawText("3. Teach", 300, menuBeginY + (int)bg.height/5, 24, Color.BLACK);

    Raylib.DrawText("Tamagotchi", 20, 50, 24, Color.BLACK);

    Raylib.EndDrawing();
}


// ta.Feed();
// ta.Teach("FUCK U");
// ta.Hi();

Console.ReadLine();