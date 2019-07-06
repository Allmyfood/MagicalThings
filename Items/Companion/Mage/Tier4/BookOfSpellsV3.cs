using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier4
{
    public class BookOfSpellsV3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Ne Incendio"
                +"\nStop the fire!");
			//Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 17;
			item.magic = true;
            item.melee = false;
			item.mana = 4;
			item.width = 26;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
            item.useStyle = 5; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 40;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = 85; //mod.ProjectileType("LightBladeShot"); //this is a mod projectile
			item.shootSpeed = 4.5f;
		}
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BookOfSpellsV2", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}