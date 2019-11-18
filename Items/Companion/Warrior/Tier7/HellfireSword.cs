using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier7
{
    public class HellfireSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Sword");
            Tooltip.SetDefault("A searing hot blade"
                + "\nMay cause Armor Break debuff on hit" + "\nTier7 Melee Class" + "\nMaterial");
        }
        public override void SetDefaults()
        {
            item.damage = 55;
            item.melee = true;
            item.width = 60;
            item.height = 54;
            item.useTime = 18;
            item.useAnimation = 17;
            item.useStyle = 1;
            item.knockBack = 3.50f;
            item.value = 100;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 13;
            item.shoot = 15; // ModContent.ProjectileType("InfestedProj");
            item.shootSpeed = 17.5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int target = 0;

            if (Main.rand.Next(6) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, target, 0f);
            }
            return false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("ArmorBreak"), 240); //60 is the buff time
                target.AddBuff(BuffID.OnFire, 180);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneCutter", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}