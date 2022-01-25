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

float speed = 3.5f;

bool moveX = false;
bool moveY = false;

Vector2 movement = new Vector2();

string level = "stage1";

while (!Raylib.WindowShouldClose())
{
    moveX = false;
    moveY = false;
    
    if (level == "stage1" || level == "stage2")
    {
        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

            if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
    {
        moveX = true;
    }
    if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
    {
        moveY = true;
    }
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

static Vector2 ReadMovement(float speed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;     

    return movement;
}
}

