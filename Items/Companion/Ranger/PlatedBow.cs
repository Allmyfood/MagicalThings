using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 7f;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3;
			item.value = 30;
			item.useAmmo = AmmoID.Arrow;
			item.rare = ItemRarityID.Orange;
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
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
