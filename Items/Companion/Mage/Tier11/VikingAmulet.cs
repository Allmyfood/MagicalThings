using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier11
{
    public class VikingAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inanis Porta!"
                + "\nSummons a black hole" + "\nWill pull enemies and items to its center");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 250;
            item.magic = true;
            item.melee = false;
            item.mana = 40;
            item.width = 30;
            item.height = 28;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 0.5f;
            item.value = 1200000;
            item.rare = 11;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.PortalRingProj>(); //this is a mod projectile
            item.shootSpeed =0.5f; //not needed for stationary sentry
            //item.sentry = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            Projectile.NewProjectile(position.X, position.Y, 0, 0, ProjectileType<Projectiles.CompanionProj.Mage.PortalRingProj>(), damage, knockBack, player.whoAmI);
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  //this make so you can only spawn one of this projectile at the time,
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
                Projectile other = Main.projectile[ProjectileType<Projectiles.CompanionProj.Mage.BlackHoleProj>()];
                {
                    proj.Kill();
                }
            }
            return true;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier11/VikingAmulet_Glow");
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
            recipe.AddIngredient(null, "VortexOrbTome", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}