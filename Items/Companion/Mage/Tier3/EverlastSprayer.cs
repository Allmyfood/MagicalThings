using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier3
{
    public class EverlastSprayer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Everlast Urn with added copper pipe");
			//Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.magic = true;
            item.melee = false;
			item.mana = 4;
			item.width = 26;
			item.height = 34;
			item.useTime = 21;
			item.useAnimation = 22;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 30;
			item.rare = 3;
			item.UseSound = SoundID.Item13;
			item.autoReuse = true;
            item.shoot = 22; //mod.ProjectileType("LightBladeShot"); //this is a mod projectile
			item.shootSpeed = 12.5f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EverlastUrn", 1);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.CopperBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EverlastUrn", 1);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.TinBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}