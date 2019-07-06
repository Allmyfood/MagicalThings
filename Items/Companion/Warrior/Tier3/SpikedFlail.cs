using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier3
{
    public class SpikedFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Spiked Flail");
            Tooltip.SetDefault("Warning: Tetanus");
        }
        public override void SetDefaults()
        {
            item.damage = 13;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 38;
            item.useAnimation = 38;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = 30;
            item.rare = 3;
            item.scale = 1.1f;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("SpikedFlailProj");
            item.shootSpeed = 12.9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SticknStone", 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SticknStone", 1);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
      /*  public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
       */ //     target.AddBuff(BuffID.Frostburn, 1800);
       // }

    }
}