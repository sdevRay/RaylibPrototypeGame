﻿using RayLibTemplate.Entities.Character;
using RayLibTemplate.Entities.Character.Character;
using RayLibTemplate.Entities.Player.Equipment;
using System.Numerics;

namespace RayLibTemplate.Entities.Player.Sprites
{
    internal class WeaponSprite : ICharacterSprite, IWeapon
    {
        public AnimatedSpriteManager AnimatedSpriteManager { get; set; } = new AnimatedSpriteManager();
        public GameCharacter GameCharacter { get; set; }
        public WeaponSprite(GameCharacter gameCharacter)
        {
            var sprite = new AnimatedSprite(rowCount: 8, columnCount: 32, "Assets/Isometric_Hero/longsword.png", this);
            AnimatedSpriteManager.AddSprite(sprite);
            GameCharacter = gameCharacter;
        }

        public void Animate()
        {
            AnimatedSpriteManager.UpdateSprites();
            AnimatedSpriteManager.DrawSprites();
        }

        public void UnloadSprites()
        {
            AnimatedSpriteManager.UnloadSprites();
        }

        public Vector2 GetFrameOffSet()
        {
            return PlayerSpriteBase.GetFrameOffSet(GameCharacter);
        }

        public int GetFrameCount()
        {
            return PlayerSpriteBase.GetFrameCount(GameCharacter);
        }
    }
}
