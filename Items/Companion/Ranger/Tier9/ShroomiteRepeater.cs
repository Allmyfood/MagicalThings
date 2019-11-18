using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier9
{
	public class ShroomiteRepeater : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Repeater");
            Tooltip.SetDefault("A Shroomite Repeater" 
                + "\n60% chance to not consume ammo" + "\nChanges arrows into Razor arrows");
        }

        public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ShadowFlameBow);
			item.damage = 90;
			item.ranged = true;
			item.width = 58;
			item.height = 30;
			item.useTime = 14;
            item.useAnimation = 14;
            item.shoot = 1;
			item.shootSpeed = 14.25f;			
			item.useStyle = 5;
			item.knockBack = 4.5f;
			item.value = 150;
			item.rare = 9;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item11;//5
			item.autoReuse = true;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
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
                type = ProjectileType<Projectiles.CompanionProj.Ranger.RazorArrowProj>();//ProjectileID.FrostburnArrow; // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MechanicalBow", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
