using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            //item.melee = true;
            //item.useTime = 10;
            //item.useAnimation = 10;
            //item.useStyle = 1;
            item.value = 50000;
            item.rare = 11;
            item.shoot = mod.ProjectileType("MugenProj");
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("MugenProj");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
		{

        }
	}
}
