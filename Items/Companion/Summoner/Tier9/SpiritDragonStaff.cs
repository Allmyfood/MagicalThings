using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Summoner.Tier9
{
	public class SpiritDragonStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Dragon Staff");
			Tooltip.SetDefault("Summons a baby Spirit Dragon to fight for you");
		}

		public override void SetDefaults()
		{
			item.damage = 120;
			item.summon = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 5.0f;
            item.value = 150;
            item.rare = 9;
            item.UseSound = SoundID.Item25;
            item.shoot = mod.ProjectileType("SpiritDragonProj");
			item.shootSpeed = 5f;
			item.buffType = mod.BuffType("SpiritDragonBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PathOfVirtue", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
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
