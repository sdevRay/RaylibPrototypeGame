namespace RayLibTemplate
{
	internal class LeatherArmor : AnimatedSprite, IArmor
	{
		public LeatherArmor(Character character) : base(rowCount: 32, columnCount: 8, fileName: "Assets/Isometric_Hero/leather_armor.png", character)
		{
		}
	}
}
