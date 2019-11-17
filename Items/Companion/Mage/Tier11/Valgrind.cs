using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier11
{
    public class Valgrind : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valgrind");
            Tooltip.SetDefault("Summon a barrage of piercing shots" + "\nWill summon a gateway from Valhalla" 
                + "\nTo extinguish your enemies" + "\nThe outer gate of Valhalla, 'But few only know how it is closed with lock'");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 250;
            item.magic = true;
            item.melee = false;
            item.mana = 10;
            item.width = 64;
            item.height = 64;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.5f;
            item.value = 1200000;
            item.rare = 11;
            item.UseSound = SoundID.Item104;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ValgrindShotProj"); //this is a mod projectile
            item.shootSpeed = 16f;
        }

        //Shoot multiple projectiles in an even ark.
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(15);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .8f; // This defines the projectile roatation and speed. .4f == projectile speed
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier11/Valgrind_Glow");
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
            recipe.AddIngredient(null, "CollapsingStarTome", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}