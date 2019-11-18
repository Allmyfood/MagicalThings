using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier10
{
    public class TheStorm : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ValkyrieYoyo);

			item.damage = 150;
			item.width = 30;
			item.height = 26;
			item.shootSpeed = 32f;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.TheStormProj>();
			item.knockBack = 2.5f;
			item.value = 250;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Storm");
			Tooltip.SetDefault("A vortex Yo-Yo");
		}

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Warrior/Tier10/TheStorm_Glow");
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
            recipe.AddIngredient(null, "TheSpectre", 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
