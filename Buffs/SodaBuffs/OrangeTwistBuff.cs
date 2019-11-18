using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.SodaBuffs
{
    public class OrangeTwistBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Orange-Twist Soda");
            Description.SetDefault("Combines Builders, Shine, Night Owl, Mining, and Calming potions");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            player.pickSpeed -= 0.25f;
            ++player.blockRange;
            player.calmed = true;
            Lighting.AddLight((int)(player.position.X + (double)(player.width / 2)) / 16, (int)(player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
            player.nightVision = true;
        }
    }
}