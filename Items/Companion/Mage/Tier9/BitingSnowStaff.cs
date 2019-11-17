using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier9
{
	public class BitingSnowStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            DisplayName.SetDefault("Biting Snow Staff");
            Tooltip.SetDefault("Casts a snow storm that drops ice" + "\nMay life steal on hit");            
		}

		public override void SetDefaults()
		{
			item.damage = 90;
			item.magic = true;
            item.melee = false;
			item.mana = 20;
			item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3.5f;
			item.value = 150;
			item.rare = 9;
            item.UseSound = SoundID.Item68; //for default
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("BitingSnowBombProj"); //this is a mod projectile
			item.shootSpeed = 15f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IceMistStaff", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}