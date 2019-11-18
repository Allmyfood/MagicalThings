using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class DarkBlaster : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Blaster");
            Tooltip.SetDefault("Shoots standard bullets" 
                + "\nMay sometimes not consume bullets" + "\nTier7 Ranger Class" + "\nMaterial");
        }

        public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.Minishark);
			item.damage = 50;
			item.ranged = true;
			item.width = 56;
			item.height = 30;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 80;
			item.rare = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //10 is default for guns.
            //item.shoot = ProjectileType<PebbleProj>();
            item.shootSpeed = 13.0f;
			item.useAmmo = AmmoID.Bullet; //Normal ammos.
            //item.useAmmo = ModContent.ItemType("Pebble");
            item.scale = 0.75f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, 1);
        }

        //50% chance not to consume ammo
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .55f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IvoryMagnum", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
            {
                type = ProjectileID.BulletHighVelocity; // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }
    }
}

