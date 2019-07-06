using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items
{
	public class BrokenWarSword : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summon the Horse of War!");
        }
        public override void SetDefaults()
		{
			item.width = 34;
			item.height = 38;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item13;
			item.noMelee = true;
			item.mountType = mod.MountType("HorseofWar");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}