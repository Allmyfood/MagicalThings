using MagicalThings.Projectiles.CompanionProj.Ranger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier10
{
	public class SelenianClaw : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Selenian Claw");
            Tooltip.SetDefault("A Selenian Bow" 
                + "\n66% chance to not consume ammo" + "\nChanges arrows into Razor arrows");
        }

        public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.PulseBow);
			item.damage = 140;
			item.ranged = true;
			item.width = 50;
			item.height = 70;
			item.useTime = 12;
            item.useAnimation = 12;
            item.shoot = 1;
			item.shootSpeed = 16f;			
			item.useStyle = 5;
			item.knockBack = 4.5f;
			item.value = 250;
			item.rare = 10;
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
            return Main.rand.NextFloat() >= .66f; //60%
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
            {
                type = ProjectileType<RazorArrowProj>();//ProjectileID.FrostburnArrow; // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShroomiteRepeater", 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        #region Glow Effec
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ranger/Tier10/SelenianClaw_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
        #endregion
    }
}
