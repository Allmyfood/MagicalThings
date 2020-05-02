using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace MagicalThings
{
    public class MagicalThingsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        [Tooltip("On : Place the Shoe Slot in the Equipment page (grappling hook)\nOff : Boot Slot on the Main Inventory Page")]
        [Label("Shoe Slot location equipment page")]
        public bool ShoeSlotlocation;

        [DefaultValue(true)]
        [Label("Allow equipping boots in accessory slots")]
        public bool AllowShoesInAccessorySlots;

        public override void OnChanged()
        {
            MagicalThings.ShoeSlotlocation = ShoeSlotlocation;
            MagicalThings.AllowShoesInAccessorySlots = AllowShoesInAccessorySlots;
        }
    }
}