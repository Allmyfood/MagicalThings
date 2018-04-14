using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Weapons
{
	//imported from Example mod because I'm lazy
	public class EnchantedBeehive : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a mess of bees!"+"\nNot the BEES!");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.summon = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = .5f;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item25;
			item.shoot = mod.ProjectileType("SwarmProj");
			item.shootSpeed = 6f;
			item.buffType = mod.BuffType("SwarmBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledHoney, 1);
            recipe.AddIngredient(ItemID.BeeWax, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
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
