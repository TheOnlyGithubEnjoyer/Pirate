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
Rectangle playerRect = new Rectangle(10, 60, 35, 40); 

Texture2D bossImage = Raylib.LoadTexture("Enemy.png");
Rectangle bossRect = new Rectangle(1500, 300, 50, 65);

Texture2D player2Image = Raylib.LoadTexture("zombie.png"); //Everything that will be included as a visual
Texture2D player2ImageDeagle = Raylib.LoadTexture("ZombieDeagle.png");
Texture2D player2ImageAk = Raylib.LoadTexture("ZombieAk.png");
Texture2D player2ImageRPG = Raylib.LoadTexture("zombieRPG.png");

Texture2D backgroundImage = Raylib.LoadTexture("Background1.png");
Texture2D backgroundImage2 = Raylib.LoadTexture("Background2.png");
Rectangle backgroundRect = new Rectangle(0, 0, backgroundImage.width, backgroundImage.height);


Rectangle headerRect = new Rectangle(0, 0, 1800, 40); 

List<Rectangle> weaponRecs = new List<Rectangle>();

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

weaponRecs.Add(new Rectangle(208, 60, 25, 25));
weaponRecs.Add(new Rectangle(658, 560, 25, 25));
weaponRecs.Add(new Rectangle(1175, 560, 25, 25));


}


int weapons = 0;

int bossHP = 1000;

int playerHP = 200;

int deaths = 0;

bool weaponTake = false;

bool weaponTake2 = false;

bool weaponTake3 = false;

bool weaponTake4 = false;

float speed = 5f;   

float speed2 = 10f;

bool moveX = false;         
bool moveY = false; 

bool moveX2 = false;
bool moveY2 = false;

Vector2 movement = new Vector2();

Vector2 movement2 = new Vector2();

string level = "stage1";

while (!Raylib.WindowShouldClose())
{
    moveX = false;
    moveY = false;

    moveX2 = false;
    moveY2 = false;

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

        movement2 = ReadMovement2(speed2);
        bossRect.x += movement2.X;
        bossRect.y += movement2.Y;

    if (playerRect.x < 0 || playerRect.x > 1800 || bossRect.x < 0 || bossRect.x > 1800)    // if (the size of the player is less than 0 in x value or if the size
    {                
        moveX2 = true;                               // of the player is at a bigger x value than 1800) 
        moveX = true;                               // {movement left and right will work}
    }
    if (playerRect.y < 42 || playerRect.y + playerRect.height > Raylib.GetScreenHeight() || bossRect.y < 42 || bossRect.y + bossRect.height > Raylib.GetScreenHeight()) 
                                                                                        // if (the value of y on the player goes lower than 42 or if the value of y
    {             
        moveY2 = true;                                                                        // and the height of the player is a bigger value on y than the screen width)
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

if (moveX2 == true) bossRect.x -= movement2.X;
if (moveY2 == true) bossRect.y -= movement2.Y;

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
    Raylib.DrawText("Score: ", 1680, 10, 22, Color.WHITE);
    Raylib.DrawText("Pirate Game", 850, 10, 22, Color.WHITE);
    
       if (Raylib.CheckCollisionRecs(playerRect, rects[i]))
    {
        playerRect.x = 12;
        playerRect.y = 60;
        deaths++;
    }
    }
      if (Raylib.CheckCollisionRecs(playerRect, weaponRecs[0]) && weaponTake == false)
        {
            weaponTake = true;
            weaponTake2 = true;

        }
        if (weaponTake == false)
        {
            Raylib.DrawRectangleRec(weaponRecs[0], Color.GREEN);

        }
                if (weaponTake2 == true)
        {
            Raylib.DrawRectangleRec(weaponRecs[1], Color.GREEN);
        }
        if (Raylib.CheckCollisionRecs(playerRect, weaponRecs[1]) && weaponTake2 == true)
        {
            weaponTake2 = false;
        }

}

// if (level == "stage2")
// {
//     Raylib.DrawRectangle(0, 300, 1800, 600, Color.ORANGE);
//     Raylib.ClearBackground(Color.GOLD);        // Everything in second stage    
//     Raylib.DrawRectangleRec(headerRect, Color.BLACK);
//     Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
//     Raylib.DrawText("Level 2", 12, 10, 22, Color.WHITE);
//     Raylib.DrawText("Score: ", 1680, 10, 22, Color.WHITE);
//     Raylib.DrawText("Pirate Game", 850, 10, 22, Color.WHITE);
    
// }

}
}

