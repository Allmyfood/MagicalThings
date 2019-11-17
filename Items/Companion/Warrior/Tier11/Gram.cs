using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier11
{
    public class Gram : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gram");
            Tooltip.SetDefault("The Dragon Slayer"
                + "\nOnce used to slay Fafnir" + "\nShoot a variety of sword beams");
        }
        public override void SetDefaults()
        {
            item.damage = 280;
            item.melee = true;
            item.width = 56;
            item.height = 56;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 3.25f;
            item.value = 1200000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 20;
            //item.shoot = 389; // mod.ProjectileType("InfestedProj");
            item.shootSpeed = 12.5f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 268);
            }
        }
        
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.immune[item.owner] = 5;
            target.AddBuff(mod.BuffType("CutDebuff"), 420);
            target.AddBuff(mod.BuffType("ArmorBreak"), 420);
            //if (Main.rand.Next(5) == 0)
            //{
            //    Projectile.NewProjectile(target.Center.X, target.Center.Y, item.velocity.X, item.velocity.Y, 641, (int)(0.52f * item.damage), item.knockBack, item.owner, 0f, 0f);
            //}
        }

        public override bool CanUseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                #region Sword Shoot
                switch (Main.rand.Next(9))
                {
                    case 0:
                        item.shoot = 173;
                        break;

                    case 1:
                        item.shoot = 116;
                        break;

                    case 2:
                        item.shoot = 156;
                        break;

                    case 3:
                        item.shoot = 157;
                        break;

                    case 4:
                        item.shoot = 451;
                        break;

                    case 5:
                        item.shoot = 132;
                        break;

                    case 6:
                        item.shoot = 503;
                        break;

                    case 7:
                        item.shoot = 502;
                        break;

                    case 8:
                        item.shoot = mod.ProjectileType("VortexMissileProj");
                        break;
                }
                #endregion
            }
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.shoot == mod.ProjectileType("VortexMissileProj"))
            {
                int numberProjectiles = 12 + Main.rand.Next(2);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // This defines the projectiles random spread . 30 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }


        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Warrior/Tier11/Gram_Glow");
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
            recipe.AddIngredient(null, "SolarBlade", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}