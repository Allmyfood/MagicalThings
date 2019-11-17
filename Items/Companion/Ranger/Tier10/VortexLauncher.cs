using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger.Tier10
{
    public class VortexLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Launcher");
            Tooltip.SetDefault("Shoots Vortex Missiles"
                + "\n66% to not consume ammo" + "\nFires powerful missiles");
            
        }

        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.ChargedBlasterCannon);
            item.damage = 140;
            item.ranged = true;
            item.width = 52;
            item.height = 34;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = 150;
            item.rare = 10;
            item.UseSound = SoundID.Item92;
            item.autoReuse = true;
            item.shoot = 10; //10 is default for guns.
            //item.shoot = mod.itemType("PebbleProj");
            item.shootSpeed = 14.0f;
            //item.useAmmo = AmmoID.Bullet; //Normal ammos.
            item.useAmmo = mod.ItemType("VortexMissileAmmo");
            item.magic = false;
            item.noUseGraphic = false;
            item.channel = true;
            //item.scale = 0.75f;
        }

        //public override Vector2? HoldoutOffset()
        //{
        //    return new Vector2(-15, -1);
        //}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PhotonicCannon", 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .66f; //60%
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ranger/Tier10/VortexLauncher_Glow");
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

