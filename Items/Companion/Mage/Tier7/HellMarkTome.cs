using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier7
{
	public class HellMarkTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Create a Hell Mark at the cursor");
			//Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.magic = true;
            item.melee = false;
			item.mana = 12;
			item.width = 30;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 20;
            item.useStyle = 5; //Standard style including books and staves. Aka held out infront of the player
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 80;
			item.rare = 7;
			item.UseSound = SoundID.Item103;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("HellMarkProj"); //this is a mod projectile //585; //is skulls
			item.shootSpeed = 4f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //Get screen position with mouse cords. multiply velocity and set custom postion is distance from cursor position.
            //Then make a projectile based on new position and velocity from cursor.
            Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            position = SPos;
            Vector2 vel1 = new Vector2(-1, -1);
            vel1 *= 4f;
            Projectile.NewProjectile(position.X + 70, position.Y + 25, vel1.X, vel1.Y, mod.ProjectileType("HellMarkProj"), item.damage, 0, Main.myPlayer); //Bottom Right point
            Vector2 vel2 = new Vector2(1, 1);
            vel2 *= 4f;
            Projectile.NewProjectile(position.X - 46, position.Y - 60, vel2.X, vel2.Y, mod.ProjectileType("HellMarkProj"), item.damage, 0, Main.myPlayer); //Top Left point
            Vector2 vel3 = new Vector2(1, -1);
            vel3 *= 4f;
            Projectile.NewProjectile(position.X - 70, position.Y + 25, vel3.X, vel3.Y, mod.ProjectileType("HellMarkProj"), item.damage, 0, Main.myPlayer); //Bottom Left point
            Vector2 vel4 = new Vector2(-1, 1);
            vel4 *= 4f;
            Projectile.NewProjectile(position.X + 46, position.Y - 60, vel4.X, vel4.Y, mod.ProjectileType("HellMarkProj"), item.damage, 0, Main.myPlayer); //Top Right point
            Vector2 vel5 = new Vector2(0, -1);
            vel5 *= 4f;
            Projectile.NewProjectile(position.X, position.Y + 75, vel5.X, vel5.Y, mod.ProjectileType("HellMarkProj"), item.damage, 0, Main.myPlayer); //Inverse point
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DeathMark", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}