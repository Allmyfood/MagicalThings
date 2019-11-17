using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Summoner
{
	//imported from Example mod because I'm lazy
	public class ServantWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a eye to help");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.summon = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 1.75f;
            item.value = 50;
            item.rare = 5;
            item.UseSound = SoundID.Item25;
			item.shoot = mod.ProjectileType("ServantProj");
			item.shootSpeed = 5f;
			item.buffType = mod.BuffType("ServantBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FluffyWand", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
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
