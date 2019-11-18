using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
 
namespace MagicalThings.Buffs
{
    public class PotionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Potion of Strangness");
            Description.SetDefault("Incresed defense by 100, life regen, melee damage and inferno buff");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {                                             //
            //player.AddBuff(mod.BuffType("BuffName"), 1); //this is an example of how to add your own buff
            player.AddBuff(BuffID.Inferno, 2);  //this is an example of how to add existing buff
            player.statDefense += 100;  // this is how to add a stat
            player.nightVision = true;
            Lighting.AddLight((int)(player.position.X + (double)(player.width / 2)) / 16, (int)(player.position.Y + (double)(player.height / 2)) / 16, 5.8f, 5.95f, 6f); //default 0.8f, 0.95f, 1f
            player.lifeRegen += 1;
            player.meleeDamage += 2;
        }
        public bool unityMouseOver;
        }
    }