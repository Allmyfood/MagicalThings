using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier11
{
    public class Sinhtgrunt : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Terrarian);
			item.damage = 260;
			item.width = 30;
			item.height = 26;
			item.shootSpeed = 32f;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.SinhtgruntProj>();
			item.knockBack = 2.5f;
			item.value = 1200000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sinhtgrunt");
			Tooltip.SetDefault("Sinhtgrunt" + "\nMoony");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 10));
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TheStorm", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
