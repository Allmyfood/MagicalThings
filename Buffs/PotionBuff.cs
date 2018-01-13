using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace MagicalThings.Buffs
{
    public class PotionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Potion of Strangness");
            Description.SetDefault("Incresed defense by 100, life regen, melee damage and inferno buff");
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {                                             //
            player.AddBuff(mod.BuffType("BuffName"), 1); //this is an example of how to add your own buff
            player.AddBuff(BuffID.Inferno, 2);  //this is an example of how to add existing buff
            player.statDefense += 100;  // this is how to add a stat
        }
        public bool unityMouseOver;
        }
    }