using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier11
{
	public class SurtrsWrath : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            DisplayName.SetDefault("Surtr's Wrath");
            Tooltip.SetDefault("Creates a fireball that fires aerial bane");            
		}

		public override void SetDefaults()
		{
			item.damage = 250;
			item.magic = true;
            item.melee = false;
			item.mana = 12;
			item.width = 48;
			item.height = 48;
			item.useTime = 15;
			item.useAnimation = 15;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3.5f;
			item.value = 1200000;
			item.rare = 11;
            item.UseSound = SoundID.Item73;
			item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.SurtrsWrathProj>(); //this is a mod projectile
			item.shootSpeed = 5f;
		}

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier11/SurtrsWrath_Glow");
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
            recipe.AddIngredient(null, "PhoenixFlightStaff", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}