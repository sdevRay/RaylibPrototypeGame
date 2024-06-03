using RayLibTemplate.Sandbox.GameObjects.Characters.Player.States;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player
{
	internal class PlayerCharacter : Character, IGameObject
	{
		public override AnimatedSprite AnimatedSprite { get; set; }

		public override StateContext StateContext { get; set; }

		public Vector2 Position { get; set; }

		public PlayerCharacter()
		{
			StateContext = new StateContext(new PlayerStateRunning());
			AnimatedSprite = new PlayerAnimatedSprite(this);
		}

		public void Draw()
		{
			AnimatedSprite.Animate(this);
		}

		public void Update()
		{
			StateContext.Request(this);
		}
	}
}
