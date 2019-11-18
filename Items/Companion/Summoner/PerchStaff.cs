using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner
{
	//imported from Example mod because I'm lazy
	public class PerchStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a blue jay to help" + "\nUses 1 minion slot");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.summon = true;
			item.mana = 10;
			item.width = 24;
			item.height = 24;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 1;
            item.value = 20;
            item.rare = 1;
			item.UseSound = SoundID.Item25;
			item.shoot = ProjectileType<Projectiles.CompanionProj.JaySpriteProj>();
			item.shootSpeed = 6f;
			item.buffType = mod.BuffType("JayBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WindOrb", 1);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddIngredient(ItemID.BlueBerries, 1);
            recipe.AddTile(TileID.WorkBenches);
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
