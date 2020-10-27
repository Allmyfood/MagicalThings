using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja.Tier8
{
    public class PrimeAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Axe");
            Tooltip.SetDefault("A mechanical axe that may shoot lasers");
        }
        public override void SetDefaults()
        {
            item.damage = 80;
            item.thrown = true;
            item.melee = false;
            item.width = 48;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4.5f;
            item.value = 120;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.PrimeAxeProj>();
            item.shootSpeed = 13.75f;
            item.crit += 14;
        }

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PWNDagger", 1);
			recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
                target.AddBuff(mod.BuffType("ArmorBreak"), 210); //60 is the buff time
        }
    }
}