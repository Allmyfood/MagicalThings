using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
 
namespace MagicalThings.Items
{
    public class Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Brew"); //In game item name
            Tooltip.SetDefault("Incresed defense by 100, life regen, melee damage and inferno buff"); //Tooltip info
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WormholePotion);
            item.UseSound = SoundID.Item3;                //this is the sound that plays when you use the item
            item.useStyle = ItemUseStyleID.EatingUsing;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 1;                 //this is where you set the max stack of item
            item.consumable = false;           //this make that the item is consumable when used
            item.width = 20; //20
            item.height = 28; //28
            item.value = 100;                
            item.rare = ItemRarityID.Blue;
            item.buffType = mod.BuffType("PotionBuff");    //this is where you put your Buff name
            item.buffTime = 20000;    //this is the buff duration        20000 = 6 min
            return;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumCoin, 1);
            recipe.AddTile(null, "SodaMachineBox");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}