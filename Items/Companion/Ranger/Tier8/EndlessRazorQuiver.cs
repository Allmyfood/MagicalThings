using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier8
{
	public class EndlessRazorQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Infinite Razor arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.ranged = true;
			item.width = 32;                     //projectile size
			item.height = 32;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 2.75f;
			item.value = 50;
			item.rare = 9;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Ranger.RazorArrowProj>();   //The projectile shoot when your weapon using this ammo
            item.ammo = AmmoID.Arrow;            //The ammo class this ammo belongs to.
        }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RazorArrow", 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
