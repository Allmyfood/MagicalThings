using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier10
{
    public class SolarBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Blade");
            Tooltip.SetDefault("A solar infused greatsword");
        }
        public override void SetDefaults()
        {
            item.damage = 160;
            item.melee = true;
            item.width = 66;
            item.height = 66;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 3.25f;
            item.value = 250;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 16;
            //item.shoot = 389; // mod.ProjectileType("InfestedProj");
            //item.shootSpeed = 17.5f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight((int)(item.Center.X / 16f), (int)(item.Center.Y / 16f), 0.98f, 0.94f, 0.53f);
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 259);
            }
        }
        
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.immune[item.owner] = 8;
            target.AddBuff(mod.BuffType("CutDebuff"), 270);
            target.AddBuff(BuffID.OnFire, 300);
            if (Main.rand.Next(16) == 0)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, item.velocity.X, item.velocity.Y, 612, (int)(0.52f * item.damage), item.knockBack, item.owner, 0f, 0f);
            }
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Warrior/Tier10/SolarBlade_Glow");
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

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SoulReaver", 1);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}