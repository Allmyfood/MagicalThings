using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner.Tier11
{
    public class BlazingGlory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Glory");
            Tooltip.SetDefault("The Valkyrie will protect you" + "\nDoes not use a minion slot" + "\nSlightly faster than Profound Darkness Tome");
        }

        public override void SetDefaults()
        {
            item.damage = 250;
            item.summon = true;
            item.mana = 10;
            item.width = 62;
            item.height = 62;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 4.0f;
            Item.sellPrice(platinum: 2, gold: 40);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item117;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Minions.ValkyrieProj>();
            item.shootSpeed = 5f;
            item.buffType = mod.BuffType("BlazingGloryBuff");    //The buff added to player after used the item
            item.buffTime = 3600;               //The duration of the buff, here is 60 seconds
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PillarDragonStaff", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one summon can be out.
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        #region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Summoner/Tier11/BlazingGlory_Glow");
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
