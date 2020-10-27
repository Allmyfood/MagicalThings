using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items            //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class AirBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Remove water with Explosions!");
        }
        public override void SetDefaults()
        {
            item.damage = 0;     //The damage stat for the Weapon.                  
            item.width = 22;    //sprite width
            item.height = 30;   //sprite height
            item.maxStack = 999;   //This defines the items max stack
            item.consumable = true;  //Tells the game that this should be used up once fired
            item.useStyle = ItemUseStyleID.SwingThrow;   //The way your item will be used, 1 is the regular sword swing for example
            item.rare = ItemRarityID.LightRed;     //The color the title of your item when hovering over it ingame
            item.UseSound = SoundID.Item1; //The sound played when using this item
            item.useAnimation = 20;  //How long the item is used for.
            item.useTime = 20;     //How fast the item is used.
            item.value = Item.buyPrice(0, 0, 3, 0);   //How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 3 silver)
            item.noUseGraphic = true;
            item.noMelee = true;      //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            item.shoot = ProjectileType<Projectiles.AirBombProj>(); //This defines what type of projectile this item will shoot
            item.shootSpeed = 5f; //This defines the projectile speed when shot
        }
        public override void AddRecipes()   //This defines the crafting recepe for this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 20); //this is how to add an ingredient from Terraria,  so for crafting this item you need 15 bombs          
            recipe.AddIngredient(ItemID.Bomb, 1);
            recipe.AddIngredient(ItemID.Cloud, 1);
            recipe.AddTile(TileID.MythrilAnvil);   //this is where to craft the item ,WorkBenches = all WorkBenches    Anvils = all anvils , MythrilAnvil = Mythril Anvil and Orichalcum Anvil, Furnaces = all furnaces , DemonAltar = Demon Altar and Crimson Altar , TinkerersWorkbench = Tinkerer's Workbench
            recipe.SetResult(this, 15);   //this defines the result of the crafting, so 15 dynamite + 1 customtileitem = 15 Custom Explosive
            recipe.AddRecipe();
        }
    }
}