using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier5
{
	public class GrandEmberStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Grand Ember Staff");
            Tooltip.SetDefault("Fire 3 large fireballs");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.magic = true;
            item.melee = false;
			item.mana = 6;
			item.width = 48;
			item.height = 48;
			item.useTime = 22;
			item.useAnimation = 22;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2.5f;
			item.value = 50;
			item.rare = 5;
            item.UseSound = SoundID.Item9; //for default
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("LivingFireballProj"); //this is a mod projectile
			item.shootSpeed = 9f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(5);
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
            recipe.AddIngredient(null, "LivingEmber", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}