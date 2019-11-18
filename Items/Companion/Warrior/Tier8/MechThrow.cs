using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier8
{
    public class MechThrow : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 70;
			item.width = 30;
			item.height = 26;
			item.shootSpeed = 32f;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.MechThrowProj>();
			item.knockBack = 3.75f;
			item.value = 120;
			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mech Throw");
			Tooltip.SetDefault("A mech Yo-Yo"
                + "\nMay shoot a laser");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNSword", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
