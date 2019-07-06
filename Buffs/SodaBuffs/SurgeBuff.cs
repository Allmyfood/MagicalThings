using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.SodaBuffs
{
    public class SurgeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Surge Soda");
            Description.SetDefault("Combines Swiftness, Summoning, Lifeforce, Cursed Flames and Flask of Fire potions");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {                                             //
            //player.AddBuff(mod.BuffType("BuffName"), 1); //this is an example of how to add your own buff
            //player.AddBuff(BuffID.ObsidianSkin, 2);  //this is an example of how to add existing buff
            //player.AddBuff(BuffID.WaterWalking, 2); //this is the way to add the buffs themselves use player."effect" to add only the effect and not the actual buff.
            player.moveSpeed += 0.25f;
            player.meleeDamage += 0.10f;
            player.meleeCrit += 2;
            player.maxMinions += 1;
            player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
            player.GetModPlayer<MagicalPlayer>(mod).SurgeBuff = true;
            //player.AddBuff(BuffID.WeaponImbueCursedFlames, 600);
        }
    }
}