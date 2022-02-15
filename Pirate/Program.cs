using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

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
    if (character == 1)                
{
    Centered("Welcome to The Pirate Game " + "(" + answer + " the Pirate" + ")");
    Centered("Press Enter To Continue"); 
}
    if (character == 2)
    {
        Centered("Welcome to The Zombie Game " + "(" + answer + " the Zombie" + ")");
        Centered("Press Enter to Continue");
    }
}

Console.ReadLine();

Raylib.InitWindow(1800, 600, "Pirate");
Raylib.SetTargetFPS(60);


Texture2D playerImage = Raylib.LoadTexture("pirate.png"); 
Rectangle playerRect = new Rectangle(10, 60, 30, 30); 

Texture2D player2Image = Raylib.LoadTexture("zombie.png"); //Everything that will be included as a visual

Rectangle headerRect = new Rectangle(0, 0, 1800, 40); 

List<Rectangle> pointRecs = new List<Rectangle>();

List<Rectangle> rects = new List<Rectangle>();


for (int i = 0; i < 1; i++)
{

rects.Add(new Rectangle(0, 150, 50, 450));
rects.Add(new Rectangle(140, 0, 50, 450));
rects.Add(new Rectangle(250, 0, 50, 520));
rects.Add(new Rectangle(370, 100, 45, 500));
rects.Add(new Rectangle(480, 0, 50, 530));
rects.Add(new Rectangle(700, 350, 50, 350));
rects.Add(new Rectangle(600, 350, 120, 50));
rects.Add(new Rectangle(700, 0, 50, 300));
rects.Add(new Rectangle(600, 100, 50, 200));
rects.Add(new Rectangle(600, 450, 40, 200));
rects.Add(new Rectangle(850, 0, 50, 520));          // All the objects inside the game
rects.Add(new Rectangle(950, 0, 50, 440));
rects.Add(new Rectangle(1100, 180, 50, 420));
rects.Add(new Rectangle(1230, 250, 100, 50));
rects.Add(new Rectangle(1150, 400, 100, 50));
rects.Add(new Rectangle(1330, 0, 50, 450));
rects.Add(new Rectangle(1330, 520, 50, 90));
rects.Add(new Rectangle(1330, 520, 250, 40));
rects.Add(new Rectangle(1530, 150, 50, 400));
rects.Add(new Rectangle(1580, 150, 250, 50));
rects.Add(new Rectangle(1580, 90, 40, 100));
rects.Add(new Rectangle(1680, 0, 180, 80));

pointRecs.Add(new Rectangle(208, 60, 25, 25));
pointRecs.Add(new Rectangle(658, 560, 25, 25));


}


int points = 0;

int deaths = 0;

bool pointTake = false;

bool pointTake2 = false;

float speed = 6f;           

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

    if (playerRect.x < 0 || playerRect.x > 1800)
    {
        moveX = true;           // Makes is so that you can reach different levels 
    }
    if (playerRect.y < 42 || playerRect.y + playerRect.height > Raylib.GetScreenHeight()) 
    {
        moveY = true;       // So you dont go through the header
    }
    if (playerRect.x > 1800)
    {
        level ="stage2";
        playerRect.x = 0;
    }

}

