using System;
using System.Collections.Generic;
using MagicalThings.Projectiles.CompanionProj.Ranger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier11
{
    public class ValkryieCrossbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valkryie Crossbow");
            Tooltip.SetDefault("Changes arrows into Valkryie Ballistas"
                + "\n66% to not consume ammo" + "\n'Blot out the... eh, everyone says that'");
        }

        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.ChargedBlasterCannon);
            item.damage = 250;
            item.ranged = true;
            item.width = 68;
            item.height = 29;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 17;
            Item.sellPrice(platinum: 2, gold: 40);
            item.rare = 11;
            item.UseSound = SoundID.Item38;
            item.autoReuse = true;
            item.shoot = 10; //10 is default for guns.
            item.shootSpeed = 20.0f;
            item.useAmmo = AmmoID.Arrow;//ModContent.ItemType("VortexMissileAmmo");
            item.magic = false;
            item.noUseGraphic = false;
            //item.channel = true;
            //item.scale = 0.75f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, -1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SelenianClaw", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
        //blot out the sun with ballista bolts lolz
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(2);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f; //this defines the distance of the projectiles form the player when the projectile spawns
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1.0f; // This defines the projectile roatation and speed. .4f == projectile speed
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<ValkyrieArrowProj>(), damage, knockBack, player.whoAmI);
            }

            #region Change arrows to Valkyrie arrows
            if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
            {
                type = ProjectileType<ValkyrieArrowProj>();//ProjectileID.FrostburnArrow; // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
            #endregion
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .66f; //60%
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ranger/Tier11/ValkryieCrossbow_Glow");
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

