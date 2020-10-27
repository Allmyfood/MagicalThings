using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier10
{
	public class VortexMissileBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Infinite Vortex Missiles");
		}

		public override void SetDefaults()
		{
			item.damage = 140;
			item.ranged = true;
			item.width = 32;                     //projectile size
			item.height = 32;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 7.5f;
			item.value = 80;
			item.rare = ItemRarityID.Red;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Ranger.VortexMissileProj>();   //The projectile shoot when your weapon using this ammo
            item.ammo = ItemType<VortexMissileAmmo>();            //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "VortexMissileAmmo", 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
