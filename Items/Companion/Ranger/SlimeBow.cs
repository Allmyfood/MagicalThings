using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
    public class SlimeBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Bow");
            Tooltip.SetDefault("A reinforced slimy bow");
        }

        public override void SetDefaults()
		{

			item.damage = 20;
			item.ranged = true;
			item.width = 20;
			item.height = 40;
			item.useTime = 24;
			item.shoot = 1;
			item.shootSpeed = 9f;
			item.useAnimation = 24;
			item.useStyle = 5;
			item.knockBack = 3.25f;
			item.value = 40;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 4;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		//public override Vector2? HoldoutOffset()
		//{
		//	return new Vector2(2, 0);
		//}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PlatedBow", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
