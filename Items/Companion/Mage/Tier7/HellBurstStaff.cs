using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier7
{
	public class HellBurstStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Hell Burst Staff");
            Tooltip.SetDefault("Fire a large fireball"
			+ "\nexplodes into homing bolts" + "\nTier7 Mage Class" + "\nMaterial");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.magic = true;
            item.melee = false;
			item.mana = 10;
			item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3.5f;
			item.value = 80;
			item.rare = 7;
            item.UseSound = SoundID.Item73; //for default
			item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.HellBurstFireballProj>(); //this is a mod projectile
			item.shootSpeed = 12f;
		}

        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    float numberProjectiles = 3; // This defines how many projectiles to shot
        //    float rotation = MathHelper.ToRadians(5);
        //    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
        //    for (int i = 0; i < numberProjectiles; i++)
        //    {
        //        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .8f; // This defines the projectile roatation and speed. .4f == projectile speed
        //        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
        //    }
        //    return false;
        //}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FlameSkullStaff", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}