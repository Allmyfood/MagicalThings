using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja
{
	public class BurningBloodDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 55;
			item.melee = false;
            item.thrown = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 3.75f;
			item.value = 80;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.crit += 11;
            //item.shoot = 567; // ModContent.ProjectileType("InfestedProj");
            //item.shootSpeed = 8f;

        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Blood Dagger");
			Tooltip.SetDefault("A fiery dagger, strikes like a claw" + "\nTier7 Ninja Class" + "\nMaterial");
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneKatar", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 200);
            target.immune[item.owner] = 7;
            if (Main.rand.Next(5) == 0)
            {
                target.AddBuff(mod.BuffType("ArmorBreak"), 180); //60 is the buff time
            }
        }
    }
}
