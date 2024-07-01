using Raylib_cs;
using RayLibTemplate.Components;
using RayLibTemplate.Entites;
using RayLibTemplate.Extensions;

namespace RayLibTemplate.Systems
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

            if(state.Equals(PlayerStates.HitAndDie))
            {
				return;
			}

            if (Raylib.IsMouseButtonDown(MouseButton.Left) && !state.Equals(PlayerStates.Running))
            {
                if (!state.Equals(PlayerStates.MeleeSwing))
                {
                    frame.CurrentFrame = 0;
                    frame.IsPlayingForward = true;
                    frame.Timer = 0;
                    frame.HasCompletedPingPong = false;
                    _initialAttack = false;

                    state.ChangeState(PlayerStates.MeleeSwing);
                }

                if (frame.IsPlayingForward && frame.CurrentFrame == 2 && _initialAttack == false)
                {
                    _initialAttack = true;

                    foreach (var entity in Entities)
                    {
                        if (entity is Zombie zombie && Player.IsFacingTowardsAndWithinRange(zombie))
                        {
                            if (!(zombie.HasComponent<StateComponent>()
                                && zombie.HasComponent<HealthComponent>()
                                && zombie.HasComponent<FrameComponent>()))
                            {
                                continue;
                            }

                            var zombieState = zombie.GetComponent<StateComponent>();
                            var zombieHealth = zombie.GetComponent<HealthComponent>();
                            var zombieFrame = zombie.GetComponent<FrameComponent>();

                            if (zombieState.Equals(ZombieStates.HitAndDie))
                            {
                                continue;
                            }

                            var playerAttack = Player.GetComponent<AttackComponent>();
							zombieHealth.TakeDamage(playerAttack.Damage);
							
                            if (zombieHealth.IsDead() && !zombieState.Equals(ZombieStates.HitAndDie))
                            {
                                zombieState.ChangeState(ZombieStates.HitAndDie);

                                zombieFrame.CurrentFrame = 0;
                                zombieFrame.IsPlayingForward = true;
                            }
                        }

                    }
                }

                if (frame.HasCompletedPingPong)
                {
                    _initialAttack = false;
                    frame.HasCompletedPingPong = false;
                }
            }
            else
            {
                if (state.Equals(PlayerStates.MeleeSwing))
                {
                    state.ChangeState(PlayerStates.Stance);
                }
            }
        }
    }
}
