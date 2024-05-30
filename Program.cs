using Raylib_cs;
using RayLibTemplate.Entities.Enemies.Zombie;
using RayLibTemplate.Entities.Player;

namespace RayLibTemplate
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialize the Raylib window
			Raylib.InitWindow(800, 600, "Raylib C# Prototype");
			Raylib.SetTargetFPS(60);


			var entityManager = new EntityManager();
			entityManager.AddEntity(new Player());
			entityManager.AddEntity(new Zombie());

			// Main game loop
			while (!Raylib.WindowShouldClose())
			{
				entityManager.UpdateEntities();

				// Drawing
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.RayWhite);

				entityManager.DrawEntities();

				Raylib.EndDrawing();
			}

			// Unload texture and close window
			entityManager.UnloadEntities();

			Raylib.CloseWindow();
		}
	}
}
