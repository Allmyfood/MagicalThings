using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior
{
    public class SticknStone : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Stick n' Stone");
            Tooltip.SetDefault("A Wood Mess trimmed down, and a stone attached with some webs");
        }
        public override void SetDefaults()
        {
            item.damage = 11;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.width = 30;
            item.height = 32;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 10;
            item.rare = 1;
            item.scale = 1.1f;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("SticknStoneProj");
            item.shootSpeed = 10.9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodMess", 1);
            recipe.AddIngredient(ItemID.Cobweb, 2);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}