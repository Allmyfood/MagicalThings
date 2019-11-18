using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ninja
{
    public class PWNDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PWN Dagger");
            Tooltip.SetDefault("A PWN Dagger"
			+ "\nRight click to swing" + "\nCraft with PwnHammer in inventory!");
        }
        public override void SetDefaults()
        {
            item.damage = 70;
            item.thrown = true;
            item.melee = false;
            item.width = 26;
            item.height = 28;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 2.5f;
            item.value = 100;
            item.rare = 8;
            item.UseSound = SoundID.Item17;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.PWNDaggerProj>();
            item.shootSpeed = 14.0f;
            item.crit += 10;
            item.noMelee = true;
        }

        public override void AddRecipes()
        {
            PWNDaggerRecipe recipe = new PWNDaggerRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Tier 7 Ninja Class", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public class PWNDaggerRecipe : ModRecipe
        {
            public PWNDaggerRecipe(Mod mod) : base(mod)
            {
            }

            public override bool RecipeAvailable()
            {
                return Main.LocalPlayer.HasItem(ItemID.Pwnhammer);
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 1;
                item.useTime = 16;
                item.useAnimation = 16;
                item.damage = 80;
                item.shoot = 0;
                item.noMelee = false;
                item.knockBack = 3.75f;
                item.UseSound = SoundID.Item1;
            }
            else
            {
                item.useStyle = 1;
                item.useTime = 15;
                item.useAnimation = 15;
                item.damage = 70;
                item.shoot = ProjectileType<Projectiles.CompanionProj.Ninja.PWNDaggerProj>();
            }
            return base.CanUseItem(player);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 210);            
        }

    }
}