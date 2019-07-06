using MagicalThings.Projectiles.CompanionProj;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior
{
    public class PointyBranch : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A now pointy Mess of Wood");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.useStyle = 5;
			item.useAnimation = 28;
			item.useTime = 34;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.75f;
			item.width = 38;
			item.height = 38;
			item.scale = 1f;
			item.rare = 1;
			item.value = Item.sellPrice(copper: 10);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType<PointyBranchProj>();
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodMess", 1);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
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
