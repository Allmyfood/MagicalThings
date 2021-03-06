using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
	public class Deployer : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Deploy your own personal submarine!");
        }
        public override void SetDefaults()
		{
			item.width = 28;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item21;
			item.noMelee = true;
			item.mountType = mod.MountType("SSMonkfish");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SharkFin, 1);
            recipe.AddIngredient(ItemID.Glowstick, 10);
            recipe.AddIngredient(ItemID.GillsPotion, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}