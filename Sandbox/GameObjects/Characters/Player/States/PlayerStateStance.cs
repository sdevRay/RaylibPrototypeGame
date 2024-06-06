using Raylib_cs;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateStance : State
	{
		public override float FrameOffSetX => 0;

		public override int FrameCount => 4;

		public PlayerStateStance(Character character) : base(character, new OneShotSpriteAnimator(character))
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
			}

			if (Input.IsDirectionalKeyDown(Raylib.GetKeyPressed()))
			{
				Character.TransitionToState(new PlayerStateRunning(Character));
			}

			base.Update();
		}
	}
}
