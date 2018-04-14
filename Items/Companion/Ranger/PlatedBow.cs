using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger
{
    public class PlatedBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plated Bow");
            Tooltip.SetDefault("A reinforced bow");
        }

        public override void SetDefaults()
		{

			item.damage = 11;
			item.ranged = true;
			item.width = 16;
			item.height = 32;
			item.useTime = 26;
			item.shoot = 1;
			item.shootSpeed = 7f;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 30;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 3;
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
            recipe.AddIngredient(null, "GreenwoodBow", 1);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GreenwoodBow", 1);
            recipe.AddIngredient(ItemID.LeadBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
