using MagicalThings.Projectiles.CompanionProj.Warrior;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier3
{
    public class DualSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A spear with a blade on each end");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.useStyle = 5;
			item.useAnimation = 28;
			item.useTime = 30;
			item.shootSpeed = 4.25f;
			item.knockBack = 5.5f;
			item.width = 61;
			item.height = 66;
			item.scale = 1f;
			item.rare = 3;
			item.value = Item.sellPrice(copper: 30);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<DualSpearProj>();
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PointyBranch", 1);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}
	}
}
