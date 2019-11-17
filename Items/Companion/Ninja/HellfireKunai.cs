using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            item.useStyle = 1;
            item.knockBack = 2.5f;
            item.value = 80;
            item.rare = 7;
            item.UseSound = SoundID.Item17;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HellfireKunaiProj");
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
                item.useStyle = 1;
                item.useTime = 17;
                item.useAnimation = 17;
                item.damage = 55;
                item.shoot = 0;
                item.noMelee = false;
                item.knockBack = 3.75f;
                item.UseSound = SoundID.Item1;
            }
            else
            {
                item.useStyle = 1;
                item.useTime = 15;
                item.useAnimation = 15;
                item.damage = 50;
                item.shoot = mod.ProjectileType("HellfireKunaiProj");
            }
            return base.CanUseItem(player);
        }

    }
}