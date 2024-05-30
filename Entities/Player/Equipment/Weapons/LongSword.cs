namespace RayLibTemplate.Entities.Player.Equipment.Weapons
{
    internal class LongSword : AnimatedSprite<PlayerState>, IWeapon
    {
        public LongSword(Character<PlayerState> character) : base(rowCount: 32, columnCount: 8, fileName: "Assets/Isometric_Hero/longsword.png", character)
        {
        }
    }
}
