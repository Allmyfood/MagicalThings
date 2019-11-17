using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier9
{
    public class SpectralRingTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Magna Clipeum et Circulum!"
                + "\nA protective shield that fires at enemies");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 90;
            item.magic = true;
            item.melee = false;
            item.mana = 20;
            item.width = 28;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 13;
            item.value = 150;
            item.rare = 9;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.buffType = mod.BuffType("HallowedShieldBuff");
            //item.shoot = mod.ProjectileType("VolcanoProj"); //this is a mod projectile
            //item.shootSpeed = 4.5f; //not needed for stationary sentry
            //item.sentry = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 2, true);
            }
        }

        public override bool CanUseItem(Player player)
        {
            if (!player.HasBuff(mod.BuffType("HallowedArmorBuff")) && !player.HasBuff(mod.BuffType("VortexShieldBuff")))
            {
                if (!player.HasBuff(mod.BuffType("HallowedShieldBuff")))
                {
                    return true;
                }
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedShieldTome", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}