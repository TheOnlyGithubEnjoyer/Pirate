using System;
using Raylib_cs;
using System.Numerics;

string answer; 

Centered("What is Your Name: ");

answer = Console.ReadLine();

static void Centered(string text)
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


int character = 0;
bool success = false;

while (success != true)
{
Centered("Pick Character! 1 (pirate) 2 (zombie)");
string input = Console.ReadLine();

success = int.TryParse(input, out character); // Så att man kan använda siffror och bosktäver.
}
if (success == true)
{
    if (character == 1)
{
    Centered("Welcome " + answer + " (Pirate)");
    Centered("Press Enter To Contiune");
}
    else if (character == 2)
    {
        Centered("Welcome " + answer + " (Zombie)");
        Centered("Press Enter To Continue");
    }

}

Console.ReadLine();



Raylib.InitWindow(800, 600, "Pirate");
Raylib.SetTargetFPS(60);


Texture2D playerImage = Raylib.LoadTexture("pirate.png");
Rectangle playerRect = new Rectangle(15, 300, 30, 30);

Texture2D player2Image = Raylib.LoadTexture("zombie.png");

Rectangle headerRect = new Rectangle(0, 0, 800, 40);


float speed = 3.5f;

bool moveX = false;
bool moveY = false;

Vector2 movement = new Vector2();

string level = "stage1";

while (!Raylib.WindowShouldClose())
{
    moveX = false;
    moveY = false;

    if (level == "stage1")
    {
        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

    if (playerRect.x < 0 || playerRect.x > 800)
    {
        moveX = true;
    }
    if (playerRect.y < 42 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
    {
        moveY = true;
    }
    if (playerRect.x > 800)
    {
        level ="stage2";
        playerRect.x = 0;
    }

}

if (level == "stage2")
{
        
        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

    if (playerRect.x < 0 || playerRect.x > 800)
    {
        moveX = true;
    }
    if (playerRect.y < 42 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
    {
        moveY = true;
    }
        if (playerRect.x > 800)
    {
        level = "stage3";
        playerRect.x = 0;
    }
        if (playerRect.x < 0)
    {
        level ="stage1";
        playerRect.x = 800;
    }

}

    if (level == "stage3")
    {
        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

    if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
    {
        moveX = true;
    }
    if (playerRect.y < 42 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
    {
        moveY = true;
    }
    if (playerRect.x < 0)
    {
        level ="stage2";
        playerRect.x = 800;
    }

}

if (moveX == true) playerRect.x -= movement.X;
if (moveY == true) playerRect.y -= movement.Y;

Raylib.BeginDrawing();
{

if (character == 1)
{
if (level == "stage1")
{
    Raylib.ClearBackground(Color.YELLOW);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    
}


if (level == "stage2")
{
    Raylib.ClearBackground(Color.ORANGE);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
}

if (level == "stage3")
{
    Raylib.ClearBackground(Color.RED);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
}

}
}

if (character == 2)
{
if (level == "stage1")
{
    Raylib.ClearBackground(Color.YELLOW);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    
}


if (level == "stage2")
{
    Raylib.ClearBackground(Color.ORANGE);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
}

if (level == "stage3")
{
    Raylib.ClearBackground(Color.RED);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
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


