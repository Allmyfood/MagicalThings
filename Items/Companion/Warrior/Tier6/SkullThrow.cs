using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier6
{
    public class SkullThrow : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 40;
			item.width = 30;
			item.height = 26;
			item.shootSpeed = 32f;
			item.shoot = ProjectileType< Projectiles.CompanionProj.Warrior.SkullThrowProj>();
			item.knockBack = 3.75f;
			item.value = 70;
			item.rare = ItemRarityID.LightPurple;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Throw");
			Tooltip.SetDefault("A now skull Yo-Yo"
                + "\nMay shoot XBones");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TaintedThrow", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.Cascade, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
