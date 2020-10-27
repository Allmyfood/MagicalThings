using MagicalThings.Projectiles.CompanionProj.Warrior;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier10
{
    public class Skypiercer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skypiercer");
			Tooltip.SetDefault("An infinitely throwable spear" + "\nWill impale the enemy");
		}

		public override void SetDefaults()
		{
			item.damage = 160;
			item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 12;
            item.useAnimation = 12;			
			item.shootSpeed = 18.75f;
			item.knockBack = 6.5f;
			item.width = 56;
			item.height = 56;
			//item.scale = 1f;
            item.value = 250;
            item.rare = ItemRarityID.Red;
            item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
            item.crit = 6;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SkypiercerProj>();
		}

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Warrior/Tier10/Skypiercer_Glow");
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
            recipe.AddIngredient(null, "EctoSpear", 1);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
