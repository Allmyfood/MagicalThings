using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Boots.Ninja
{
    [AutoloadEquip(EquipType.Shoes)]
    public class NinjaLightningJika : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Ninja Lightning Jika");
            Tooltip.SetDefault("Increases Throwing Damage and Crit by 10%" + "\nAllows flight" + "\nThe wearer can run incredibly fast");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 28;
            item.value = Item.sellPrice(gold: 6);
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NinjaSpectreJika", 1);
            recipe.AddIngredient(ItemID.AnkletoftheWind, 1);
            recipe.AddIngredient(ItemID.Aglet, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.1f; //10% thrown damage
            player.thrownCrit += 10; //10 thrown crit
            player.accRunSpeed = 6.75f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            player.rocketBoots = 2; //default Spectre boots rocket and lightning. Frostspark = 3;
            player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.iceSkate = true; //default frostspark/iceskate.
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
