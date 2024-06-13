using Raylib_cs;
using RayLibTemplate.Sandbox;
using RayLibTemplate.Sandbox2;
using RayLibTemplate.Sandbox2.Systems;

namespace RayLibTemplate
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialize the Raylib window
			Raylib.InitWindow(800, 600, "Raylib C# Prototype");
			Raylib.SetTargetFPS(60);

			DrawSystem drawSystem = new DrawSystem();
			MovementSystem movementSystem = new MovementSystem();

			var player = new Player();
			drawSystem.AddGameObject(player);
			movementSystem.AddGameObject(player);

			// Main game loop
			while (!Raylib.WindowShouldClose())
			{
				float deltaTime = Raylib.GetFrameTime();

				movementSystem.Update(deltaTime);

				// Drawing
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.RayWhite);
				
				drawSystem.Update(deltaTime);

				Raylib.EndDrawing();
			}

			// Unload texture and close window
			drawSystem.UnloadTextures();

			Raylib.CloseWindow();
		}
	}
}
