using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Summoner
{
	public class PWNCrystalStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PWN Crystal Staff");
			Tooltip.SetDefault("Summons a magic crystal to help" + "\nCraft with PwnHammer in inventory!");
		}

		public override void SetDefaults()
		{
			item.damage = 70;
			item.summon = true;
			item.mana = 10;
			item.width = 52;
			item.height = 52;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 4.25f;
            item.value = 100;
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item25;
			item.shoot = ProjectileType<Projectiles.CompanionProj.Minions.PWNCrystalProj>();
			item.shootSpeed = 6f;
			item.buffType = mod.BuffType("PWNCrystalBuff");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
        public override void AddRecipes()
        {
            PWNSummonRecipe recipe = new PWNSummonRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Tier 7 Summoner Class", 1);
            //recipe.AddIngredient(null, "HellMarkTome", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public class PWNSummonRecipe : ModRecipe
        {
            public PWNSummonRecipe(Mod mod) : base(mod)
            {
            }

            public override bool RecipeAvailable()
            {
                return Main.LocalPlayer.HasItem(ItemID.Pwnhammer);
            }
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
