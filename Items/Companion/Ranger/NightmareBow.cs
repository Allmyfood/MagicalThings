using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger
{
	public class NightmareBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Bow");
            Tooltip.SetDefault("A dark bow" 
                + "\n May sometimes not consume ammo" + "\nTier7 Ranger Class" + "\nMaterial");
        }

        public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ShadowFlameBow);
			item.damage = 50;
			item.ranged = true;
			item.width = 28;
			item.height = 56;
			item.useTime = 17;
            item.useAnimation = 17;
            item.shoot = 1;
			item.shootSpeed = 13.25f;			
			item.useStyle = 5;
			item.knockBack = 2.5f;
			item.value = 80;
			item.rare = 7;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -1);
        }

        //50% chance not to consume ammo
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .55f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
            {
                type = ProjectileID.ShadowFlameArrow; // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SkeletalBow", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
