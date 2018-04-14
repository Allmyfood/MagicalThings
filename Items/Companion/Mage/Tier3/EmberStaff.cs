using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier3
{
    public class EmberStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Starter fire staff");
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
			item.value = 30;
			item.rare = 3;
            item.UseSound = SoundID.Item9; //for default
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("EmberProj"); //this is a mod projectile
			item.shootSpeed = 12f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoomStick", 1);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoomStick", 1);
            recipe.AddIngredient(ItemID.LeadBar, 2);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}