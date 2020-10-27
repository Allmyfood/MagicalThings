using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage.Tier9
{
    public class SpectralFangTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Fang Tome");
            Tooltip.SetDefault("Summon a Spectral Fang"
            + "\nMay life steal on hit");
            Item.staff[item.type] = false; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 90;
            item.magic = true;
            item.melee = false;
            item.mana = 3;
            item.width = 28;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.5f;
            item.value = 150;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item104;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Mage.SpectralFangProj>(); //this is a mod projectile
            item.shootSpeed = 16f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WitherBoltTome", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}