using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.SodaBuffs
{
    public class MelonBlastBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Melon Blast Soda");
            Description.SetDefault("Combines Ammo Reservation, Wrath, Regeneration, and Thorns potions");
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.ammoPotion = true;
            player.meleeDamage += 0.1f; //Wrath is Melee, Magic, Thrown, Ranged, and Minion damage by 10% no crits.
            player.magicDamage= 0.1f;
            player.thrownDamage= 0.1f;
            player.rangedDamage= 0.1f;
            player.minionDamage= 0.1f;
            player.lifeRegen += 4; //Regeneration
            if (player.thorns < 1.0)
            {
                player.thorns = 0.333333f;
            }
        }
    }
}