using Raylib_cs;
using RayLibTemplate.Sandbox.GameObjects.Characters;

namespace RayLibTemplate.Sandbox.GameObjects
{
	internal class OneShotSpriteAnimator : SpriteAnimator
	{
		public bool IsAnimationFinished { get; private set; } = false;

		public OneShotSpriteAnimator(Character character) : base(character)
		{
		}

		public override void Update()
		{
			_timer += Raylib.GetFrameTime();

			if (_timer >= _frameTime)
			{
				_timer = 0;
				if (_currentFrame < Character.CurrentState.FrameCount - 1) // Only increment frame if it's not the last one
				{
					_currentFrame += 1;
				}
				else
				{
					IsAnimationFinished = true;
				}
			}
		}
	}
}
