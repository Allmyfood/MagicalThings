using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior
{
    public class Branch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A Mess of Wood shaped into a sword" + "\nA sword");
        }
        public override void SetDefaults()
        {
            item.damage = 8;
            item.melee = true;
            item.width = 28;
            item.height = 30;
            item.useTime = 22;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4;
            item.value = 10;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodMess", 1);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddIngredient(ItemID.ClayBlock, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}