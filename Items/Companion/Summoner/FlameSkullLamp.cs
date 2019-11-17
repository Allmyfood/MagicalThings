using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Summoner
{
	public class FlameSkullLamp : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flame Skeleton Lamp");
			Tooltip.SetDefault("Summons a fire spirit to help" + "\nTier7 Summoner Class" + "\nMaterial");
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.summon = true;
			item.mana = 10;
			item.width = 32;
			item.height = 18;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 2.0f;
            item.value = 80;
            item.rare = 7;
            item.UseSound = SoundID.Item25;
			item.shoot = mod.ProjectileType("FlameSkeletonProj");
			item.shootSpeed = 5f;
			item.buffType = mod.BuffType("FlameSkullBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FireRingScepter", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
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
