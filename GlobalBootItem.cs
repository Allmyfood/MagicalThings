using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ModLoader;
using TerraUI.Utilities;

namespace MagicalThings
{
    class GlobalBootItem : GlobalItem {
        public override bool Autoload(ref string name) {
            return true;
        }
        
        public override bool CanEquipAccessory(Item item, Player player, int slot) {
            if(item.shoeSlot > 0) {
                return true;
            }

            return base.CanEquipAccessory(item, player, slot);
        }

        public override bool CanRightClick(Item item) {
            if(item.shoeSlot > 0) {
                return true;
            }

            return base.CanRightClick(item);
        }

        public override void RightClick(Item item, Player player) {
            if(item.shoeSlot > 0) {
                MagicalPlayer mp = player.GetModPlayer<MagicalPlayer>(mod);

                if(KeyboardUtils.HeldDown(Keys.LeftShift)) {
                    mp.EquipShoes(true, item);
                }
                else {
                    mp.EquipShoes(false, item);
                }
            }
            else {
                base.RightClick(item, player);
            }
        }
    }
}
