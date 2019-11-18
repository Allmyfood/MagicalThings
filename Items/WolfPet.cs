using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
	public class WolfPet : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wolf Runestone");
            Tooltip.SetDefault("Summons A Loyal Wolf Friend");
        }
        public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.DogWhistle);
			item.shoot = ProjectileType<Projectiles.Pets.WolfPet>();
			item.buffType = mod.BuffType("WolfPet");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WolfBanner, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}