using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate.Entities
{
    public abstract class AnimatedSprite<TState> : IDraw, IUpdate, IUnload
    {
        public Character<TState> Character { get; set; }
        public Texture2D SpriteSheet { get; set; }

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

        protected AnimatedSprite(int rowCount, int columnCount, string fileName, Character<TState> character)
        {
            SpriteSheet = Raylib.LoadTexture(fileName);
            _rowCount = rowCount;
            _columnCount = columnCount;

            _frameWidth = SpriteSheet.Width / _rowCount;
            _frameHeight = SpriteSheet.Height / _columnCount;
            _origin = new Vector2(_frameWidth / 2, _frameHeight / 2);

            Character = character;
        }

        public void Update()
        {
            _timer += Raylib.GetFrameTime();

            if (_timer >= _frameTime)
            {
                _timer = 0;
                _currentFrame = (_currentFrame + 1) % Character.GetFrameCount(); // Loop through frames
            }
        }

        public void Draw()
        {
            Rectangle sourceRec = new((_currentFrame + Character.GetFrameOffSet().X) * _frameWidth, _frameHeight * Character.GetFrameOffSet().Y, _frameWidth, _frameHeight);
            Rectangle destRec = new(Character.Position.X, Character.Position.Y, _frameWidth, _frameHeight);
            Raylib.DrawTexturePro(SpriteSheet, sourceRec, destRec, _origin, 0, Color.White);
        }

        public void Unload()
        {
            Raylib.UnloadTexture(SpriteSheet);
        }

    }
}
