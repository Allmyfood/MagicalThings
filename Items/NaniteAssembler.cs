using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
	public class NaniteAssembler : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Assemble your MiTV!");
        }
        public override void SetDefaults()
		{
			item.width = 36;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item90;
			item.noMelee = true;
			item.mountType = mod.MountType("MiTV");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Nanites, 50);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 10);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}