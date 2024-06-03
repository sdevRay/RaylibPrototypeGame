﻿using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateMeleeSwing : State
	{
		public override float FrameOffSetX => 12;

		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public override Direction Direction { get; set; }

		public override int FrameCount => 4;

		public override void Handle(IGameObject gameObject)
		{
		}
	}
}
