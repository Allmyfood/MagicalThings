using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
	public class SkeletalBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skeletal Bow");
            Tooltip.SetDefault("A bone bow" 
                + "\n May sometimes not consume ammo");
        }

        public override void SetDefaults()
		{

			item.damage = 45;
			item.ranged = true;
			item.width = 26;
			item.height = 48;
			item.useTime = 17;
            item.useAnimation = 17;
            item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 13f;			
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2.25f;
			item.value = 70;
			item.rare = ItemRarityID.LightPurple;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, -1);
        }

        //50% chance not to consume ammo
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TaintedBow", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.Spike, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
