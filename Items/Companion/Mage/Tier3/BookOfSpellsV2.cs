using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier3
{
    public class BookOfSpellsV2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Navis Concido!"
                +"\nThe ship was chopped!");
			//Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.magic = true;
            item.melee = false;
			item.mana = 4;
			item.width = 26;
			item.height = 32;
			item.useTime = 25;
			item.useAnimation = 25;
            item.useStyle = 5; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10;
			item.value = 30;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = 383; //mod.ProjectileType("LightBladeShot"); //this is a mod projectile
			item.shootSpeed = 20f;
		}
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BookOfSpells", 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BookOfSpells", 1);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}