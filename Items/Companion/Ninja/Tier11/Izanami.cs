using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja.Tier11
{
    public class Izanami : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Izanami");
            Tooltip.SetDefault("Wife of the deity Izanagi" + "\nGoddess of creation and death" + "\nAs well as the mother of many deities");
        }
        public override void SetDefaults()
        {
            item.damage = 250;
            item.thrown = true;
            item.melee = false;
            item.width = 78;
            item.height = 70;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 6.5f;
            item.value = 1200000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.IzanamiProj>();
            item.shootSpeed = 17.0f;
            item.crit += 25;
            item.noMelee = true;
            item.noUseGraphic = true;
        }
		
		#region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ninja/Tier11/Izanami_Glow");
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
			recipe.AddIngredient(null, "TwistingNebula", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		//public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        //{
            //target.AddBuff(BuffID.OnFire, 180);
        //}
    }
}