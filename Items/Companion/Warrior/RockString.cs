using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior
{
	public class RockString : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 8;
			item.width = 30;
			item.height = 26;

			item.shootSpeed = 25f;
			item.shoot = mod.ProjectileType("RockStringProj");
			item.knockBack = 5;
			item.value = 10;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Yo-Yo");
			Tooltip.SetDefault("A string tied to a rock"
                + "\nFormaly a Wood Mess used for parts");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodMess", 1);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddIngredient(ItemID.Gel, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
