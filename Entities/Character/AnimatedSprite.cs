using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate.Entities.Character.Character
{
	public class AnimatedSprite : IAnimatedSprite
	{
		Texture2D SpriteSheet { get; set; }
		ICharacterSprite CharacterSprite { get; set; }

		// Sprite Sheet
		readonly int _rowCount;
		readonly int _columnCount;
		readonly int _frameWidth;
		readonly int _frameHeight;
		readonly Vector2 _origin;

		// Frames
		readonly float _frameTime = 0.1f; // Time per frame
		int _currentFrame = 0;
		float _timer = 0;

		public AnimatedSprite(int rowCount, int columnCount, string fileName, ICharacterSprite characterSprite)
		{
			SpriteSheet = Raylib.LoadTexture(fileName);
			_rowCount = rowCount;
			_columnCount = columnCount;

			_frameWidth = SpriteSheet.Width / _columnCount;
			_frameHeight = SpriteSheet.Height / _rowCount;
			_origin = new Vector2(_frameWidth / 2, _frameHeight / 2);

			CharacterSprite = characterSprite;
		}

		public void UpdateSprite()
		{
			_timer += Raylib.GetFrameTime();

			if (_timer >= _frameTime)
			{
				_timer = 0;
				_currentFrame = (_currentFrame + 1) % CharacterSprite.GetFrameCount(); // Loop through frames
			}
		}

		public void DrawSprite()
		{
			Rectangle sourceRec = new((_currentFrame + CharacterSprite.GetFrameOffSet().X) * _frameWidth, _frameHeight * CharacterSprite.GetFrameOffSet().Y, _frameWidth, _frameHeight);

			Rectangle destRec = new(CharacterSprite.GameCharacter.Position.X, CharacterSprite.GameCharacter.Position.Y, _frameWidth, _frameHeight);
			Raylib.DrawTexturePro(SpriteSheet, sourceRec, destRec, _origin, 0, Color.White);
		}

		public void UnloadSprite()
		{
			Raylib.UnloadTexture(SpriteSheet);
		}
	}
}
