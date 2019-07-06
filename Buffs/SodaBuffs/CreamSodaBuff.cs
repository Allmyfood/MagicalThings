using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.SodaBuffs
{
    public class CreamSodaBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cream Soda");
            Description.SetDefault("Combines Featherfall, Ironskin, and Spelunker potions");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.slowFall = true;
            player.findTreasure = true;
            player.statDefense += 8;
        }
    }
}