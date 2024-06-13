using RayLibTemplate.Sandbox2.Components;
using System.Numerics;

namespace RayLibTemplate.Sandbox2
{
	internal class Player : GameObject
	{
		public Player()
		{
			AddComponent(new TransformComponent(new Vector2(100, 100)));
			AddComponent(new DrawComponent("Assets/Player/leather_armor.png", rowCount: 8, columnCount: 32));
			AddComponent(new MovementComponent(100));
			AddComponent(new StateComponent<PlayerState>(PlayerState.Stance));
			AddComponent(new FrameComponent());

			var frame = GetComponent<FrameComponent>();
			frame.AddFrameState(PlayerState.Stance, new FrameState(4, 0));
			frame.AddFrameState(PlayerState.Running, new FrameState(8, 4));
		}
	}
}
