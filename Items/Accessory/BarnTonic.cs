using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Accessory
{
	public class BarnTonic : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Smells like hay!");
        }
        public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("Centaur");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Hay, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}