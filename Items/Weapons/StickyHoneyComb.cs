using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Weapons
{
	//imported from Example mod because I'm lazy
	public class StickyHoneyComb : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a mess of wasps!"+"\nNot the BEES or WASPS!");
		}

		public override void SetDefaults()
		{
			item.damage = 48;
			item.summon = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = .5f;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item25;
			item.shoot = ProjectileType<Projectiles.Minions.WaspProj>();
			item.shootSpeed = 6f;
			item.buffType = mod.BuffType("WaspBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedBeehive", 1);
            recipe.AddIngredient(ItemID.Bezoar, 1);
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
