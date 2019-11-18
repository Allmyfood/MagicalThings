using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Accessory
{
	public class IlluminationTriangle : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Illumination Triangle");
            Tooltip.SetDefault("Summons floating triangle light pet");
        }
        public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MagicLantern);
            item.width = 12;
            item.height = 12;
            item.shoot = ProjectileType<Projectiles.Pets.IlluminationProj>();
			item.buffType = mod.BuffType("EyeBuff");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Torch, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}