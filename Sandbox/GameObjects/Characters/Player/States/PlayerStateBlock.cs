using Raylib_cs;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateBlock : State
	{
		public override float FrameOffSetX => 16;

		public override int FrameCount => 2;

		public PlayerStateBlock(Character character) : base(character, new OneShotSpriteAnimator(character))
		{
		}

		public override void Update()
		{
			if (Input.TryGetMousesButtonDown(out MouseButton mouseButton))
			{
				if (mouseButton == MouseButton.Left)
				{
					Character.TransitionToState(new PlayerStateMeleeSwing(Character));
				}
			}

			if (Input.IsDirectionalKeyPressed())
			{
				Character.TransitionToState(new PlayerStateRunning(Character));
			}

			if (SpriteAnimator is OneShotSpriteAnimator oneShotSpriteAnimator && oneShotSpriteAnimator.IsAnimationFinished)
			{
				// Stay in block state until user input state change
			}

			base.Update();
		}
	}
}
