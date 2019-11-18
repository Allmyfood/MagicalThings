using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier6
{
    public class BookOfSpellsV5 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Magna Draco Cranium!"
                +"\nThe Dragon Skull!");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.magic = true;
            item.melee = false;
            item.mana = 18;
            item.width = 28;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5; // 5; //Is default staff
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3;
            item.value = 70;
            item.rare = 6;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.DragonSkullProj>(); //this is a mod projectile
            //item.shootSpeed = 4.5f; //not needed for stationary sentry
            item.sentry = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BookOfSpellsV4", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.BookofSkulls, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);   //this make so the projectile will spawn at the mouse cursor position
            position = SPos;
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  //this make so you can only spawn one of this projectile at the time,
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }
    }
}