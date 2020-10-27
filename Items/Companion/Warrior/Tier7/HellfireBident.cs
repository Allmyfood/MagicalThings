using MagicalThings.Projectiles.CompanionProj.Warrior;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier7
{
    public class HellfireBident : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A fiery bident" + "\nTier7 Melee Class" + "\nMaterial");
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 24;
            item.useAnimation = 24;			
			item.shootSpeed = 5.75f;
			item.knockBack = 5.75f;
			item.width = 66;
			item.height = 66;
			item.scale = 1f;
            item.value = 80;
            item.rare = ItemRarityID.Lime;
            item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<HellfireBidentProj>();
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneNaginata", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
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
