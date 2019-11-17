using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier9
{
    public class TheSpectre : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 80;
			item.width = 30;
			item.height = 26;
			item.shootSpeed = 32f;
			item.shoot = mod.ProjectileType("SpectreProj");
			item.knockBack = 2.5f;
			item.value = 150;
			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Spectre");
			Tooltip.SetDefault("A spectral Yo-Yo"
                + "\nMay life steal on hit");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MechThrow", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
