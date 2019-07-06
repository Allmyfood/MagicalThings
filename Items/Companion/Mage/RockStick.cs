using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage
{
	public class RockStick : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A powerful staff of magic! Eh, maybe...");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 2;
			item.magic = true;
			item.mana = 0;
			item.width = 44;
			item.height = 42;
			item.useTime = 14;
			item.useAnimation = 12;
            item.useStyle = 1; // 5; //Is default staff
			item.noMelee = false; //so the item's animation doesn't do damage
            item.melee = true; //bonk them with the staff
			item.knockBack = 1;
			item.value = 10;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = 504; //mod.ProjectileType("LightBladeShot"); //this is a mod projectile
			item.shootSpeed = 5f;
		}
        //make it only shoot randomly not always
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int target = 0;

            if (Main.rand.Next(9) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, target, 0f);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Animus", 1);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}