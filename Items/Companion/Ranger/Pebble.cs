using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class Pebble : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A small rock, ammo for a slingshot");
		}

		public override void SetDefaults()
		{
			item.damage = 2;
			item.ranged = true;
			item.width = 8;                     //projectile size
			item.height = 8;
			item.maxStack = 9999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = .5f;
			item.value = 0;
			item.rare = 0;
			item.shoot = ProjectileType<Projectiles.CompanionProj.PebbleProj>();   //The projectile shoot when your weapon using this ammo
			//item.shootSpeed = 16f;                  //The speed of the projectile
            item.ammo = item.type;            //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
