using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Boots.Warrior
{
    [AutoloadEquip(EquipType.Shoes)]
    public class LightningGladiators : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Lightning Gladiators");
            Tooltip.SetDefault("Increases Melee Damage and Speed by 10%" + "\nAllows flight" + "\nThe wearer can run incredibly fast");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 28;
            item.value = Item.sellPrice(gold: 6);
            item.rare = 4;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpectreGladiators", 1);
            recipe.AddIngredient(ItemID.AnkletoftheWind, 1);
            recipe.AddIngredient(ItemID.Aglet, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.1f; //10% melee damage
            player.meleeSpeed += 0.1f; //10% melee speed
            player.accRunSpeed = 6.75f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            player.rocketBoots = 2; //default Spectre boots rocket and lightning. Frostspark = 3;
            player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.iceSkate = true; //default frostspark/iceskate.
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
