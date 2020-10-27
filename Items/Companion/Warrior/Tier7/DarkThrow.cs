using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier7
{
    public class DarkThrow : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 50;
			item.width = 30;
			item.height = 26;
			item.shootSpeed = 32f;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.DarkThrowProj>();
			item.knockBack = 3.75f;
			item.value = 80;
			item.rare = ItemRarityID.Lime;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Throw");
			Tooltip.SetDefault("A shadowy Yo-Yo"
                + "\nMay shoot shadowy crystals" + "\nTier7 Melee Class" + "\nMaterial");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SkullThrow", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
