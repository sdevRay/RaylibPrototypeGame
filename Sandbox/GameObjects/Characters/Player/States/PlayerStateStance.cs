using Raylib_cs;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateStance : State
	{
		public override float FrameOffSetX => 0;

		public override int FrameCount => 4;

		public PlayerStateStance(Character character) : base(character, new PingPongSpriteAnimator(character))
		{
			Console.WriteLine("PlayerStateStance");
		}

		public override void Update()
		{
			if (Input.TryGetMousesButtonDown(out MouseButton mouseButton))
			{
				if(mouseButton == MouseButton.Left)
				{
					Character.TransitionToState(new PlayerStateMeleeSwing(Character));
				}
				else if(mouseButton == MouseButton.Right)
				{
					Character.TransitionToState(new PlayerStateBlock(Character));
				}
			}
			if (Input.IsDirectionalKeyDown()/* || Input.IsDirectionalKeyPressed()*/)
			{
				Character.TransitionToState(new PlayerStateRunning(Character));
			}

			base.Update();
		}
	}
}
