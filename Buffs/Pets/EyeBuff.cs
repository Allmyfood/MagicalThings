using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.Pets
{
	public class EyeBuff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Illuminating Light");
            Description.SetDefault("\"A strange triangle lights the way\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.nightVision = true;
            player.dangerSense = true;
            player.detectCreature = true;
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MagicalPlayer>().IlluminationTriangle = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.IlluminationProj>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, ProjectileType<Projectiles.Pets.IlluminationProj>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}