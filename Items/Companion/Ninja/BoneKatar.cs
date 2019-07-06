using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja
{
	public class BoneKatar : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 45;
			item.melee = false;
            item.thrown = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 3.75f;
			item.value = 70;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.crit += 8;
            //item.shoot = 567; // mod.ProjectileType("InfestedProj");
            //item.shootSpeed = 8f;

        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Katar");
			Tooltip.SetDefault("A poisoned katar, strikes like a claw");
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TaintedKama", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.Spike, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 200);
            if (Main.rand.Next(5) == 0)
            {
                target.AddBuff(mod.BuffType("ArmorBreak"), 180); //60 is the buff time
            }
        }
    }
}
