using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.SodaBuffs
{
    public class GrapeOrangeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Grape-Orange Soda");
            Description.SetDefault("Combines Obsidian Skin and Water Walking potions");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {                                             //
            //player.AddBuff(mod.BuffType("BuffName"), 1); //this is an example of how to add your own buff
            //player.AddBuff(BuffID.ObsidianSkin, 2);  //this is an example of how to add existing buff
            //player.AddBuff(BuffID.WaterWalking, 2); //this is the way to add the buffs them selves use player."effect" to add only the effect and not the actual buff.
            player.fireWalk = true;
            player.lavaImmune = true;
            player.waterWalk = true;
            player.waterWalk2 = true;
            //}
            //public bool unityMouseOver;
            //}
        }
    }
}