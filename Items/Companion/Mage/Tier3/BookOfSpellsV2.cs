using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
            item.useStyle = ItemUseStyleID.HoldingOut; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10;
			item.value = 30;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = ProjectileID.Anchor; //ModContent.ProjectileType("LightBladeShot"); //this is a mod projectile
			item.shootSpeed = 20f;
		}
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BookOfSpells", 1);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}