using Raylib_cs;
using RayLibTemplate.Sandbox2.Enums;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
    internal class PlayerStateRunning : State
	{
		public override float FrameOffSetX => 4;

		public override int FrameCount => 8;

		readonly int _speed = 2;

        public PlayerStateRunning(Character character) : base(character, new SpriteAnimator(character))
        {
			Console.WriteLine("PlayerStateRunning");
        }

        public override void Update()
		{
			if (Input.TryGetMousesButtonDown(out MouseButton mouseButton))
			{
				if (mouseButton == MouseButton.Left)
				{
					Character.TransitionToState(new PlayerStateMeleeSwing(Character));
				}
				else if (mouseButton == MouseButton.Right)
				{
					Character.TransitionToState(new PlayerStateBlock(Character));
				}
			}

			Input.GetDirectionalMovement(out Direction direction, out Vector2 movement);
			if (movement != Vector2.Zero)
			{
				Character.Direction = direction;
				((IGameObject)Character).Position += movement * _speed;
			}
			else
			{
				Character.TransitionToState(new PlayerStateStance(Character));
			}

			base.Update();
		}
	}
}
