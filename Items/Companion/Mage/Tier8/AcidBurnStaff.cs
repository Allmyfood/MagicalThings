using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier8
{
	public class AcidBurnStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            DisplayName.SetDefault("Acid Burn Staff");
            Tooltip.SetDefault("Creates an poison ball that explodes on collision");            
		}

		public override void SetDefaults()
		{
			item.damage = 75;
			item.magic = true;
            item.melee = false;
			item.mana = 15;
			item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3.5f;
			item.value = 120;
			item.rare = 9;
            item.UseSound = SoundID.Item117; //for default
			item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.AcidBurnBombProj>(); //this is a mod projectile
			item.shootSpeed = 5f;
		}
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNBook", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}