using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class PebbleGun : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pebble Gun");
            Tooltip.SetDefault("Shoots pebbles");
        }

        public override void SetDefaults()
		{

			item.damage = 8;
			item.ranged = true;
			item.width = 12;
			item.height = 12;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 20;
			item.rare = 1;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			//item.shoot = 10; //10 is default for guns.
            item.shoot = ProjectileType<Projectiles.CompanionProj.PebbleProj>();
            item.shootSpeed = 11f;
			//item.useAmmo = AmmoID.Bullet; //Normal ammos.
            item.useAmmo = ItemType<Pebble>();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Slingshot", 1);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
