using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja.Tier8
{
    public class MechSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mech Saber");
            Tooltip.SetDefault("A mechanized saber"
			+ "\nRight click to throw a smoke bomb");
        }
        public override void SetDefaults()
        {
            item.damage = 80;
            item.thrown = true;
            item.melee = false;
            item.width = 30;
            item.height = 33;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = 120;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            //item.shoot = ProjectileType<PWNDaggerProj>();
            item.shootSpeed = 11.0f;
            item.crit += 14;
            item.noMelee = false;
            item.noUseGraphic = false;
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

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                item.damage = 80;
                item.shoot = 0;
                item.noUseGraphic = false;
                item.noMelee = false;
                item.useTime = 13;
                item.useAnimation = 13;
            }

            if (player.altFunctionUse == 2)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.damage = 1;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.BlindPowderProj>();
            }
            return base.CanUseItem(player);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.immune[item.owner] = 6;
            target.AddBuff(mod.BuffType("ArmorBreak"), 120);
        }

    }
}