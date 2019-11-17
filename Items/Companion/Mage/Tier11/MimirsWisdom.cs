using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier11
{
	public class MimirsWisdom : ModItem
	{
		public override void SetStaticDefaults()
		{
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            DisplayName.SetDefault("Mimir's Wisdom");
            Tooltip.SetDefault("Rains blizzard bolts from the sky" + "\nLeaves trais of Starlight" + "\n'Drink from the well of wisdom and know power'" + "\n450 max stars");            
		}

		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.BlizzardStaff);
			item.damage = 250;
			item.magic = true;
            item.melee = false;
			item.mana = 10;
			item.width = 24;
			item.height = 24;
			item.useTime = 5;
			item.useAnimation = 10;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4.5f;
			item.value = 1200000;
			item.rare = 11;
            //item.UseSound = SoundID.Item68; //for default
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("MimirsShotProj"); //this is a mod projectile
			item.shootSpeed = 10f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            #region Vanilla Blizzard Staff
            int num111 = 2;
            int num2;
            for (int num112 = 0; num112 < num111; num112 = num2 + 1)
            {
                Vector2 vector2 = new Vector2(player.position.X + (player.width * 0.5f) + (Main.rand.Next(201) * -(float)player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                vector2.X = ((vector2.X + player.Center.X) / 2f) + Main.rand.Next(-200, 201);
                vector2.Y -= 100 * num112;
                float num82 = Main.mouseX + Main.screenPosition.X - vector2.X;
                float num83 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
                float num84 = (float)Math.Sqrt((num82 * num82) + (num83 * num83));
                float num76 = item.shootSpeed;
                num82 = Main.mouseX + Main.screenPosition.X - vector2.X;
                num83 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
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
                float speedX4 = num82 + (Main.rand.Next(-40, 41) * 0.02f);
                float speedY5 = num83 + (Main.rand.Next(-40, 41) * 0.02f);
                Projectile.NewProjectile(vector2.X, vector2.Y, speedX4, speedY5, type, damage, knockBack, Main.myPlayer, 0f, Main.rand.Next(5));
                num2 = num112;
            }
            #endregion
            return false;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier11/MimirsWisdom_Glow");
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
            recipe.AddIngredient(null, "StarFieldStaff", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}