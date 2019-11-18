using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Accessory
{
	public class CheeseWheel : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cheese Wheel");
            Tooltip.SetDefault("Summons a cute mousey");
        }
        public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.DogWhistle);
			item.width = 16;
            item.height = 12;
			item.shoot = ProjectileType<Projectiles.Pets.MousePetProj>();
			item.buffType = mod.BuffType("MouseyBuff");
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldMouseCage, 1);
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