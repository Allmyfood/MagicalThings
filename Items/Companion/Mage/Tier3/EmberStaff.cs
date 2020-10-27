using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
            item.useStyle = ItemUseStyleID.HoldingOut; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1.5f;
			item.value = 30;
			item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item9; //for default
			item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.EmberProj>(); //this is a mod projectile
			item.shootSpeed = 12f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoomStick", 1);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}