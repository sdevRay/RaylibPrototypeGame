using Raylib_cs;
using RayLibTemplate.Sandbox.GameObjects.Characters;

namespace RayLibTemplate.Sandbox.GameObjects
{
	internal class PingPongSpriteAnimator : SpriteAnimator
	{
		bool _isPlayingForward = true;

		public PingPongSpriteAnimator(Character character) : base(character)
		{
		}

		public override void Update()
		{
			_timer += Raylib.GetFrameTime();

			if (_timer >= _frameTime)
			{
				_timer = 0;

				if (_isPlayingForward)
				{
					_currentFrame++;
					if (_currentFrame >= Character.CurrentState.FrameCount - 1)
					{
						_isPlayingForward = false;
					}
				}
				else
				{
					_currentFrame--;
					if (_currentFrame <= 0)
					{
						_isPlayingForward = true;
					}
				}

				_currentFrame = Math.Clamp(_currentFrame, 0, Character.CurrentState.FrameCount - 1);
			}
		}
	}
}
