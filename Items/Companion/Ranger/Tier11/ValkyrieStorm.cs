using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier11
{
    public class ValkyrieStorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valkyrie Storm");
            Tooltip.SetDefault("Shoots Lots of Vortex Missiles"
                + "\n66% to not consume ammo" + "\n'I'm not in trouble, I make trouble!");
        }

        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.ChargedBlasterCannon);
            item.damage = 250;
            item.ranged = true;
            item.width = 68;
            item.height = 28;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            Item.sellPrice(platinum: 2, gold: 40);
            item.rare = 11;
            item.UseSound = SoundID.Item94;
            item.autoReuse = true;
            item.shoot = 10; //10 is default for guns.
            item.shootSpeed = 18.0f;
            item.useAmmo = ItemType<Tier10.VortexMissileAmmo>();
            item.magic = false;
            item.noUseGraphic = false;
            item.channel = true;
            //item.scale = 0.75f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, -1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "VortexLauncher", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 12 + Main.rand.Next(2); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // This defines the projectiles random spread . 30 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .66f; //60%
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ranger/Tier11/ValkyrieStorm_Glow");
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

