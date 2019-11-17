using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier11
{
    public class Ogmios : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ogmios");
            Tooltip.SetDefault("A legendary sword housing the power of eloquence" + "\nCalls down Lunar Flares at the cursor");
        }
        public override void SetDefaults()
        {
            item.damage = 320;
            item.melee = true;
            item.width = 88;
            item.height = 88;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 11.75f;
            item.value = 1200000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 22;
            item.shoot = 645;//mod.ProjectileType("OgmiosShotProj"); //645;
            item.shootSpeed = 10;//12.5f;
        }

        #region Melee Effects
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 226);
            }
        }
        #endregion

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.immune[item.owner] = 3;
            target.AddBuff(mod.BuffType("CutDebuff"), 420);
            target.AddBuff(mod.BuffType("ArmorBreak"), 420);
            target.AddBuff(BuffID.Frostburn, 300);
            Projectile.NewProjectile(target.position.X, target.position.Y, 3 * player.direction, 0, 263, damage, knockback, player.whoAmI);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            #region Mostly Vanilla Lunar Flare
            Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
            int weaponDamage = item.damage;
            float num82 = Main.mouseX + Main.screenPosition.X - vector2.X;
            float num83 = Main.mouseY + Main.screenPosition.Y - vector2.Y;

            int num117 = 4;//Flares default 3
            int num2;
            for (int num118 = 0; num118 < num117; num118 = num2 + 1)
            {
                vector2 = new Vector2(player.position.X + (player.width * 0.5f) + (Main.rand.Next(201) * -(float)player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                vector2.X = ((vector2.X + player.Center.X) / 2f) + Main.rand.Next(-200, 201);
                vector2.Y -= 100 * num118;
                num82 = Main.mouseX + Main.screenPosition.X - vector2.X;
                num83 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
                float ai2 = num83 + vector2.Y;
                float num84 = (float)Math.Sqrt((num82 * num82) + (num83 * num83));
                //int num75 = item.shoot;
                float num76 = item.shootSpeed;
                //int num77 = weaponDamage;
                //float num78 = item.knockBack;
                if (num83 < 0f)
                {
                    num83 *= -1f;
                }
                if (num83 < 20f)
                {
                    num83 = 20f;
                }
                num84 = (float)Math.Sqrt((num82 * num82) + (num83 * num83));
                num84 = num76 / num84;
                num82 *= num84;
                num83 *= num84;
                Vector2 vector12 = new Vector2(num82, num83) / 2f;
                Main.PlaySound(2, (int)vector2.X, (int)vector2.Y, 88);
                Projectile.NewProjectile(vector2.X, vector2.Y, vector12.X, vector12.Y, type, damage, knockBack, player.whoAmI, 0f, ai2);
                num2 = num118;
                //Projectile.NewProjectile(vector2.X, vector2.Y, vector12.X, vector12.Y, num75, num77, num78, item.owner, 0f, ai2);
            }
            #endregion
            return false;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Warrior/Tier11/Ogmios_Glow");
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
            recipe.AddIngredient(null, "NebulaMace", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}