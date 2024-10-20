using Raylib_cs;
using RaylibPrototypeGame.Components;
using RaylibPrototypeGame.Entites;
using RaylibPrototypeGame.Systems;
using System.Numerics;

namespace RaylibPrototypeGame
{
	// The game code is implemented here to get a working prototype.

	class Program
	{
		public static int ScreenWidth = 800;

		public static int ScreenHeight = 600;

		static void Main(string[] args)
		{
			// Initialize the Raylib window
			Raylib.InitWindow(ScreenWidth, ScreenHeight, "Raylib C# Prototype");
			Raylib.SetTargetFPS(60);

			var player = new Player();

			DrawSystem drawSystem = new DrawSystem();
			InputMovementSystem inputMovementSystem = new InputMovementSystem(player);
			AIMovementSystem aiMovementSystem = new AIMovementSystem(player);
			CollisionSystem collisionSystem = new CollisionSystem();
			AttackSystem attackSystem = new AttackSystem(player);
			CooldownSystem cooldownSystem = new CooldownSystem();
			AIAttackSystem aIAttackSystem = new AIAttackSystem(player);

			drawSystem.AddEntity(player);
			collisionSystem.AddEntity(player);
			cooldownSystem.AddEntity(player);

			// Variables for the zombie horde spawner
			var zombies = new List<Zombie>();
			var waveIncrement = 2;
			var zombieCount = 4;
			
			// Main game loop
			while (!Raylib.WindowShouldClose())
			{
				float deltaTime = Raylib.GetFrameTime();

				// Zombie horde spawner
				var waveCleared = zombies.All(zombie => zombie.GetComponent<HealthComponent>().IsDead());
				if (waveCleared)
				{
					for (int i = 0; i < zombieCount; i++)
					{
						var zombie = new Zombie(GetRandomPositionOutsideBox());
						drawSystem.AddEntity(zombie);
						aiMovementSystem.AddEntity(zombie);
						collisionSystem.AddEntity(zombie);
						attackSystem.AddEntity(zombie);
						cooldownSystem.AddEntity(zombie);
						aIAttackSystem.AddEntity(zombie);

						zombies.Add(zombie);
					}

					zombieCount *= waveIncrement;
				}

				// System updates
				inputMovementSystem.Update(deltaTime);
				aiMovementSystem.Update(deltaTime);
				collisionSystem.Update(deltaTime);
				attackSystem.Update(deltaTime);
				cooldownSystem.Update(deltaTime);
				aIAttackSystem.Update(deltaTime);

				// End game check
				if (player.GetComponent<HealthComponent>().IsDead()){
					foreach (var zombie in zombies)
					{
						var state = zombie.GetComponent<StateComponent>();
						if (!state.Equals(ZombieStates.HitAndDie) && !state.Equals(ZombieStates.Stance))
						{
							state.ChangeState(ZombieStates.Stance);
						}

						if (zombie.HasComponent<MovementComponent>())
						{
							zombie.RemoveComponent<MovementComponent>();
						}
					}					
				}

				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.RayWhite);

				drawSystem.Update(deltaTime);

				Raylib.EndDrawing();
			}

			// Unload texture and close window
			TextureLoader.UnloadAllTextures();
			Raylib.CloseWindow();
		}

		// Generates a random position outside bounds
		static Vector2 GetRandomPositionOutsideBox()
		{
			var spawnBuffer = 20;
			int randomX, randomY;

			// Decide randomly which side of the box (left, right, top, bottom) the entity will appear
			int side = Raylib.GetRandomValue(0, 3);

			switch (side)
			{
				case 0: // Left of the box
					randomX = Raylib.GetRandomValue(0, -spawnBuffer);
					randomY = Raylib.GetRandomValue(0, ScreenHeight);
					break;
				case 1: // Right of the box
					randomX = Raylib.GetRandomValue(ScreenWidth, ScreenWidth + spawnBuffer);
					randomY = Raylib.GetRandomValue(0, ScreenHeight);
					break;
				case 2: // Above the box
					randomX = Raylib.GetRandomValue(0, ScreenWidth);
					randomY = Raylib.GetRandomValue(0, -spawnBuffer);
					break;
				case 3: // Below the box
					randomX = Raylib.GetRandomValue(0, ScreenWidth);
					randomY = Raylib.GetRandomValue(ScreenHeight, ScreenHeight + spawnBuffer);
					break;
				default:
					randomX = 0;
					randomY = 0;
					break;
			}

			return new Vector2(randomX, randomY);
		}
	}
}
