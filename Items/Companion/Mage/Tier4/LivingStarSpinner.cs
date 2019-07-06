using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier4
{
	public class LivingStarSpinner : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots 3 spinning stars");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.magic = true;
            item.melee = false;
			item.mana = 5;
			item.width = 48;
			item.height = 48;
			item.useTime = 26;
			item.useAnimation = 26;
            item.useStyle = 5; //Standard style including books and staves. Aka held out infront of the player
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 40;
			item.rare = 4;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarSpinnerProj"); //this is a mod projectile
			item.shootSpeed = 3f;
		}
        //Shoot multiple projectiles in an even ark.
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(15);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .8f; // This defines the projectile roatation and speed. .4f == projectile speed
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarSpinnerStaff", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}