using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja.Tier9
{
    public class SpectralLabrys : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Labrys");
            Tooltip.SetDefault("A spirit-powered homing axe");
        }
        public override void SetDefaults()
        {
            item.damage = 90;
            item.thrown = true;
            item.melee = false;
            item.width = 34;
            item.height = 34;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = 150;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SpectralLabrysProj");
            item.shootSpeed = 14.0f;
            item.crit += 15;
        }

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PrimeAxe", 1);
			recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		//public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        //{
            //target.AddBuff(BuffID.OnFire, 180);
        //}
    }
}