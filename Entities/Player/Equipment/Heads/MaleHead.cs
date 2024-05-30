namespace RayLibTemplate.Entities.Player.Equipment.Heads
{
    internal class MaleHead : AnimatedSprite<PlayerState>, IHead
    {
        public MaleHead(Character<PlayerState> character) : base(rowCount: 32, columnCount: 8, fileName: "Assets/Isometric_Hero/male_head2.png", character)
        {
        }
    }
}
