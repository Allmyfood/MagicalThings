using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier5
{
    public class Infested : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infested Blade");
            Tooltip.SetDefault("A corrupted blade"
                + "\nMay rarely cause Bleeding debuff on hit.");
        }
        public override void SetDefaults()
        {
            item.damage = 25;
            item.melee = true;
            item.width = 42;
            item.height = 44;
            item.useTime = 22;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3.75f;
            item.value = 50;
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 7;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.InfestedProj>();
            item.shootSpeed = 5.5f;
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
            if (Main.rand.Next(24) == 0)
            {
                target.AddBuff(mod.BuffType("CutDebuff"), 160); //60 is the buff time
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GemBlade", 1);
            recipe.AddRecipeGroup("MagicalThings:Demonite Bar", 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}