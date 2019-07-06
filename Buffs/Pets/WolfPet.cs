using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.Pets
{
	public class WolfPet : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Wolf Follower");
            Description.SetDefault("\"A Loyal Wolf Friend\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MagicalPlayer>(mod).WolfPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("WolfPet")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("WolfPet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}