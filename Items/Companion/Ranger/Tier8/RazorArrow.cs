using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger.Tier8
{
	public class RazorArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Razor sharp arrows cause bleeding");
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.ranged = true;
			item.width = 14;                     //projectile size
			item.height = 32;
			item.maxStack = 9999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 2.75f;
			item.value = 50;
			item.rare = 9;
			item.shoot = mod.ProjectileType("RazorArrowProj");   //The projectile shoot when your weapon using this ammo
			//item.shootSpeed = 16f;                  //The speed of the projectile
            item.ammo = AmmoID.Arrow;            //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 100);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
	}
}
