﻿using Raylib_cs;

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

			// Main game loop
			while (!Raylib.WindowShouldClose())
			{

				player.Update();

				// Drawing
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.RayWhite);

				player.Draw();


				Raylib.EndDrawing();
			}

			// Unload texture and close window
			player.Unload();
			Raylib.CloseWindow();
		}
	}
}
