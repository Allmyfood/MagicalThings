using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier6
{
    public class BoneCutter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Cutter Blade");
            Tooltip.SetDefault("A blade that can cut through bone"
                + "\nMay cause Armor Break debuff on hit.");
        }
        public override void SetDefaults()
        {
            item.damage = 48;
            item.melee = true;
            item.width = 58;
            item.height = 58;
            item.useTime = 19;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2.50f;
            item.value = 100;
            item.rare = ItemRarityID.LightPurple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 11;
            //item.shoot = 21; // ModContent.ProjectileType("InfestedProj");
            //item.shootSpeed = 7.5f;
        }

        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    for (int i = 5; i <10; i++)
        //    {
        //        if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("ArmorBreak"), 240); //60 is the buff time
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Infested", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(null, "Infested", 1);
            //recipe.AddIngredient(ItemID.Bone, 20);
            //recipe.AddTile(TileID.Anvils);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }
    }
}