if (character == 2) // Gameplay if you choose zombie as character
{
if (level == "stage1")
{

    Raylib.DrawTexture(backgroundImage, (int)backgroundRect.x, (int)backgroundRect.y, Color.WHITE);

    for (int i = 0; i < rects.Count; i++)
    {
    Rectangle rectangle = rects[i];

    rects[i] = rectangle;

    Raylib.DrawRectangleRec(headerRect, Color.BLACK);
    Raylib.DrawRectangleRec(rects[i], Color.BLACK);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 1", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Deaths (" + deaths + ")", 450, 10, 22, Color.WHITE);
    Raylib.DrawText("Weapon: ", 1550, 10, 22, Color.WHITE);
    Raylib.DrawText("Zombie Game", 850, 10, 22, Color.WHITE);
    
       if (Raylib.CheckCollisionRecs(playerRect, rects[i]))
    {
        playerRect.x = 12;
        playerRect.y = 60;
        deaths++;
    }
    }
      
            if (Raylib.CheckCollisionRecs(playerRect, weaponRecs[0]) && weaponTake == false) // First collision detection with weapon rectangle 1
        {
            weaponTake = true;
            weaponTake2 = true;

        }
        if (weaponTake == false)
        {
            Raylib.DrawRectangleRec(weaponRecs[0], Color.WHITE); // Make sure to draw the weapon rectangle when it is False
        }
        if (weaponTake2 == true)
        {
            Raylib.DrawText("Desert Eagle", 1650, 10, 22, Color.WHITE);
            Raylib.DrawRectangleRec(weaponRecs[1], Color.GREEN);
            Raylib.DrawTexture(player2ImageDeagle, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
            weapons = 1;


        }
        if (Raylib.CheckCollisionRecs(playerRect, weaponRecs[1]) && weaponTake2 == true)
        {
            weaponTake2 = false;
            weaponTake3 = true;
        }
        if (weaponTake3 == true)
        {
            Raylib.DrawText("Ak-47", 1650, 10, 22, Color.WHITE);
            Raylib.DrawTexture(player2ImageAk,(int)playerRect.x, (int)playerRect.y, Color.WHITE);
            Raylib.DrawRectangleRec(weaponRecs[2], Color.PURPLE);
            weapons = 2;

        }
        if (Raylib.CheckCollisionRecs(playerRect, weaponRecs[2]) && weaponTake3 == true)
        {
            weaponTake3 = false;
            weaponTake4 = true;
        }
        if (weaponTake4 == true)
        {
            Raylib.DrawText("RPG", 1650, 10, 22, Color.WHITE);
            Raylib.DrawTexture(player2ImageRPG,(int)playerRect.x, (int)playerRect.y, Color.WHITE);
            weapons = 3;

        }
}

if (level == "stage2")
{
    Raylib.DrawTexture(backgroundImage2, (int)backgroundRect.x, (int)backgroundRect.y, Color.WHITE);
    Raylib.DrawRectangleRec(headerRect, Color.RED);
    Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawText("Level 2", 12, 10, 22, Color.WHITE);
    Raylib.DrawText("Weapon: ", 1550, 10, 22, Color.WHITE);   
    Raylib.DrawText("Zombie Game", 850, 10, 22, Color.WHITE);
    Raylib.DrawText("Health:", 400, 10, 22, Color.WHITE);
    Raylib.DrawText(playerHP.ToString(), 480, 10, 22, Color.WHITE);
    
    Raylib.DrawTexture(bossImage, (int)bossRect.x, (int)bossRect.y, Color.WHITE);

    if (weapons == 0)
    {
        Raylib.DrawTexture(player2Image, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    }
    else if (weapons == 1)
    {
        Raylib.DrawTexture(player2ImageDeagle, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        Raylib.DrawText("Desert Eagle", 1650, 10, 22, Color.WHITE);
    }
    else if (weapons == 2)
    {
        Raylib.DrawTexture(player2ImageAk, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        Raylib.DrawText("Ak-47", 1650, 10, 22, Color.WHITE);
    }
    else if (weapons == 3)
    {
        Raylib.DrawTexture(player2ImageRPG, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        Raylib.DrawText("RPG", 1650, 10, 22, Color.WHITE);
    }

    if (Raylib.CheckCollisionRecs(playerRect, bossRect))
    {
        playerHP --;
    }
    if(playerHP < 0)
    {
        level = "Game Over";
    }
}

if (level == "Game Over")
{
    Raylib.ClearBackground(Color.RED);
    Raylib.DrawText("YOU ARE DIED", 840, 300, 35, Color.WHITE);
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
static Vector2 ReadMovement2(float speed2)
{
        Vector2 movement2 = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) movement2.Y = -speed2;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) movement2.Y = speed2;    // Movement with arrow keys funktion for stage2
    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) movement2.X = -speed2;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) movement2.X = speed2;  

    return movement2;
}
}



