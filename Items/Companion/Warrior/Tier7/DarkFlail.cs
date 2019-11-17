using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier7
{
    public class DarkFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Dark Flail");
            Tooltip.SetDefault("A shadowy flail" + "\nTier7 Melee Class" + "\nMaterial");
        }
        public override void SetDefaults()
        {
            item.damage = 60;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.width = 33;
            item.height = 34;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.knockBack = 6.5f;
            item.value = 80;
            item.rare = 7;
            item.scale = 1.1f;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("DarkFlailProj");
            item.shootSpeed = 15.75f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SkullFlail", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
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
            target.AddBuff(BuffID.ShadowFlame, 180);
        }
    }
}