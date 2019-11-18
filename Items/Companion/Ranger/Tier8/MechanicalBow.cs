using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier8
{
	public class MechanicalBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Bow");
            Tooltip.SetDefault("A Mechanical bow" 
                + "\n60% chance to not consume ammo" + "\nChanges arrows into Holy arrows");
        }

        public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ShadowFlameBow);
			item.damage = 80;
			item.ranged = true;
			item.width = 36;
			item.height = 40;
			item.useTime = 15;
            item.useAnimation = 15;
            item.shoot = 1;
			item.shootSpeed = 13.75f;			
			item.useStyle = 5;
			item.knockBack = 4.5f;
			item.value = 120;
			item.rare = 9;
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
            return Main.rand.NextFloat() >= .60f; //60%
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
            {
                type = ProjectileID.HolyArrow; // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNBow", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
