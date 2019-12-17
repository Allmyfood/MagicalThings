using MagicalThings.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Weapons
{
    public class ChaosBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Chaos Breaker");
            Tooltip.SetDefault("A powerful blade created to destroy evil");
        }
        public override void SetDefaults()
        {
            item.damage = 150;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = item.value = Item.buyPrice(gold: 50);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileType<ChaosBreakerProj>();
            item.shootSpeed = 9.75f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SwordOfLight", 1);
            recipe.AddIngredient(null, "SwordOfDarkness", 1);
            recipe.AddTile(TileID.MythrilAnvil); ;
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 107);
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 300);
        }

    }
}