using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ranger
{
	public class CrustyPistol : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crusty Pistol");
            Tooltip.SetDefault("Shoots standard bullets" 
                + "\nMay sometimes not consume bullets");
        }

        public override void SetDefaults()
		{

			item.damage = 24;
			item.ranged = true;
			item.width = 42;
			item.height = 32;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 50;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //10 is default for guns.
            //item.shoot = mod.ProjectileType("PebbleProj");
            item.shootSpeed = 11.75f;
			item.useAmmo = AmmoID.Bullet; //Normal ammos.
            //item.useAmmo = mod.ItemType("Pebble");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, -3);
        }

        //40% chance not to consume ammo
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .40f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SlimeCannon", 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SlimeCannon", 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
