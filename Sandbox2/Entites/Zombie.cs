using RayLibTemplate.Sandbox2.Components;
using RayLibTemplate.Sandbox2.Enums;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Entites
{
    record ZombieStateStance(string Name) : IState;
	record ZombieStateLurch(string Name) : IState;

	internal static class ZombieStates
	{
		public static readonly ZombieStateStance Stance = new ZombieStateStance("Stance");
		public static readonly ZombieStateLurch Lurch = new ZombieStateLurch("Lurch");
		public static readonly ZombieStateLurch HitAndDie = new ZombieStateLurch("HitAndDie");
	}

	internal class Zombie : Entity
	{
		public Zombie(Vector2 position)
		{
			AddComponent(new TransformComponent() { Position = position });
			AddComponent(new MovementComponent() { Speed = 25 });
			AddComponent(new StateComponent(ZombieStates.Stance));
			AddComponent(new AIComponent() { AggroDistance = 100 });
			AddComponent(new CollisionComponent() { Radius = 10 });
			AddComponent(new HealthComponent() { Health = 100 });
			AddComponent(new AttackComponent() { AttackRange = 20 });

			AddComponent(new DrawComponent(rowCount: 8, columnCount: 36));
			var draw = GetComponent<DrawComponent>();
			draw.AddSprite("Zombie");

			AddComponent(new FrameComponent());
			var frame = GetComponent<FrameComponent>();
			frame.AddFrameState(ZombieStates.Stance, new FrameState(4, 0, AnimationType.PingPong));
			frame.AddFrameState(ZombieStates.Lurch, new FrameState(8, 4, AnimationType.Loop));
			frame.AddFrameState(ZombieStates.HitAndDie, new FrameState(6, 22, AnimationType.SingleShot));
		}

		public void Destroy()
		{
			RemoveComponent<AIComponent>();
			RemoveComponent<MovementComponent>();
			RemoveComponent<AttackComponent>();
			RemoveComponent<HealthComponent>();
		}
	}
}
