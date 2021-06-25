using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace MagicalThings
{
    [Label("Client Config")]
    public class MagicalThingsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        //public static Config Instance => ModContent.GetInstance<Config>();

        [DefaultValue(true)]
        [Tooltip("On : Place the BootSlot in the Equipment page (grappling hook)\nOff : Bootslot on the Main Inventory Page")]
        [Label("Bootslot location equipment page")]
        public bool ShoeSlotlocation;

        [DefaultValue(true)]
        [Tooltip("On : Allows normal boots in Equipment slots\nOff : Boots may only be equipped in Bootslot")]
        [Label("Allow equipping boots in accessory slots")]
        public bool AllowShoesInAccessorySlots;

        [Header("Hint: To go to the server config, containing Bootslot Enable / Disable, press the '>' arrow in the bottom right")]
        [Label("Hint")]
        [JsonIgnore]
        public bool Hint => true;

        public override void OnChanged()
        {
            MagicalThings.ShoeSlotlocation = ShoeSlotlocation;
            MagicalThings.AllowShoesInAccessorySlots = AllowShoesInAccessorySlots;
        }
    }
}