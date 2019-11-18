using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Dev.Mugen
{
	public class MugenBlade : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mugen");
            Tooltip.SetDefault("Limitless Potential"
                +"\nDev Item, WIP");
        }

        public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Arkhalis);
			item.damage = 520;
            item.width = 40;
            item.height = 62;
            item.melee = true;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            //item.noMelee = true;
            item.value = 500000;
            item.rare = 9;
            item.shoot = ProjectileType<Projectiles.MugenProj>();
            item.shootSpeed = 15;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ProjectileType<Projectiles.MugenProj>();
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("ArmorBreak"), 2400); //60 is the buff time
                target.AddBuff(BuffID.WeaponImbueCursedFlames, 2400);
            }
        }

        public override void AddRecipes()
		{

        }
	}
}
