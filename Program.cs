using Raylib_cs;
using RayLibTemplate.Sandbox;
using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie;
using RayLibTemplate.Sandbox.GameObjects.Characters.Player;
using System.Numerics;

namespace RayLibTemplate
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialize the Raylib window
			Raylib.InitWindow(800, 600, "Raylib C# Prototype");
			Raylib.SetTargetFPS(60);

			var scene = new GameScene();

			var zombie = new ZombieCharacter()
			{
				Position = new Vector2(100, 100)
			};

			var player = new PlayerCharacter()
			{
				Position = new Vector2(200, 200)
			};

			scene.AddGameObject(zombie);
			scene.AddGameObject(player);

			// Main game loop
			while (!Raylib.WindowShouldClose())
			{
				scene.UpdateGameObjects();

				// Drawing
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.RayWhite);
				
				scene.DrawGameObjects();

				Raylib.EndDrawing();
			}

			// Unload texture and close window
			SpriteLoader.UnloadSprites();
			Raylib.CloseWindow();
		}
	}
}
