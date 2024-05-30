namespace RayLibTemplate
{
	internal class MaleHead : AnimatedSprite, IHead
	{
		public MaleHead(Character character) : base(rowCount: 32, columnCount: 8, fileName: "Assets/Isometric_Hero/male_head2.png", character)
		{
		}
	}
}
