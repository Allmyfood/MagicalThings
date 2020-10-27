using Microsoft.Xna.Framework;
using Terraria;
using MagicalThings.Mounts;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Accessory
{
	public class FancyBluePresent : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Drive a Santa-NK2!");
        }
        public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.NPCDeath5;
			item.noMelee = true;
            item.mountType = MountType<SantaNK2>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ZombieElfBanner, 1);
            recipe.AddIngredient(ItemID.SnowGlobe, 1);
            recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}