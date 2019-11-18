using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier4
{
    public class LivingEmber : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Living Ember Staff");
            Tooltip.SetDefault("Shoot a homing ember");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.magic = true;
            item.melee = false;
			item.mana = 4;
			item.width = 21;
			item.height = 30;
			item.useTime = 24;
			item.useAnimation = 24;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1.5f;
			item.value = 40;
			item.rare = 4;
            item.UseSound = SoundID.Item9; //for default
			item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.LivingEmberProj>(); //this is a mod projectile
			item.shootSpeed = 12f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EmberStaff", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}