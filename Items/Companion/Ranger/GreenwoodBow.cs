using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger
{
	public class GreenwoodBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greenwood Bow");
            Tooltip.SetDefault("A basic bow");
        }

        public override void SetDefaults()
		{

			item.damage = 8;
			item.ranged = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 28;
			item.shoot = 1;
			item.shootSpeed = 6f;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 20;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Slingshot", 1);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(ItemID.Cobweb, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
