using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class IvoryMagnum : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ivory Magnum");
            Tooltip.SetDefault("Shoots standard bullets" 
                + "\nMay sometimes not consume bullets");
        }

        public override void SetDefaults()
		{

			item.damage = 45;
			item.ranged = true;
			item.width = 52;
			item.height = 38;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 70;
			item.rare = 6;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //10 is default for guns.
            //item.shoot = ProjectileType<PebbleProj>();
            item.shootSpeed = 12.75f;
			item.useAmmo = AmmoID.Bullet; //Normal ammos.
            //item.useAmmo = ModContent.ItemType("Pebble");
            item.scale = 0.75f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, -3);
        }

        //50% chance not to consume ammo
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CrustyPistol", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.Handgun, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
