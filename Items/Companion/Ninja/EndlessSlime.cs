using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja
{
    public class EndlessSlime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bouncy Endless Knives");
            Tooltip.SetDefault("A poisoned throwing knife that bounces");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.thrown = true;
            item.melee = false;
            item.width = 16;
            item.height = 38;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4.5f;
            item.value = 40;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.EndlessSlimeProj>();
            item.shootSpeed = 11.5f;
            item.crit += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EndlessKnives", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        //How to have it create multiple projectiles instead of 1. Uses 1 ammo.
        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    float numberProjectiles = 3; // This defines how many projectiles to shot
        //    float rotation = MathHelper.ToRadians(12); //this is the angle from the original projectile the other projectiles are spawned
        //    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
        //    for (int i = 0; i < numberProjectiles; i++)
        //    {
        //        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f; // This defines the projectile roatation and speed. .4f == projectile speed
        //        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
        //    }
        //    return false;
        //}

        //    public override void MeleeEffects(Player player, Rectangle hitbox)
        //    {
        //        if (Main.rand.Next(3) == 0)
        //        {
        //            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
        //        }
        //    }
        //    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        //    {
        //        target.AddBuff(BuffID.Frostburn, 1800);
        //     }

    }
}