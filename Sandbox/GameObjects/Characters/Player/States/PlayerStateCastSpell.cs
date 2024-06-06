using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateCastSpell : State
	{
		public override float FrameOffSetX => 24;

		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(_stateContext.Character.Direction));

		public override int FrameCount => 4;

		public override AnimatedSprite AnimatedSprite => throw new NotImplementedException();

		public override int CurrentFrame { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override void Draw()
		{
			throw new NotImplementedException();
		}

		public override void Update()
		{
			throw new NotImplementedException();
		}
	}
}
