using MagicalThings.Projectiles.CompanionProj.Warrior;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier6
{
    public class BoneNaginata : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("An ancient naginata ");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.useStyle = 5;
            item.useTime = 26;
            item.useAnimation = 26;			
			item.shootSpeed = 5.75f;
			item.knockBack = 5.25f;
			item.width = 66;
			item.height = 66;
			item.scale = 1f;
			item.rare = 6;
			item.value = Item.sellPrice(copper: 70);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType<BoneNaginataProj>();
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CorruptSpear", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.DarkLance, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(null, "LivingSpear", 1);
            //recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            //recipe.AddTile(TileID.DemonAltar);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}
	}
}
