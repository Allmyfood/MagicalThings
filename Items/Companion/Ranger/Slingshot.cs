using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class Slingshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A simple slingshot shoots pebbles" + "\nRange Weapon");
		}

		public override void SetDefaults()
		{
			item.damage = 2;
			item.ranged = true;             //Ranger class
			item.width = 16;
			item.height = 23;
			item.useTime = 24;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10;
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
            item.shoot = ProjectileType<Projectiles.CompanionProj.PebbleProj>();//1; //1 for bows 10 for guns. 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 4.5f;
            item.useAmmo = ItemType<Pebble>();//AmmoID.Arrow;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }

        public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Animus", 1);
            recipe.AddRecipeGroup("Wood", 1);
            recipe.AddIngredient(ItemID.Gel, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
