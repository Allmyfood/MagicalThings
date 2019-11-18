using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier10
{
    public class CollapsingStarTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Collapsing Star Tome");
            Tooltip.SetDefault("Summon a Collapsing Star" + "\nWill shoot at enemies");
            Item.staff[item.type] = false; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 140;
            item.magic = true;
            item.melee = false;
            item.mana = 15;
            item.width = 28;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.5f;
            item.value = 250;
            item.rare = 10;
            item.UseSound = SoundID.Item104;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.CollapsingStarHoleProj>(); //this is a mod projectile
            item.shootSpeed = 16f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            Projectile.NewProjectile(position.X, position.Y, 0, 0, type, damage, knockBack, player.whoAmI);
            return false;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier10/CollapsingStarTome_Glow");
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
            recipe.AddIngredient(null, "SpectralFangTome", 1);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}