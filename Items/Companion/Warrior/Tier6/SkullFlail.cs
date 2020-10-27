using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier6
{
    public class SkullFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Skull Flail");
            Tooltip.SetDefault("A skull-fashioned flail");
        }
        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6;
            item.value = 70;
            item.rare = ItemRarityID.LightPurple;
            item.scale = 1.1f;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Warrior.SkullFlailProj>();
            item.shootSpeed = 15.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "InfestedFlail", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.BlueMoon, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(null, "SlimeLeash", 1);
            //recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            //recipe.AddTile(TileID.DemonAltar);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }
        //public override void MeleeEffects(Player player, Rectangle hitbox)
        //{
        //    if (Main.rand.Next(3) == 0)
        //    {
        //        int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
        //    }
        //}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused, 120);
        }
    }
}