using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TerraUI.Utilities;

namespace MagicalThings
{
    internal class GlobalBootItem : GlobalItem
    {
        //public override bool Autoload(ref string name) {
        //    return true;
        //}
        public override bool CanEquipAccessory(Item item, Player player, int slot)//new conditional style
        {
            return item.shoeSlot > 0 && MagicalThingsServerConfig.Instance.EnableBootslot == true
                ? MagicalThings.AllowShoesInAccessorySlots
                : base.CanEquipAccessory(item, player, slot);
        }

        //public override bool CanEquipAccessory(Item item, Player player, int slot)//Changed to conditional statement
        //{
        //    if (item.shoeSlot > 0 && MagicalThingsServerConfig.Instance.EnableBootslot == true)
        //    {
        //        return MagicalThings.AllowShoesInAccessorySlots;
        //    }

        //    return base.CanEquipAccessory(item, player, slot);
        //}

        //old version
        //public override bool CanEquipAccessory(Item item, Player player, int slot)
        //{
        //    bool AllowShoesInAccessorySlots = (bool)MagicalThings.Config.Get(MagicalThings.AllowShoesInAccessorySlots);
        //    return ((item.shoeSlot > 0) && allowAccessorySlots) || base.CanEquipAccessory(item, player, slot);
        //}

        public override bool CanRightClick(Item item)//conditional expression
        {
            return MagicalThingsServerConfig.Instance.EnableBootslot == true
                ? item.shoeSlot > 0 && !MagicalThings.OverrideRightClick()
                : base.CanRightClick(item);
        }

        //public override bool CanRightClick(Item item)//regular
        //{
        //    if (MagicalThingsServerConfig.Instance.EnableBootslot == true)
        //    {
        //        return (item.shoeSlot > 0 && !MagicalThings.OverrideRightClick());
        //    }
        //    return base.CanRightClick(item);
        //}

        public override void RightClick(Item item, Player player) {
            if (!CanRightClick(item))
            {
                return;
            }

            MagicalPlayer mp = player.GetModPlayer<MagicalPlayer>();
            mp.EquipShoes(KeyboardUtils.HeldDown(Keys.LeftShift), item);
        }
    }
}
