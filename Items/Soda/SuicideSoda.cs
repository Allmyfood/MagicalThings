using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Soda
{
    public class SuicideSoda : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suicide Soda"); //In game item name
            Tooltip.SetDefault("Combines all Sodas; 25% chance to kill the player"); //Tooltip info
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WormholePotion);
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SodaCan");  //SoundID.Item3;                //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 999;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 16; //20
            item.height = 24; //28
            item.value = 100;                
            item.rare = 1;
            item.buffType = mod.BuffType("SuicideSodaBuff");    //this is where you put your Buff name
            item.buffTime = 200000;    //this is the buff duration        20000 = 6 min
            return;
        }

        public override void OnConsumeItem(Player player)
        {
            if (Main.rand.Next(4) == 0)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), CombatText.DamagedFriendly, 0.ToString(), false, false);
                player.showLastDeath = true;
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " heart stopped from sugar overload"), 0, 0, false);
                player.ClearBuff(mod.BuffType("SuicideSodaBuff")); //Clears but B quick buff bypasses item use.
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperCoin, 10);
            recipe.AddTile(null, "SodaMachineBox");
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverCoin, 1);
            recipe.AddTile(null, "SodaMachineBox");
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}