using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier3
{
    public class RichThrow : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 12;
			item.width = 30;
			item.height = 26;

			item.shootSpeed = 26f;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.RichThrowProj>();
			item.knockBack = 5.5f;
			item.value = 30;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rich Throw");
			Tooltip.SetDefault("An expensive Yo-Yo"
                + "\nLegend says it will make you rich");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RockString", 1);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RockString", 1);
            recipe.AddIngredient(ItemID.PlatinumBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
