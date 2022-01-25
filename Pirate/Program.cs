using System;
using Raylib_cs;
using System.Numerics;

WriteCentered("You Are About to Start The Pirate Game!");
WriteCentered("Press Enter To Load In");

static void WriteCentered(string text)
{
    int numberOfSpaces = Console.WindowWidth / 2 - text.Length /2;

    int i = 0;
    while (i < numberOfSpaces)
    {
        i++;
        Console.Write(" ");
    }
    Console.WriteLine(text);
}

Console.ReadLine();

Raylib.InitWindow(800,600, "Pirate");
Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("pirate.png");
Rectangle playerRect = new Rectangle(15, 300, playerImage.width, playerImage.height);

string level = "stage1";

while (!Raylib.WindowShouldClose())
{

}

Raylib.BeginDrawing();
{

if (level == "stage1" || level == "stage2")
{
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
}     

}

Raylib.EndDrawing();
