using Raylib_cs;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateMeleeSwing : State
	{
		public override float FrameOffSetX => 12;

		public override int FrameCount => 4;

		public PlayerStateMeleeSwing(Character character) : base(character, new OneShotSpriteAnimator(character))
		{
			Console.WriteLine("PlayerStateMeleeSwing");
		}

		public override void Update()
		{
			if (Input.IsDirectionalKeyDown(Raylib.GetKeyPressed()))
			{
				Character.TransitionToState(new PlayerStateRunning(Character));
			}

			if (SpriteAnimator is OneShotSpriteAnimator oneShotSpriteAnimator && oneShotSpriteAnimator.IsAnimationFinished)
			{
				Character.TransitionToState(new PlayerStateStance(Character));
			}

			base.Update();
		}
	}
}
