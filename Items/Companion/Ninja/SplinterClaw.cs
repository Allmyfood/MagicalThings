using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja
{
	public class SplinterClaw : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 8;
			item.melee = false;
            item.thrown = true;
			item.width = 24;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 20;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Splinter Claw" + "\nA claw");
			Tooltip.SetDefault("Claws of Wood!");
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Dirtball", 1);
            recipe.AddRecipeGroup("Wood", 1);
            recipe.AddIngredient(ItemID.Rope, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
