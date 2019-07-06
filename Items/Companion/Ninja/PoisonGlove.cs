using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja
{
	public class PoisonGlove : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.melee = false;
            item.thrown = true;
			item.width = 28;
			item.height = 31;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 7.25f;
			item.value = 40;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.crit += 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poison Glove");
			Tooltip.SetDefault("Poisoned Boxing Glove");
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PiercerGlove", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 85);
        }
    }
}
