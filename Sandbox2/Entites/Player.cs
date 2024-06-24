using RayLibTemplate.Sandbox2.Components;
using RayLibTemplate.Sandbox2.Enums;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Entities
{
	record PlayerStateStance(string Name) : IState;
    record PlayerStateRunning(string Name) : IState;
    record PlayerStateMeleeSwing(string Name) : IState;

    internal static class PlayerStates
    {
		public static readonly PlayerStateStance Stance = new PlayerStateStance("Stance");
		public static readonly PlayerStateRunning Running = new PlayerStateRunning("Running");
		public static readonly PlayerStateMeleeSwing MeleeSwing = new PlayerStateMeleeSwing("MeleeSwing");
	}

	internal class Player : Entity
    {
		public Player()
        {
            AddComponent(new TransformComponent() { Position = new Vector2(100, 100) });
            AddComponent(new MovementComponent() { Speed = 150 });
			AddComponent(new StateComponent(PlayerStates.Stance));
            AddComponent(new CollisionComponent() { Radius = 10 });
			AddComponent(new HealthComponent() { Health = 100 });
			AddComponent(new AttackComponent() {  Damage = 25, AttackRange = 50f, Cooldown = 0.5f, CurrentCooldown = 0 });

			AddComponent(new DrawComponent(rowCount: 8, columnCount: 32));
            var draw = GetComponent<DrawComponent>();
            draw.AddSprite("MaleHead1");
            draw.AddSprite("LongSword");
            draw.AddSprite("Clothes");

            AddComponent(new FrameComponent());
            var frame = GetComponent<FrameComponent>();
            frame.AddFrameState(PlayerStates.Stance, new FrameState(4, 0, AnimationType.PingPong));
            frame.AddFrameState(PlayerStates.Running, new FrameState(8, 4, AnimationType.Loop));
            frame.AddFrameState(PlayerStates.MeleeSwing, new FrameState(4, 12, AnimationType.PingPong));
		}
	}
}
