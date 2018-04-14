using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier4
{
    public class SlimeThrow : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 20;
			item.width = 30;
			item.height = 26;

			item.shootSpeed = 28f;
			item.shoot = mod.ProjectileType("SlimeThrowProj");
			item.knockBack = 5.75f;
			item.value = 40;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Throw");
			Tooltip.SetDefault("A slime covered Yo-Yo"
                + "\nLegend says it will not make you rich");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RichThrow", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
