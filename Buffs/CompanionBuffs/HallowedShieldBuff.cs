using Terraria;
using Terraria.ModLoader;
using MagicalThings.Items.Companion.Mage.Tier9;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class HallowedShieldBuff : ModBuff
	{
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Hallowed Protection");
			Description.SetDefault("A magic shield grants defence" + "\nWill shoot at enemies" + "\nOuter ring will deal damage to enemies");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.statDefense += 30;
            if (!player.HasBuff(mod.BuffType("VortexShieldBuff")))
            {
                player.AddBuff(mod.BuffType("HallowedShieldBuff"), 2);
                if (player.ownedProjectileCounts[mod.ProjectileType("SpectralRingProj")] <= 0)
                {
                    Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("SpectralRingProj"), 90, 13, player.whoAmI);
                    Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("HallowedShieldProj"), 0, 0, player.whoAmI);
                }
            }
        }
	}
}