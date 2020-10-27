using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier8
{
	public class PulseAmmo : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault("Energy based ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.ranged = true;
			item.width = 28;                     //projectile size
			item.height = 28;
			item.maxStack = 9999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 7.5f;
			item.value = 50;
			item.rare = ItemRarityID.Cyan;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Ranger.PulseAmmoProj>();   //The projectile shoot when your weapon using this ammo
			//item.shootSpeed = 16f;                  //The speed of the projectile
            item.ammo = item.type;            //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EmptyBullet, 50);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
	}
}
