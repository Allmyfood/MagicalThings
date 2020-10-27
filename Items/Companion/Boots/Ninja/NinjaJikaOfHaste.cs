using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Boots.Ninja
{
    [AutoloadEquip(EquipType.Shoes)]
    public class NinjaJikaOfHaste : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Ninja Jika of Haste");
            Tooltip.SetDefault("Increases Throwing Damage and Crit by 5%" + "\nThe wearer can run super fast");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Hermes Boots", 1);
            recipe.AddIngredient(null, "NinjaJika", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.05f; //5% thrown damage
            player.thrownCrit += 5; //5 thrown crit
            player.accRunSpeed = 6.0f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            //player.rocketBoots = 2; //default Spectre boots rocket and lightning. Frostspark = 3;
            //player.iceSkate = true; //default frostspark/iceskate.
            //player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
