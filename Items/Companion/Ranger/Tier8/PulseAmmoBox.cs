using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger.Tier8
{
	public class PulseAmmoBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Infinite Energy based ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.ranged = true;
			item.width = 32;                     //projectile size
			item.height = 30;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 7.5f;
			item.value = 50;
			item.rare = 9;
			item.shoot = mod.ProjectileType("PulseAmmoProj");   //The projectile shoot when your weapon using this ammo
            item.ammo = mod.ItemType("PulseAmmo");            //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PulseAmmo", 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
