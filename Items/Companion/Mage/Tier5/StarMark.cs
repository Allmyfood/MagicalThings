using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier5
{
	public class StarMark : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Create a Star Mark at the cursor");
			//Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.magic = true;
            item.melee = false;
			item.mana = 7;
			item.width = 28;
			item.height = 32;
			item.useTime = 22;
			item.useAnimation = 22;
            item.useStyle = 5; //Standard style including books and staves. Aka held out infront of the player
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 50;
			item.rare = 5;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarMarkProj"); //this is a mod projectile
			item.shootSpeed = 1f;
		}
        //Shoot multiple projectiles in an even ark.
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mousePosition = Main.MouseWorld;
            float posX = mousePosition.X; //top point of star
            float posY = mousePosition.Y + -75;
            float pos2X = mousePosition.X + 70; //upper right point
            float pos2Y = mousePosition.Y + -25;
            float pos3X = mousePosition.X + -70; //upper left point
            float pos3Y = mousePosition.Y + -25;
            float pos4X = mousePosition.X + 46; //lower right point
            float pos4Y = mousePosition.Y + 60;
            float pos5X = mousePosition.X + -46; //lower left point
            float pos5Y = mousePosition.Y + 60;
            for (int i = 1; i < 5; ++i) // Will shoot 5 bullets.
            {
                Projectile.NewProjectile(posX, posY, speedX*.2f, speedY*.2f, type, damage, knockBack, Main.myPlayer);
                Projectile.NewProjectile(pos2X, pos2Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
                Projectile.NewProjectile(pos3X, pos3Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
                Projectile.NewProjectile(pos4X, pos4Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
                Projectile.NewProjectile(pos5X, pos5Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LivingStarSpinner", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}