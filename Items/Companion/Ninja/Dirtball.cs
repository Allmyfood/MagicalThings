using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja
{
    public class Dirtball : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A lump of dirt with rocks");
        }
        public override void SetDefaults()
        {
            item.damage = 2;
            item.thrown = true;
            item.melee = false;
            item.width = 18;
            item.height = 18;
            item.useTime = 24;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Dirtballproj");
            item.shootSpeed = 6.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Animus", 1);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
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