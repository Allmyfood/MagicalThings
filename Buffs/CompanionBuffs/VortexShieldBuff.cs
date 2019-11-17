using Terraria;
using Terraria.ModLoader;
using MagicalThings.Items.Companion.Mage.Tier10;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class VortexShieldBuff : ModBuff
	{
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Vortex Protection");
			Description.SetDefault("An upgraded magic shield grants defence" + "\nWill shoot at enemies" + "\nOuter ring will deal damage to enemies");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.statDefense += 60;
            player.AddBuff(mod.BuffType("VortexShieldBuff"), 2);
            if (player.ownedProjectileCounts[mod.ProjectileType("VortexShieldProj")] <= 0)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("SpectralRingProj"), 90, 13, player.whoAmI);
                Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("VortexShieldProj"), 0, 0, player.whoAmI);
            }
        }
	}
}