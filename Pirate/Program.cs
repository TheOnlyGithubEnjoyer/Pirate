using System;
using Raylib_cs;
using System.Numerics;

string answer; 

Centered("What is Your Name: ");

answer = Console.ReadLine();

static void Centered(string text)
{
    int numberOfSpaces = Console.WindowWidth / 2 - text.Length /2;

    int i = 0;                    //Makes the introduction more clean with centered writing
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
Centered("Pick Character! 1 (pirate) or 2 (zombie)");
string input = Console.ReadLine();

success = int.TryParse(input, out character); // Tryparse for choosing character between numbers 1 and 2
}
if (success == true)
{
    if (character == 1)                // Choosing different character makes the writing different
{
    Centered("Welcome To The Obstacle Game " + answer + " (Pirate)");
    Centered("Press Enter To Continue"); 
}
    else if (character == 2)
    {
        Centered("Welcome To The Obstacle Game " + answer + " (Zombie)");
        Centered("Press Enter To Continue");
    }
}

Console.ReadLine();

Raylib.InitWindow(800, 600, "Pirate");
Raylib.SetTargetFPS(60);


Texture2D playerImage = Raylib.LoadTexture("pirate.png"); 
Rectangle playerRect = new Rectangle(15, 300, 30, 30); 

Texture2D player2Image = Raylib.LoadTexture("zombie.png"); //Everything that will be included as a visual 

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
        playerRect.x += movement.X;     // Movement of character
        playerRect.y += movement.Y;

    if (playerRect.x < 0 || playerRect.x > 800)
    {
        moveX = true;           // Makes is so that you can reach different levels 
    }
    if (playerRect.y < 42 || playerRect.y + playerRect.height > Raylib.GetScreenHeight()) 
    {
        moveY = true;       // So you dont go through the header
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

if (character == 1) // Gameplay if you choose pirate as character
{
if (level == "stage1")
{
    Raylib.ClearBackground(Color.YELLOW);           // Everything in first stage
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);     
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Score:", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Level 1", 700, 10, 22, Color.WHITE);

}


if (level == "stage2")
{
    Raylib.ClearBackground(Color.GOLD);        // Everything in second stage    
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Score:", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Level 2", 700, 10, 22, Color.WHITE);
}

if (level == "stage3")
{
    Raylib.ClearBackground(Color.ORANGE);                  // Everything in third stage
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Score:", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Level 3", 700, 10, 22, Color.WHITE);
}

}
}

if (character == 2) // Gameplay if you choose zombie as character
{
if (level == "stage1")
{
    Raylib.ClearBackground(Color.MAGENTA);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Score:", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Level 1", 700, 10, 22, Color.WHITE);
    
}

if (level == "stage2")
{
    Raylib.ClearBackground(Color.PURPLE);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Score:", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Level 2", 700, 10, 22, Color.WHITE);
}

if (level == "stage3")
{
    Raylib.ClearBackground(Color.VIOLET);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Score:", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Level 3", 700, 10, 22, Color.WHITE);
}

}

Raylib.EndDrawing();

static Vector2 ReadMovement(float speed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;    // Movement with keyboard keys funktion
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;     

    return movement;
}
}


