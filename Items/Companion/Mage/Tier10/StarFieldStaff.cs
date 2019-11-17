using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier10
{
	public class StarFieldStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            DisplayName.SetDefault("Star Field Staff");
            Tooltip.SetDefault("Creates stars near the player" + "\nStars will home-in on targets" + "\nOnly allows 450 stars max");            
		}

		public override void SetDefaults()
		{
			item.damage = 140;
			item.magic = true;
            item.melee = false;
			item.mana = 16;
			item.width = 48;
			item.height = 48;
			item.useTime = 16;
			item.useAnimation = 16;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3.5f;
			item.value = 250;
			item.rare = 10;
            item.UseSound = SoundID.Item68; //for default
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarFieldProj"); //this is a mod projectile
			item.shootSpeed = 5f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            #region Shoot Multiple Stars in Random Position
            float numberProjectiles = 3; // This defines how many projectiles to shot
            Vector2 playerPosition = Main.player[item.owner].position;
            for (int i = 0; i < numberProjectiles; i++)
            {
                float posX = playerPosition.X + (Main.rand.Next(-40, 40) * 16);
                float posY = playerPosition.Y + (Main.rand.Next(-20, 7) * 16);
                Projectile.NewProjectile(posX, posY, 0, 0, mod.ProjectileType("StarFieldProj"), damage, knockBack, player.whoAmI);
            }
            #endregion
            return false;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier10/StarFieldStaff_Glow");
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
            recipe.AddIngredient(null, "BitingSnowStaff", 1);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}