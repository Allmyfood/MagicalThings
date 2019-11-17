using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja
{
	public class PiercerGlove : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 10;
			item.melee = false;
            item.thrown = true;
			item.width = 26;
			item.height = 29;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 5.25f;
			item.value = 30;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Piercer Glove");
			Tooltip.SetDefault("Spike of Metal!");
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SplinterClaw", 1);
            recipe.AddIngredient(ItemID.Rope, 5);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 75);
        }
    }
}
