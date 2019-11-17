using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier10
{
	public class PhoenixFlightStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            DisplayName.SetDefault("Phoenix Flight Staff");
            Tooltip.SetDefault("Shoots an exploding Phoenix");            
		}

		public override void SetDefaults()
		{
			item.damage = 150;
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
			item.value = 250;
			item.rare = 10;
            item.UseSound = SoundID.Item42;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("PhoenixFlightProj"); //this is a mod projectile
			item.shootSpeed = 15f;
		}
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AcidCloudStaff", 1);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y - 15, speedX, speedY, type, damage, knockBack, player.whoAmI);
            return false;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier10/PhoenixFlightStaff_Glow");
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