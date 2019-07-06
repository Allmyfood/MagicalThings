using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.SodaBuffs
{
    public class SuicideSodaBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Suicide Soda");
            Description.SetDefault("Combines all Sodas; 25% chance to kill the player"
                + "\nYou survived the Suicide!");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {       
                #region MelonBlast Buff
                player.ammoPotion = true;
                player.meleeDamage += 0.20f; //Wrath is Melee, Magic, Thrown, Ranged, and Minion damage by 10% no crits.
                player.magicDamage = 0.1f;
                player.thrownDamage = 0.1f;
                player.rangedDamage = 0.1f;
                player.minionDamage = 0.1f;
                player.lifeRegen += 4; //Regeneration
                if (player.thorns < 1.0)
                {
                    player.thorns = 0.333333f;
                }
                #endregion
                #region Surge Buff
                player.moveSpeed += 0.25f;
                //player.meleeDamage += 0.10f; //combined to 20% wozer!
                player.meleeCrit += 2;
                player.maxMinions += 1;
                player.lifeForce = true;
                player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
                player.GetModPlayer<MagicalPlayer>(mod).SurgeBuff = true;
                #endregion
                #region CreamSodaBuff
                player.slowFall = true;
                player.findTreasure = true;
                player.statDefense += 8;
                #endregion
                #region BlueberryLime Buff
                player.gills = true;
                player.fishingSkill += 15;
                player.accFlipper = true;
                #endregion
                #region GrapeOrange Buff
                player.fireWalk = true;
                player.lavaImmune = true;
                player.waterWalk = true;
                player.waterWalk2 = true;
                #endregion
                #region OrangeTwist Buff
                player.tileSpeed += 0.25f;
                player.wallSpeed += 0.25f;
                player.pickSpeed -= 0.25f;
                ++player.blockRange;
                //player.calmed = true; //Ha not that easy
                Lighting.AddLight((int)(player.position.X + (double)(player.width / 2)) / 16, (int)(player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
                player.nightVision = true;
                #endregion
        }
    }
}