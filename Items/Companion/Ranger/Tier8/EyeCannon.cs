using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier8
{
	public class EyeCannon : ModItem
	{
        public static int counter = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye Cannon");
            Tooltip.SetDefault("Shoots Pulse Ammo bullets" 
                + "\n25% to not consume ammo" + "\nFires a powerful laser beam");
        }

        public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.Minishark);
			item.damage = 40;
			item.ranged = true;
			item.width = 66;
			item.height = 22;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 120;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item13;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder; //10 is default for guns.
            //item.shoot = ProjectileType<PebbleProj>();
            item.shootSpeed = 14.0f;
			//item.useAmmo = AmmoID.Bullet; //Normal ammos.
            item.useAmmo = ItemType<PulseAmmo>();
            item.channel = true;
            //item.scale = 0.75f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, 1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNBow", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

