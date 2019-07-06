using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Dev.Maverick
{
	public class MaverickStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Maverick");
            Tooltip.SetDefault("Soul Stealing Staff"
                +"\nDev Item for Tax, WIP");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
            item.damage = 365;
			item.magic = true;
            item.melee = false;
			item.mana = 1;
			item.width = 58;
			item.height = 58;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = .5f;
            item.value = 50000;
			item.rare = 9;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MaverickProj"); //this is a mod projectile
            item.shootSpeed = 3f;
        }

        public override void UseStyle(Player player)
        {
            player.itemLocation.X -= 5f * player.direction;
            player.itemLocation.Y += 15f * player.gravDir;
        }

        //Shoot multiple projectiles in an even ark.
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 8; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(270);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .8f; // This defines the projectile roatation and speed. .4f == projectile speed
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;
        }

        public override void AddRecipes()
        {

        }
    }
}