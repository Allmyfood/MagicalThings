using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			item.height = 32;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7.25f;
			item.value = 40;
			item.rare = ItemRarityID.LightRed;
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
