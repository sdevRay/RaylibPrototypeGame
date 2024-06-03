using RayLibTemplate.Sandbox.GameObjects.Characters.Player.States;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player
{
	internal class PlayerCharacter : Character, IGameObject
	{
		public override AnimatedSprite AnimatedSprite { get; set; }

		public override State State { get; set; }

		public override int Speed { get; set; }

		public Vector2 Position { get; set; }

		public PlayerCharacter()
		{
			State = new State(new PlayerStateRunning());
			AnimatedSprite = new PlayerAnimatedSprite(this);
			Speed = 1;
		}

		public void Draw()
		{
			AnimatedSprite.Animate(this);
		}

		public void Update()
		{
			State.Request();
		}
	}
}
