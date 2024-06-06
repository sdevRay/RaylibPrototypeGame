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
