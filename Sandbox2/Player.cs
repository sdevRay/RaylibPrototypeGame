using Raylib_cs;
using RayLibTemplate.Sandbox2.Components;
using System.Numerics;

namespace RayLibTemplate.Sandbox2
{
	internal class Player : GameObject
	{
		public Player()
		{
			AddComponent(new TransformComponent(new Vector2(100, 100)));
			AddComponent(new DrawComponent("Assets/Player/leather_armor.png"));
			AddComponent(new PlayerMovementComponent(100));
		}
	}
}
