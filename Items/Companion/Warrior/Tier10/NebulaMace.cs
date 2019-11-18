using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier10
{
    public class NebulaMace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Mace");
            Tooltip.SetDefault("A Nebula empowered mace"
                + "\nMay generate nebula orbs on hit");
        }
        public override void SetDefaults()
        {
            item.damage = 210;
            item.melee = true;
            item.width = 70;
            item.height = 70;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 9.75f;
            item.value = 250;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 18;
            //item.shoot = 389; // ModContent.ProjectileType("InfestedProj");
            //item.shootSpeed = 17.5f;
        }

        #region Melee Effects
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight((int)(item.Center.X / 16f), (int)(item.Center.Y / 16f), 0.58f, 1.0f, 1.0f);
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135);
            }
        }
        #endregion

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("CutDebuff"), 270);

            #region Drop Nebula booster chance
            if (item.owner == Main.myPlayer && !target.friendly && target.active && target.CanBeChasedBy(target, false))
            {
                if (Main.rand.NextFloat() < .3000f)
                {
                    int choice = Main.rand.Next(2);
                    if (choice == 0)
                    {
                        Item.NewItem((int)target.position.X + (Main.rand.Next(target.width) * 2), (int)target.position.Y + (Main.rand.Next(target.height) * -6), 2, 2, ItemID.NebulaPickup1, Main.rand.Next(1, 4));
                    }
                    else if (choice == 1)
                    {
                        Item.NewItem((int)target.position.X + (Main.rand.Next(target.width) * 2), (int)target.position.Y + (Main.rand.Next(target.height) * -6), 2, 2, ItemID.NebulaPickup2, Main.rand.Next(1, 4));
                    }
                }
                return;
            }
            #endregion
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Warrior/Tier10/NebulaMace_Glow");
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
            recipe.AddIngredient(null, "SpiritCrusher", 1);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}