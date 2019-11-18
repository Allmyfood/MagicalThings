using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner
{
	public class FreeSpiritStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a freed spirit to help");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.summon = true;
			item.mana = 10;
			item.width = 42;
			item.height = 42;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 2.25f;
            item.value = 70;
            item.rare = 6;
            item.UseSound = SoundID.Item25;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Minions.FreeSpiritProj>();
			item.shootSpeed = 6f;
			item.buffType = mod.BuffType("FreeSpiritBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SidheStaff", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.MagicMissile, 1);
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
