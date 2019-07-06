using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Summoner
{
	//imported from Example mod because I'm lazy
	public class CrimsonDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons an enchanted dagger to help");
		}

		public override void SetDefaults()
		{
			item.damage = 6;
			item.summon = true;
			item.mana = 10;
			item.width = 24;
			item.height = 57;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = .5f;
			item.value = Item.buyPrice(0, 0, 0, 30);
			item.rare = 3;
			item.UseSound = SoundID.Item25;
			item.shoot = mod.ProjectileType("CrimsonDaggerProj");
			item.shootSpeed = 5f;
			item.buffType = mod.BuffType("CrimsonDaggerBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CardinalWand", 1);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CardinalWand", 1);
            recipe.AddIngredient(ItemID.LeadBar, 2);
            recipe.AddIngredient(ItemID.Ruby, 1);
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
