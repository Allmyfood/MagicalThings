using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner
{
	//imported from Example mod because I'm lazy
	public class FluffyWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a crimson puff to help");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 26;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = .75f;
			item.value = Item.buyPrice(0, 0, 0, 40);
			item.rare = 4;
			item.UseSound = SoundID.Item25;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Minions.CrimsonPuffProj>();
			item.shootSpeed = 5f;
			item.buffType = mod.BuffType("CrimsonPuffBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CrimsonDagger", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
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
