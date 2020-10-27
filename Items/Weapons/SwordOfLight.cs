using MagicalThings.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Weapons
{
    public class SwordOfLight : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Sword of Light");
            Tooltip.SetDefault("A powerful blade of light");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = item.value = Item.buyPrice(gold: 50);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileType<SwordOfLightProj>();
            item.shootSpeed = 7.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LightBlade", 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169);
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 300);
        }

    }
}