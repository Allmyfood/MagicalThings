using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier8
{
    public class HallowedShieldTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Magna Clipeum!"
                + "\nA protective shield that fires at enemies");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            //item.damage = 70;
            item.magic = true;
            item.melee = false;
            item.mana = 20;
            item.width = 28;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3;
            item.value = 120;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.buffType = mod.BuffType("HallowedArmorBuff");
            //item.shoot = ProjectileType<VolcanoProj>(); //this is a mod projectile
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
            if (!player.HasBuff(mod.BuffType("HallowedShieldBuff")) && !player.HasBuff(mod.BuffType("VortexShieldBuff")))
            {
                if (!player.HasBuff(mod.BuffType("HallowedArmorBuff")))
                {
                    return true;
                }
            }
            return false; 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNBook", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}