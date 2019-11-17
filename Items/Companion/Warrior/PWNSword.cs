using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior
{
    public class PWNSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PWN Sword");
            Tooltip.SetDefault("A searing hot blade"
                + "\nMay cause Armor Break debuff on hit" + "\nCraft with PwnHammer in inventory!");
        }
        public override void SetDefaults()
        {
            item.damage = 75;
            item.melee = true;
            item.width = 52;
            item.height = 52;
            item.useTime = 17;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 4.50f;
            item.value = 100;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 14;
            item.shoot = 280; // mod.ProjectileType("InfestedProj");
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
            target.AddBuff(BuffID.Ichor, 210);
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("ArmorBreak"), 240); //60 is the buff time                
            }
        }

        public override void AddRecipes()
        {
            PWNSwordRecipe recipe = new PWNSwordRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Tier 7 Melee Class", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public class PWNSwordRecipe : ModRecipe
        {
            public PWNSwordRecipe(Mod mod) : base(mod)
            {
            }

            public override bool RecipeAvailable()
            {
                return Main.LocalPlayer.HasItem(ItemID.Pwnhammer);
            }
        }
    }
}