using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Boots.Warrior
{
    [AutoloadEquip(EquipType.Shoes)]
    public class FrostsparkGladiators : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Frostspark Gladiators");
            Tooltip.SetDefault("Increases Melee Damage and Speed by 12%" + "\nAllows flight, super fast running, and extra mobility on ice" + "\n7% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(gold: 7);
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LightningGladiators", 1);
            recipe.AddIngredient(ItemID.IceSkates, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.12f; //12% melee damage
            player.meleeSpeed += 0.12f; //12% melee speed
            player.accRunSpeed = 6.75f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            player.rocketBoots = 3; //default Spectre boots rocket and lightning. Frostspark = 3;
            player.iceSkate = true; //default frostspark/iceskate.
            player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
