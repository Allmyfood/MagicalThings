using MagicalThings.Projectiles.CompanionProj.Warrior;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier8
{
    public class PrimeSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prime Spear");
			Tooltip.SetDefault("An infinitely throwable spear" + "\nWill impale the enemy");
		}

		public override void SetDefaults()
		{
			item.damage = 80;
			item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 16;
            item.useAnimation = 16;			
			item.shootSpeed = 16.75f;
			item.knockBack = 5.75f;
			item.width = 66;
			item.height = 66;
			//item.scale = 1f;
            item.value = 120;
            item.rare = ItemRarityID.Cyan;
            item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<PrimeSpearProj>();
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNSword", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
