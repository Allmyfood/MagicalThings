using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier4
{
    public class GemBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sleek gem encrusted blade"
                + "\nMay rarely cause Ichor debuff on hit.");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 18;
            item.useAnimation = 17;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4.75f;
            item.value = 40;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 7;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(24) == 0)
            {
                target.AddBuff(BuffID.Ichor, 160); //60 is the buff time
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SapphireBlade", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}