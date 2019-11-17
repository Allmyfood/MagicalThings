using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage
{
	public class BookOfSpells : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A strange book, what could happen?" + "\nMagic that changes with progress");
			//Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.magic = true;
            item.melee = false;
			item.mana = 2;
			item.width = 26;
			item.height = 32;
			item.useTime = 26;
			item.useAnimation = 26;
            item.useStyle = 5; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 20;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = 271; //mod.ProjectileType("LightBladeShot"); //this is a mod projectile
			item.shootSpeed = 5f;
		}
        //make it only shoot randomly not always
        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    int target = 0;

        //    if (Main.rand.Next(9) == 0)
        //    {
        //        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, target, 0f);
        //    }
        //    return false;
        //}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RockStick", 1);
            recipe.AddRecipeGroup("Wood", 1);
            recipe.AddIngredient(ItemID.Rope, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}