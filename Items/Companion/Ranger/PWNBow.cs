using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger
{
	public class PWNBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PWN Bow");
            Tooltip.SetDefault("A PWN bow" 
                + "\n May sometimes not consume ammo" + "\nCraft with PwnHammer in inventory!");
        }

        public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ShadowFlameBow);
			item.damage = 70;
			item.ranged = true;
			item.width = 28;
			item.height = 56;
			item.useTime = 17;
            item.useAnimation = 17;
            item.shoot = 1;
			item.shootSpeed = 13.25f;			
			item.useStyle = 5;
			item.knockBack = 2.5f;
			item.value = 100;
			item.rare = 8;
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
                type = ProjectileID.IchorArrow; // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override void AddRecipes()
        {
            PWNBowRecipe recipe = new PWNBowRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Tier 7 Ranger Class", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public class PWNBowRecipe : ModRecipe
        {
            public PWNBowRecipe(Mod mod) : base(mod)
            {
            }

            public override bool RecipeAvailable()
            {
                return Main.LocalPlayer.HasItem(ItemID.Pwnhammer);
            }
        }
    }
}
