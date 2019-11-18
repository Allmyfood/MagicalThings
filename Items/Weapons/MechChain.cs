using MagicalThings.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Weapons
{
    public class MechChain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mech Chain");
            Tooltip.SetDefault("A mechanized chain");
        }
        public override void SetDefaults()
        {
            item.damage = 80;
            item.thrown = true;
            item.melee = false;
            item.width = 34;
            item.height = 34;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 2f;
            item.value = 120;
            item.rare = 9;
            item.UseSound = SoundID.Item116;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<MechChains>();
            item.shootSpeed = 11.0f;
            item.crit += 12;
            item.noMelee = true;
            item.noUseGraphic = true;
            //item.channel = true;
        }
        //Removed
   //     public override void AddRecipes()
   //     {
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(null, "PWNDagger", 1);
			//recipe.AddIngredient(ItemID.HallowedBar, 20);
   //         recipe.AddTile(TileID.MythrilAnvil);
   //         recipe.SetResult(this);
   //         recipe.AddRecipe();
   //     }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.immune[item.owner] = 6;
            target.AddBuff(mod.BuffType("ArmorBreak"), 120);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0,
                Main.rand.Next(-100, 100) * 0.001f * player.gravDir); //whip swinging
            return false;
        }

        public  override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 200);
        }
    }
}