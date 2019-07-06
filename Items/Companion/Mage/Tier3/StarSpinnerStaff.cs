using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier3
{
    public class StarSpinnerStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots a spinning star");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.magic = true;
            item.melee = false;
			item.mana = 5;
			item.width = 48;
			item.height = 48;
			item.useTime = 26;
			item.useAnimation = 26;
            item.useStyle = 5; //Standard style including books and staves. Aka held out infront of the player
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 30;
			item.rare = 3;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarSpinnerProj"); //this is a mod projectile
			item.shootSpeed = 3f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("StarStaff"), 1);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}