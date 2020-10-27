using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner
{
	public class BrokenLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a young Valkyrie to help" + "\nTier7 Summoner Class" + "\nMaterial");
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.summon = true;
			item.mana = 10;
			item.width = 40;
			item.height = 38;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 3.25f;
            item.value = 80;
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item25;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Minions.YoungValkyrieProj>();
			item.shootSpeed = 6f;
			item.buffType = mod.BuffType("YoungValkyrieBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FreeSpiritStaff", 1);
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
