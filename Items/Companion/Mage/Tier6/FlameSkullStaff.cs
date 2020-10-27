using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier6
{
	public class FlameSkullStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Flame Skull Staff");
            Tooltip.SetDefault("Fire a large skull fireball");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.magic = true;
            item.melee = false;
			item.mana = 8;
			item.width = 52;
			item.height = 56;
			item.useTime = 20;
			item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2.5f;
			item.value = 70;
			item.rare = ItemRarityID.LightPurple;
            item.UseSound = SoundID.Item72; //for default
			item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.FlameSkullProj>(); //this is a mod projectile
			item.shootSpeed = 9f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GrandEmberStaff", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.FlowerofFire, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}