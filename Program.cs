using Raylib_cs;
using RayLibTemplate.Sandbox;
using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie;
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

			var gameObject = new ZombieCharacter()
			{
				Position = new Vector2(100, 100)
			};

			scene.AddGameObject(gameObject);

			// Main game loop
			while (!Raylib.WindowShouldClose())
			{
				//entityManager.UpdateEntities();
				scene.UpdateGameObjects();
				// Drawing
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.RayWhite);
				scene.DrawGameObjects();
				//entityManager.DrawEntities();

				Raylib.EndDrawing();
			}

			// Unload texture and close window
			SpriteLoader.UnloadSprites();

			Raylib.CloseWindow();
		}
	}
}
