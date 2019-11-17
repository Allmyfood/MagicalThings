using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja.Tier11
{
    public class JuuchiYosamu : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Juuchi Yosamu");
            Tooltip.SetDefault("10,000 Cold Nights."
			+ "\nCrafted by the legendary Swordsmith Muramasa" + "\nWill cut to oblivion all in it's path");
        }
        public override void SetDefaults()
        {
            item.damage = 250;
            item.thrown = true;
            item.melee = false;
            item.width = 60;
            item.height = 60;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 1;
            item.knockBack = 2.0f;
            item.value = 1200000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            //item.shoot = mod.ProjectileType("SakuraPetalFallingProj");
            item.shootSpeed = 0.5f;
            item.crit += 25;
            item.noMelee = false;
            item.noUseGraphic = false;
        }

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Starbrand", 1);
			recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        #region Shoot Override
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1 + Main.rand.Next(5);
            position = Main.MouseWorld;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 vector2_1 = new Vector2((float)(Main.MouseWorld.X + (player.width * 0.5) + (Main.rand.Next(201) * -player.direction)), (float)Main.MouseWorld.Y + (float)(player.height * 0.5) + (Main.rand.Next(50) * -player.direction));   //this defines the projectile width, direction and position
                vector2_1.X = (float)((vector2_1.X + (double)Main.MouseWorld.X) / 2.0) + Main.rand.Next(-5, 5);
                vector2_1.Y -= 15 * i;
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, 0, 0, type, damage, knockBack, player.whoAmI);
            }
            //Projectile.NewProjectile(position.X, position.Y, 0, 0, type, damage, knockBack, player.whoAmI);
            return false;
        }
        #endregion

        #region Alt Function
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                item.damage = item.damage;
                item.shoot = 0;
                item.noUseGraphic = false;
                item.noMelee = false;
                item.useTime = 9;
                item.useAnimation = 9;
                item.buffType = 0;
                item.UseSound = SoundID.Item1;
            }

            if (player.altFunctionUse == 2)
            {
                //item.useTime = 15;
                //item.useAnimation = 15;
                //item.damage = item.damage;
                item.noMelee = true;
                item.buffType = 198;
                item.buffTime = 300;               
                item.noUseGraphic = true;
                item.UseSound = SoundID.Item4;
                item.shoot = mod.ProjectileType("SakuraPetalFallingProj");
            }
                return base.CanUseItem(player);
        }
        #endregion

        #region Melee Effects
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight((int)(item.Center.X / 16f), (int)(item.Center.Y / 16f), 0.58f, 1.0f, 1.0f);
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135);
            }
        }
        #endregion

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ninja/Tier11/JuuchiYosamu_Glow");
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

        #region On Hit NPC
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.immune[item.owner] = 5;
            if (player.HasBuff(BuffID.ParryDamageBuff))
            {
                item.damage = 800;
            }
            else if (!player.HasBuff(BuffID.ParryDamageBuff))
            {
                item.damage = 250;
            }
            //target.AddBuff(mod.BuffType("ArmorBreak"), 120);
            #region Lifesteal
            if (item.owner == Main.myPlayer) //do life steal if hp is less than max.
            {
                Player owner = Main.player[item.owner];
                if (owner.statLife < owner.statLifeMax)
                {
                    if (owner.lifeSteal <= 0f) return;
                    float heal = damage / 10;
                    owner.lifeSteal -= heal;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, 298, 0, 0f, item.owner, item.owner, heal);
                }
            }
            #endregion
        }
        #endregion
    }
}