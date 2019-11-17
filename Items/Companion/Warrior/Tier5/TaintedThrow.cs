using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier5
{
    public class TaintedThrow : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 24;
			item.width = 32;
			item.height = 32;

			item.shootSpeed = 30f;
			item.shoot = mod.ProjectileType("TaintedThrowProj");
			item.knockBack = 3.75f;
			item.value = 50;
			item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tainted Throw");
			Tooltip.SetDefault("A now tainted Yo-Yo"
                + "\nMay spew cursed flames rarely");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SlimeThrow", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
