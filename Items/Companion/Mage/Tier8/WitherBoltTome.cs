using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Mage.Tier8
{
    public class WitherBoltTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Withering Bolt Tome");
            Tooltip.SetDefault("Fire a Withering Bolt"
            + "\nPasses through surfaces");
            Item.staff[item.type] = false; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.magic = true;
            item.melee = false;
            item.mana = 6;
            item.width = 28;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5; //Standard style including books
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.5f;
            item.value = 120;
            item.rare = 9;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("WitherBoltProj"); //this is a mod projectile
            item.shootSpeed = 16f;
        }
        //Shoot at desired angle. Shoot 2 at a distance of 1 degree from each other and spread out from there slowly
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            #region Shoot Multiple shots
            float numberProjectiles = 2; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(1);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f; //this defines the distance of the projectiles form the player when the projectile spawns
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f; // This defines the projectile roatation and speed. .4f == projectile speed
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
            #endregion
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNBook", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}