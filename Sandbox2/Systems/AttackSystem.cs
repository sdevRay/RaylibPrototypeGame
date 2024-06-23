using Raylib_cs;
using RayLibTemplate.Sandbox2.Components;
using RayLibTemplate.Sandbox2.Entites;
using RayLibTemplate.Sandbox2.Entities;
using RayLibTemplate.Sandbox2.Enums;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class AttackSystem : System
	{
		public Entity Player { get; set; }

		private bool _initialAttack = false;

		public AttackSystem(Entity player)
		{
			Player = player;
		}

		public override void Update(float deltaTime)
		{
			var frame = Player.GetComponent<FrameComponent>();
			var state = Player.GetComponent<StateComponent>();

			// Check for space key press to initiate attack
			if (Raylib.IsMouseButtonPressed(MouseButton.Left))
			{
				frame.CurrentFrame = 0;
				frame.IsPlayingForward = true;
				frame.Timer = 0;
				frame.HasCompletedPingPong = false;
				_initialAttack = true;

				state.ChangeState(PlayerStates.MeleeSwing);
			}
			else if (state.Equals(PlayerStates.MeleeSwing))
			{
				if (frame.HasCompletedPingPong)
				{
					// Return to stance state after completing melee swing animation
					state.ChangeState(PlayerStates.Stance);
				}

				if (_initialAttack && frame.CurrentFrame >= 2)
				{
					foreach(var entity in Entities)
					{
						// Check for collision with enemy
						if (entity is Zombie zombie && IsFacingTowardsAndWithinRange(zombie))
						{
							var q = zombie.GetComponent<StateComponent>();
							if (q.Equals(ZombieStates.HitAndDie))
							{
								continue;
							}

							var t = zombie.GetComponent<HealthComponent>();
							var z = Player.GetComponent<AttackComponent>();	
							t.Health -= z.Damage;

							if(t.Health <= 0 && !q.Equals(ZombieStates.HitAndDie))
							{
								q.ChangeState(ZombieStates.HitAndDie);
								var f = zombie.GetComponent<FrameComponent>();
								f.CurrentFrame = 0;
								f.IsPlayingForward = true;
								//Entities.Remove(entity);
							}

							Console.WriteLine("Zombie is within range and facing player");
						}
					}
					
					_initialAttack = false;
				}
			}
		}

		public bool IsFacingTowardsAndWithinRange(Entity otherEntity)
		{
			var otherTransform = otherEntity.GetComponent<TransformComponent>();
			var playerTransform = Player.GetComponent<TransformComponent>();
			var playerAttack = Player.GetComponent<AttackComponent>();

			// Calculate the vector from the player to the zombie
			Vector2 toOther = otherTransform.Position - playerTransform.Position;

			var playerFacingDirection = GetFacingDirectionVector(playerTransform.Direction);

			// Normalize the vectors
			Vector2 normalizedPlayerDirection = Vector2.Normalize(playerFacingDirection);
			Vector2 normalizedToOther = Vector2.Normalize(toOther);

			// Calculate the dot product
			float dotProduct = Vector2.Dot(normalizedPlayerDirection, normalizedToOther);

			// Determine if the player is facing the zombie
			// A dot product of 1 means facing directly towards, 0 means perpendicular, and -1 means opposite directions.
			// You can adjust the threshold based on how strict you want the facing direction check to be.
			bool isFacingTowards = dotProduct > 0.8f; // Example threshold, adjust based on your game's requirements

			// Calculate the distance to the zombie
			float distanceToOther = Vector2.Distance(playerTransform.Position, otherTransform.Position);

			// Check if the zombie is within attack range
			bool isWithinRange = distanceToOther <= playerAttack.AttackRange;

			// The player is facing towards the zombie and within attack range
			return isFacingTowards && isWithinRange;
		}

		public static Vector2 GetFacingDirectionVector(Direction direction)
		{
			switch (direction)
			{
				case Direction.Up:
					return new Vector2(0, -1); // Moving up decreases the Y value in most 2D coordinate systems
				case Direction.Down:
					return new Vector2(0, 1); // Moving down increases the Y value
				case Direction.Left:
					return new Vector2(-1, 0); // Moving left decreases the X value
				case Direction.Right:
					return new Vector2(1, 0); // Moving right increases the X value
				case Direction.UpRight:
					return Vector2.Normalize(new Vector2(1, -1)); // Diagonal movement
				case Direction.UpLeft:
					return Vector2.Normalize(new Vector2(-1, -1)); // Diagonal movement
				case Direction.DownRight:
					return Vector2.Normalize(new Vector2(1, 1)); // Diagonal movement
				case Direction.DownLeft:
					return Vector2.Normalize(new Vector2(-1, 1)); // Diagonal movement
				default:
					return Vector2.Zero; // No movement or an undefined direction
			}
		}
	}
}
