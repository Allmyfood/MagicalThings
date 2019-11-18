using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.Pets
{
	public class MedicBuff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("The Nurse");
            Description.SetDefault("\"The Nurse will heal you\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MagicalPlayer>().Medic = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.MedicProj>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.MedicProj>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.lifeRegen += 6; //Regeneration
        }
	}
}