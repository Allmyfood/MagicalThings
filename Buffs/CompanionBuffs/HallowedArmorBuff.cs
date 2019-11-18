using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class HallowedArmorBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hallowed Shield");
			Description.SetDefault("A magic shield grants defence" + "\nWill shoot at enemies");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.statDefense += 30;
            if (!player.HasBuff(mod.BuffType("VortexShieldBuff")))
            {
                if (!player.HasBuff(mod.BuffType("HallowedShieldBuff")))
                {
                    player.AddBuff(mod.BuffType("HallowedArmorBuff"), 2);
                    if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Mage.HallowedShieldProj>()] <= 0)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ProjectileType<Projectiles.CompanionProj.Mage.HallowedShieldProj>(), 0, 0, player.whoAmI);
                    }
                }
            }
        }
	}
}