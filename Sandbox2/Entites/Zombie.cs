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
	}

	internal class Zombie : Entity
	{
		public Zombie(Vector2 position)
		{
			AddComponent(new TransformComponent(position: position));
			AddComponent(new MovementComponent(speed: 75));
			AddComponent(new StateComponent(ZombieStates.Stance));
			AddComponent(new AIComponent(aggroDistance: 100));
			AddComponent(new CollisionComponent(radius: 10f));

			AddComponent(new DrawComponent(rowCount: 8, columnCount: 36));
			var draw = GetComponent<DrawComponent>();
			draw.AddSprite("Zombie");

			AddComponent(new FrameComponent());
			var frame = GetComponent<FrameComponent>();
			frame.AddFrameState(ZombieStates.Stance, new FrameState(4, 0, AnimationType.PingPong));
			frame.AddFrameState(ZombieStates.Lurch, new FrameState(8, 4, AnimationType.Loop));
		}
	}
}
