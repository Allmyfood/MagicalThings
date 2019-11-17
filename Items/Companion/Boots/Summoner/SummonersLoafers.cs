using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Boots.Summoner
{
    [AutoloadEquip(EquipType.Shoes)]
    public class SummonersLoafers : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Summoners Loafers");
            Tooltip.SetDefault("Increases Minion Damage by 5% and Max Minions by 1");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 10;
            item.value = Item.sellPrice(silver: 1);
            item.rare = 1;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 4);
            recipe.AddIngredient(ItemID.Bunny, 1);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.05f; //5% minion damage
            player.maxMinions += 1; //Max minions
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
