using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier5
{
    public class InfestedFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Infested Flail");
            Tooltip.SetDefault("A corrupted flail");
        }
        public override void SetDefaults()
        {
            item.damage = 24;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.width = 34;
            item.height = 32;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5;
            item.value = 50;
            item.rare = ItemRarityID.Pink;
            item.scale = 1.1f;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.InfestedFlailProj>();
            item.shootSpeed = 14.9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SlimeLeash", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        //public override void MeleeEffects(Player player, Rectangle hitbox)
        //{
        //    if (Main.rand.Next(3) == 0)
        //    {
        //        int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
        //    }
        //}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Dazed, 35);
        }
    }
}