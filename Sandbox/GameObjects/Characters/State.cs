using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	public abstract class State
    {
		public Character Character { get; }

		public SpriteAnimator SpriteAnimator { get; }

		protected State(Character character, SpriteAnimator spriteAnimator)
		{
			Character = character;
			SpriteAnimator = spriteAnimator;
		}

		public abstract float FrameOffSetX { get; }

		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, SpriteAnimator.GetFrameOffSetY(Character.Direction));

		public abstract int FrameCount { get; }

		public virtual void Update()
		{
			SpriteAnimator.Update();
		}

		public void Draw()
		{
			SpriteAnimator.Draw();
		}
	}
}
