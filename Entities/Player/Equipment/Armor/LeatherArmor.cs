namespace RayLibTemplate.Entities.Player.Equipment.Armor
{
    internal class LeatherArmor : AnimatedSprite<PlayerState>, IArmor
    {
        public LeatherArmor(Character<PlayerState> character) : base(rowCount: 32, columnCount: 8, fileName: "Assets/Isometric_Hero/leather_armor.png", character)
        {
        }
    }
}
