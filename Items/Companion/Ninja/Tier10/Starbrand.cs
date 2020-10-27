using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja.Tier10
{
    public class Starbrand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starbrand");
            Tooltip.SetDefault("A star powered saber"
			+ "\nRight click to boost attack");
        }
        public override void SetDefaults()
        {
            item.damage = 160;
            item.thrown = true;
            item.melee = false;
            item.width = 40;
            item.height = 48;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4.5f;
            item.value = 250;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            //item.shoot = ProjectileType<PWNDaggerProj>();
            //item.shootSpeed = 11.0f;
            item.crit += 18;
            item.noMelee = false;
            item.noUseGraphic = false;
        }

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpectralSaber", 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                item.damage = item.damage;
                item.shoot = ProjectileID.None;
                item.noUseGraphic = false;
                item.noMelee = false;
                item.useTime = 12;
                item.useAnimation = 12;
                item.buffType = 0;
                item.UseSound = SoundID.Item1;
            }

            if (player.altFunctionUse == 2)
            {
                //item.useTime = 15;
                //item.useAnimation = 15;
                //item.damage = item.damage;
                item.noMelee = true;
                item.buffType = 198;
                item.buffTime = 300;               
                item.noUseGraphic = true;
                item.UseSound = SoundID.Item4;
                //item.shoot = ProjectileType<BlindPowderProj>();           
            }
                return base.CanUseItem(player);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight((int)(item.Center.X / 16f), (int)(item.Center.Y / 16f), 0.58f, 1.0f, 1.0f);
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135);
            }
        }

		#region Glow Effect
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Companion/Ninja/Tier10/Starbrand_Glow");
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
		
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.immune[item.owner] = 5;
            if (player.HasBuff(BuffID.ParryDamageBuff))
            {
                item.damage = 800;
            }
            else if (!player.HasBuff(BuffID.ParryDamageBuff))
            {
                item.damage = 160;
            }
            //target.AddBuff(mod.BuffType("ArmorBreak"), 120);
            if (item.owner == Main.myPlayer) //do life steal if hp is less than max.
            {
                Player owner = Main.player[item.owner];
                if (owner.statLife < owner.statLifeMax)
                {
                    if (owner.lifeSteal <= 0f) return;
                    float heal = damage / 10;
                    owner.lifeSteal -= heal;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, ProjectileID.SpiritHeal, 0, 0f, item.owner, item.owner, heal);
                }
            }
        }
    }
}