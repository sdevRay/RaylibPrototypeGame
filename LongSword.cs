namespace RayLibTemplate
{
	internal class LongSword : AnimatedSprite, IWeapon
	{
		public LongSword(Character character) : base(rowCount: 32, columnCount: 8, fileName: "Assets/Isometric_Hero/longsword.png", character)
		{
		}
	}
}
