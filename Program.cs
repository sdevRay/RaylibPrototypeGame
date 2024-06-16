using Raylib_cs;
using RayLibTemplate.Sandbox2;
using RayLibTemplate.Sandbox2.Entites;
using RayLibTemplate.Sandbox2.Player;
using RayLibTemplate.Sandbox2.Systems;
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

			var player = new Player();

			DrawSystem drawSystem = new DrawSystem();
			MovementSystem movementSystem = new MovementSystem();
			AIMovementSystem aiMovementSystem = new AIMovementSystem(player);
			CollisionSystem collisionSystem = new CollisionSystem();

			drawSystem.AddEntity(player);
			movementSystem.AddEntity(player);
			collisionSystem.AddEntity(player);

			var zombie = new Zombie(new Vector2(300, 300));
			drawSystem.AddEntity(zombie);
			aiMovementSystem.AddEntity(zombie);
			collisionSystem.AddEntity(zombie);

			// Main game loop
			while (!Raylib.WindowShouldClose())
			{
				float deltaTime = Raylib.GetFrameTime();

				movementSystem.Update(deltaTime);
				aiMovementSystem.Update(deltaTime);
				collisionSystem.Update(deltaTime);

				// Drawing
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.RayWhite);
				
				drawSystem.Update(deltaTime);

				Raylib.EndDrawing();
			}

			// Unload texture and close window
			TextureLoader.UnloadAllTextures();			
			Raylib.CloseWindow();
		}
	}
}
