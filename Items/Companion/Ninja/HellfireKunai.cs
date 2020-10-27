using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja
{
    public class HellfireKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Kunai");
            Tooltip.SetDefault("A fiery kunai"
			+ "\nRight click to swing" + "\nTier7 Ninja Class" + "\nMaterial");
        }
        public override void SetDefaults()
        {
            item.damage = 55;
            item.thrown = true;
            item.melee = false;
            item.width = 24;
            item.height = 24;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2.5f;
            item.value = 80;
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item17;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.HellfireKunaiProj>();
            item.shootSpeed = 14.0f;
            item.crit += 9;
            item.noMelee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneAxe", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.useTime = 17;
                item.useAnimation = 17;
                item.damage = 55;
                item.shoot = ProjectileID.None;
                item.noMelee = false;
                item.knockBack = 3.75f;
                item.UseSound = SoundID.Item1;
            }
            else
            {
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.useTime = 15;
                item.useAnimation = 15;
                item.damage = 50;
                item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.HellfireKunaiProj>();
            }
            return base.CanUseItem(player);
        }

    }
}