using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner.Tier9
{
	public class DoomSpectreStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doom Spectre Staff");
			Tooltip.SetDefault("Summons a spectre of doom to do your bidding");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.summon = true;
			item.mana = 10;
			item.width = 29;
			item.height = 29;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4.0f;
            item.value = 150;
            item.rare = 9;
            item.UseSound = SoundID.Item25;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Minions.DoomSpectreProj>();
			item.shootSpeed = 5f;
			item.buffType = mod.BuffType("DoomSpectreBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PathOfEvil", 1);
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
