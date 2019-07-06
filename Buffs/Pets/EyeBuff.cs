using Terraria;
using Terraria.ModLoader;

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
            player.GetModPlayer<MagicalPlayer>(mod).IlluminationTriangle = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("IlluminationProj")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("IlluminationProj"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}