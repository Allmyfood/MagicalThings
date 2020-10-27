using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
	public class Animus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Animation Scroll");
			Tooltip.SetDefault("Used in the creation of companion weapons"
                +"\nCan only be used once"
                +"\nChoose your class wisely");
		}
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.rare = ItemRarityID.Purple;
            item.value = Item.buyPrice(silver: 1);
            item.maxStack = 1;
        }
    }
}