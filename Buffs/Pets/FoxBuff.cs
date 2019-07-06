using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.Pets
{
	public class FoxBuff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Fox Pet");
            Description.SetDefault("\"A little fox is happily following you\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MagicalPlayer>(mod).FoxPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("FoxPetProj")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("FoxPetProj"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}