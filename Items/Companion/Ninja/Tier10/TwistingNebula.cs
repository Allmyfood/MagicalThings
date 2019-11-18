using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja.Tier10
{
    public class TwistingNebula : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twisting Nebula");
            Tooltip.SetDefault("A swirling nebula");
        }
        public override void SetDefaults()
        {
            item.damage = 160;
            item.thrown = true;
            item.melee = false;
            item.width = 56;
            item.height = 64;
            item.useTime = 11;
            item.useAnimation = 11;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = 250;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.TwistingNebulaProj>();
            item.shootSpeed = 15.0f;
            item.crit += 18;
            item.noMelee = true;
            item.noUseGraphic = true;
        }
		
		#region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ninja/Tier10/TwistingNebula_Glow");
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
			recipe.AddIngredient(null, "SpectralLabrys", 1);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
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