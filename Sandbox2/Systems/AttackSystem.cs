using Raylib_cs;
using RayLibTemplate.Sandbox2.Components;
using RayLibTemplate.Sandbox2.Entites;
using RayLibTemplate.Sandbox2.Entities;
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
			var attack = Player.GetComponent<AttackComponent>();
			var frame = Player.GetComponent<FrameComponent>();
			var state = Player.GetComponent<StateComponent>();

			// Check for space key press to initiate attack
			if (Raylib.IsKeyPressed(KeyboardKey.Space))
			{
				frame.CurrentFrame = 0;
				frame.IsPlayingForward = true;
				frame.Timer = 0;
				frame.HasCompletedPingPong = false;
				_initialAttack = true;
				state.ChangeState(PlayerStates.MeleeSwing);
			}
			else if (state.CurrentState.Equals(PlayerStates.MeleeSwing))
			{
				if (frame.HasCompletedPingPong)
				{
					// Return to stance state after completing melee swing animation
					state.ChangeState(PlayerStates.Stance);
				}
				else if(frame.CurrentFrame == 2 && _initialAttack)
				{
					// Check if the player is attacking
					foreach (var entity in Entities)
					{
						if (entity is Zombie zombie && IsTargetInFront(zombie) && zombie.HasComponent<HealthComponent>())
						{
							_initialAttack = false;
							var enemyHealth = zombie.GetComponent<HealthComponent>();

							// Attack the enemy
							enemyHealth.Health -= attack.Damage;

							if (enemyHealth.Health <= 0)
							{
								// Enemy is dead
								var enemyState = entity.GetComponent<StateComponent>();
								enemyState.ChangeState(ZombieStates.HitAndDie);

								var enemyFrame = entity.GetComponent<FrameComponent>();	
								enemyFrame.CurrentFrame = 0;
								enemyFrame.Timer = 0;

								zombie.Destroy();
								//entity.RemoveComponent<AIComponent>();

								Console.WriteLine("Enemy is dead.");
							}

							Console.WriteLine($"Player attacked enemy for {attack.Damage} damage. Enemy health: {enemyHealth.Health}");
						}
					}
				}
			}
		}

		public bool IsTargetInFront(Entity target)
		{
			var transform = Player.GetComponent<TransformComponent>();
			var attack = Player.GetComponent<AttackComponent>();

			var targetTransform = target.GetComponent<TransformComponent>();

			if (transform == null || targetTransform == null)
				return false;

			Vector2 toTarget = targetTransform.Position - transform.Position;
			float distanceToTarget = toTarget.Length();
			if (distanceToTarget > attack.AttackRange)
			{
				return false;
			}

			toTarget = Vector2.Normalize(toTarget);
			float dotProduct = Vector2.Dot(transform.FacingDirection, toTarget);
			return dotProduct > 0.90f;
		}
	}
}
