using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Boots.Ninja
{
    [AutoloadEquip(EquipType.Shoes)]
    public class NinjaJika : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Ninja Jika");
            Tooltip.SetDefault("Increases Throwing Damage and Crit by 5%");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(silver: 1);
            item.rare = 1;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 4);
            recipe.AddIngredient(ItemID.Shuriken, 2);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.05f; //5% thrown damage
            player.thrownCrit += 5; //5 thrown crit
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
