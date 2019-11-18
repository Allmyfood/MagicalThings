using MagicalThings.Projectiles.CompanionProj.Warrior;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier5
{
    public class CorruptSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("An awfully stiff worm");
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.useStyle = 5;
            item.useTime = 28;
            item.useAnimation = 28;			
			item.shootSpeed = 5.25f;
			item.knockBack = 4.75f;
			item.width = 66;
			item.height = 66;
			item.scale = 1f;
			item.rare = 5;
			item.value = Item.sellPrice(copper: 50);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<CorruptSpearProj>();
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LivingSpear", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}
	}
}
