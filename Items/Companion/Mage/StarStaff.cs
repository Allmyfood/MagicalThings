using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage
{
    public class StarStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A powerful staff of magic! Now with a Star" + "\nArcane magic");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.magic = true;
            item.melee = false;
			item.mana = 2;
			item.width = 21;
			item.height = 30;
			item.useTime = 26;
			item.useAnimation = 26;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 20;
			item.rare = 1;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
            item.shoot = 12; //mod.ProjectileType("LightBladeShot"); //this is a mod projectile
			item.shootSpeed = 8f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RockStick", 1);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}