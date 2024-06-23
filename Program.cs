using Raylib_cs;
using RayLibTemplate.Sandbox2;
using RayLibTemplate.Sandbox2.Entites;
using RayLibTemplate.Sandbox2.Entities;
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
			InputMovementSystem inputMovementSystem = new InputMovementSystem(player);
			AIMovementSystem aiMovementSystem = new AIMovementSystem(player);
			CollisionSystem collisionSystem = new CollisionSystem();
			AttackSystem attackSystem = new AttackSystem(player);
			CooldownSystem cooldownSystem = new CooldownSystem();

			drawSystem.AddEntity(player);
			collisionSystem.AddEntity(player);
			cooldownSystem.AddEntity(player);

			for (int i = 0; i < 40; i++)
			{
				var zombie = new Zombie(new Vector2(0 + i * 20, 300));
				drawSystem.AddEntity(zombie);
				aiMovementSystem.AddEntity(zombie);
				collisionSystem.AddEntity(zombie);
				attackSystem.AddEntity(zombie);
				cooldownSystem.AddEntity(zombie);
			}

			for (int i = 0; i < 40; i++)
			{
				var zombie = new Zombie(new Vector2(0 + i * 20, 400));
				drawSystem.AddEntity(zombie);
				aiMovementSystem.AddEntity(zombie);
				collisionSystem.AddEntity(zombie);
				attackSystem.AddEntity(zombie);
				cooldownSystem.AddEntity(zombie);
			}



			// Main game loop
			while (!Raylib.WindowShouldClose())
			{
				float deltaTime = Raylib.GetFrameTime();

				inputMovementSystem.Update(deltaTime);
				aiMovementSystem.Update(deltaTime);
				collisionSystem.Update(deltaTime);
				attackSystem.Update(deltaTime);
				cooldownSystem.Update(deltaTime);	

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