if (level == "stage2")
{                                           //PSEUDOKOD
                            
        movement = ReadMovement(speed);     // if (level of the game is 1)
        playerRect.x += movement.X;         // {movement of the character will be read and will have a speed
        playerRect.y += movement.Y;

    if (playerRect.x < 0 || playerRect.x > 1800)    // if (the size of the player is less than 0 in x value or if the size
    {                                               // of the player is at a bigger x value than 1800) 
        moveX = true;                               // {movement left and right will work}
    }
    if (playerRect.y < 42 || playerRect.y + playerRect.height > Raylib.GetScreenHeight()) // if (the value of y on the player goes lower than 42 or if the value of y
    {                                                                                     // and the height of the player is a bigger value on y than the screen width)
        moveY = true;                                                                     // {movement down and up will work}
    }
        if (playerRect.x > 1800)                    // if (the player size of the x value exceeds 1800 in the x value)
    {                                               // {let the level change from "stage1" to "stage2"
        level = "stage3";                           // make the x value of the player also end up at 0}
        playerRect.x = 0;
    }
        if (playerRect.x < 0)
    {
        level ="stage1";
        playerRect.x = 1800;
    }

}

    if (level == "stage3")
    {
        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

    if (playerRect.x < 0 || playerRect.x > 1800)
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
        playerRect.x = 1800;
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
    
    Raylib.DrawRectangle(0, 300, 1800, 600, Color.ORANGE);
    Raylib.ClearBackground(Color.YELLOW);
    
    for (int i = 0; i < rects.Count; i++)
    {
    Rectangle rectangle = rects[i];

    rects[i] = rectangle;


    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawRectangleRec(rects[i], Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 1", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Deaths (" + deaths + ")", 450, 10, 22, Color.WHITE);
    Raylib.DrawText("Score: " + points, 1680, 10, 22, Color.WHITE);
    Raylib.DrawText("Pirate Game", 850, 10, 22, Color.WHITE);
    
       if (Raylib.CheckCollisionRecs(playerRect, rects[i]))
    {
        playerRect.x = 12;
        playerRect.y = 60;
        deaths++;
    }
    }
      if (Raylib.CheckCollisionRecs(playerRect, pointRecs[0]) && pointTake == false)
        {
            points++;
            pointTake = true;
            pointTake2 = true;

        }
        if (pointTake == false)
        {
            Raylib.DrawRectangleRec(pointRecs[0], Color.GREEN);

        }
                if (pointTake2 == true)
        {
            Raylib.DrawRectangleRec(pointRecs[1], Color.GREEN);
        }
        if (Raylib.CheckCollisionRecs(playerRect, pointRecs[1]) && pointTake2 == true)
        {
            points++;
            pointTake2 = false;
        }

}

if (level == "stage2")
{
    Raylib.DrawRectangle(0, 300, 1800, 600, Color.ORANGE);
    Raylib.ClearBackground(Color.GOLD);        // Everything in second stage    
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 2", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Score: " + points, 1680, 10, 22, Color.WHITE);
    Raylib.DrawText("Pirate Game", 850, 10, 22, Color.WHITE);
    
}

if (level == "stage3")
{
    Raylib.DrawRectangle(0, 300, 1800, 600, Color.ORANGE);
    Raylib.ClearBackground(Color.BEIGE);                  // Everything in third stage
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 3", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Score: " + points, 1680, 10, 22, Color.WHITE);
    Raylib.DrawText("Pirate Game", 850, 10, 22, Color.WHITE);

}
}
}

if (character == 2) // Gameplay if you choose zombie as character
{
if (level == "stage1")
{

    Raylib.DrawRectangle(0, 300, 1800, 600, Color.LIGHTGRAY);
    Raylib.ClearBackground(Color.MAGENTA); 

    for (int i = 0; i < rects.Count; i++)
    {
    Rectangle rectangle = rects[i];

    rects[i] = rectangle;

    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawRectangleRec(rects[i], Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 1", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Deaths (" + deaths + ")", 450, 10, 22, Color.WHITE);
    Raylib.DrawText("Score: " + points, 1680, 10, 22, Color.WHITE);
    Raylib.DrawText("Zombie Game", 850, 10, 22, Color.WHITE);
    
       if (Raylib.CheckCollisionRecs(playerRect, rects[i]))
    {
        playerRect.x = 12;
        playerRect.y = 60;
        deaths++;
    }
    }
      
            if (Raylib.CheckCollisionRecs(playerRect, pointRecs[0]) && pointTake == false)
        {
            points++;
            pointTake = true;
            pointTake2 = true;

        }
        if (pointTake == false)
        {
            Raylib.DrawRectangleRec(pointRecs[0], Color.GREEN);
        }
        if (pointTake2 == true)
        {
            Raylib.DrawRectangleRec(pointRecs[1], Color.GREEN);
        }
        if (Raylib.CheckCollisionRecs(playerRect, pointRecs[1]) && pointTake2 == true)
        {
            points++;
            pointTake2 = false;
        }


}

if (level == "stage2")
{
    Raylib.DrawRectangle(0, 300, 1800, 600, Color.LIGHTGRAY);
    Raylib.ClearBackground(Color.PURPLE);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 2", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Score: " + points, 1680, 10, 22, Color.WHITE);
    Raylib.DrawText("Zombie Game", 850, 10, 22, Color.WHITE);
}

if (level == "stage3")
{
    Raylib.DrawRectangle(0, 300, 1800, 600, Color.LIGHTGRAY);
    Raylib.ClearBackground(Color.VIOLET);
    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 3", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Score: " + points, 1680, 10, 22, Color.WHITE);
    Raylib.DrawText("Zombie Game", 850, 10, 22, Color.WHITE);
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


