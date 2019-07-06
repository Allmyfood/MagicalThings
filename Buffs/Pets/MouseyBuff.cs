using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.Pets
{
	public class MouseyBuff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Mouse Pet");
            Description.SetDefault("\"A little mouse is happily following you\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.nightVision = true;
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MagicalPlayer>(mod).MousePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("MousePetProj")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("MousePetProj"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}