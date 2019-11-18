using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Mage
{
    public class PWNBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PWN Book");
            Tooltip.SetDefault("Fire a PWN Hammer!"
            + "\nReflects off surfaces" + "\nCraft with PwnHammer in inventory!");
            Item.staff[item.type] = false; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 70;
            item.magic = true;
            item.melee = false;
            item.mana = 15;
            item.width = 28;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.5f;
            item.value = 100;
            item.rare = 8;
            item.UseSound = SoundID.Item53;
            item.autoReuse = true;
            //item.shoot = 409; //ModContent.ProjectileType("HellBurstFireballProj"); //this is a mod projectile
            item.shoot = ModContent.ProjectileType<Projectiles.CompanionProj.Mage.PWNBookProj>();
            item.shootSpeed = 13f;
        }

        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    float numberProjectiles = 3; // This defines how many projectiles to shot
        //    float rotation = MathHelper.ToRadians(5);
        //    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
        //    for (int i = 0; i < numberProjectiles; i++)
        //    {
        //        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .8f; // This defines the projectile roatation and speed. .4f == projectile speed
        //        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
        //    }
        //    return false;
        //}

        public override void AddRecipes()
        {
            PWNBookRecipe recipe = new PWNBookRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Tier 7 Mage Class", 1);
            //recipe.AddIngredient(null, "HellMarkTome", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public class PWNBookRecipe : ModRecipe
        {
            public PWNBookRecipe(Mod mod) : base(mod)
            {
            }

            public override bool RecipeAvailable()
            {
                return Main.LocalPlayer.HasItem(ItemID.Pwnhammer);
            }
        }
    }
}