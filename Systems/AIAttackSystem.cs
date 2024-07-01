using RayLibTemplate.Components;
using RayLibTemplate.Entites;
using RayLibTemplate.Extensions;

namespace RayLibTemplate.Systems
{
	internal class AIAttackSystem : System
	{
		public Entity Player { get; set; }

		private bool _initialAttack = false;

		public AIAttackSystem(Entity player)
		{
			Player = player;
		}

		public override void Update(float deltaTime)
		{
			foreach (var entity in Entities)
			{
				if (!entity.HasComponent<StateComponent>() || !entity.HasComponent<FrameComponent>())
					continue;

				var state = entity.GetComponent<StateComponent>();

				if (state.Equals(ZombieStates.HitAndDie))
				{
					continue;
				}

				var frame = entity.GetComponent<FrameComponent>();

				if (entity.IsFacingTowardsAndWithinRange(Player))
				{
					if (!state.Equals(ZombieStates.Slam))
					{
						state.ChangeState(ZombieStates.Slam);

						frame.CurrentFrame = 0;
						frame.IsPlayingForward = true;
						frame.Timer = 0;
						frame.HasCompletedPingPong = false;
						_initialAttack = false;
					}
					else if (frame.IsPlayingForward && frame.CurrentFrame == 2 && !_initialAttack)
					{
						_initialAttack = true;

						var playerHealth = Player.GetComponent<HealthComponent>();
						var attack = entity.GetComponent<AttackComponent>();

						playerHealth.TakeDamage(attack.Damage);

						if (playerHealth.IsDead())
						{
							var playerState = Player.GetComponent<StateComponent>();
							if (!playerState.Equals(PlayerStates.HitAndDie))
							{
								playerState.ChangeState(PlayerStates.HitAndDie);
							}
						}
					}

					if (frame.HasCompletedPingPong)
					{
						_initialAttack = false;
						frame.HasCompletedPingPong = false;
					}
				}
			}
		}
	}
}
