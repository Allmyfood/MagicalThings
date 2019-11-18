using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.SodaBuffs
{
    public class BlueberryLimeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blueberry-Lime Soda");
            Description.SetDefault("Combines Gills, Fishing, and Flipper potions");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.gills = true;
            player.fishingSkill += 15;
            player.accFlipper = true;
            //player.GetModPlayer<MagicalPlayer>().SurgeBuff = true; //example of using a custom buff in the ModPlayer section.
        }
    }
}