using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner.Tier8
{
	public class PathOfEvil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Path of Evil");
			Tooltip.SetDefault("Summon malevolent animated weapons to do your bidding");
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.summon = true;
			item.mana = 10;
			item.width = 28;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4.0f;
            item.value = 120;
            item.rare = 9;
            item.UseSound = SoundID.Item25;
            item.shoot = ProjectileType<Projectiles.ExplosionFake>();
			item.shootSpeed = 5f;
			item.buffType = mod.BuffType("PoEBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNCrystalStaff", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            int target = 0;
            int choice = Main.rand.Next(2);
            if(choice == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<Projectiles.CompanionProj.Minions.ShadowHammerProj>(), damage, knockBack, player.whoAmI, target, 0f);
            }
            else if (choice == 1)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<Projectiles.CompanionProj.Minions.BloodAxeProj>(), damage, knockBack, player.whoAmI, target, 0f);
            }
            return player.altFunctionUse != 2;
        }

        public override bool UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
	}
}
