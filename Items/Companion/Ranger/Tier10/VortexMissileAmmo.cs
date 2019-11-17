using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger.Tier10
{
	public class VortexMissileAmmo : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault("Vortex Missile ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 140;
			item.ranged = true;
			item.width = 24;                     //projectile size
			item.height = 14;
			item.maxStack = 9999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 7.5f;
			item.value = 80;
			item.rare = 10;
			item.shoot = mod.ProjectileType("VortexMissileProj");   //The projectile shoot when your weapon using this ammo
			//item.shootSpeed = 16f;                  //The speed of the projectile
            item.ammo = item.type;
            //item.useAmmo = AmmoID.Rocket;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
	}
}
