using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier10
{
    public class VortexOrbTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Magna Impetus!"
                + "\nAn upgraded protective shield that fires at enemies");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 140;
            item.magic = true;
            item.melee = false;
            item.mana = 20;
            item.width = 28;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 13;
            item.value = 250;
            item.rare = 10;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.buffType = mod.BuffType("VortexShieldBuff");
            //item.shoot = ProjectileType<VolcanoProj>(); //this is a mod projectile
            //item.shootSpeed = 4.5f; //not needed for stationary sentry
            //item.sentry = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 2, true);
            }
        }

        public override bool CanUseItem(Player player)
        {
            if (!player.HasBuff(mod.BuffType("HallowedArmorBuff")) && !player.HasBuff(mod.BuffType("HallowedShieldBuff")))
            {
                if (!player.HasBuff(mod.BuffType("VortexShieldBuff")))
                {
                    return true;
                }
            }
            return false;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Mage/Tier10/VortexOrbTome_Glow");
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
            recipe.AddIngredient(null, "SpectralRingTome", 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}