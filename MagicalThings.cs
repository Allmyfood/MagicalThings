using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using MagicalThings.Tiles;

namespace MagicalThings
{
	public class MagicalThings : Mod
	{
        public const string SHOE_SLOT_BACK_TEX = "ShoeSlotBackground";
        internal static MagicalThings instance;

        public MagicalThings()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
            TerraUI.Utilities.UIUtils.Mod = this;
            TerraUI.Utilities.UIUtils.Subdirectory = "TerraUI";
        }
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            MagicalPlayer mpp = Main.player[Main.myPlayer].GetModPlayer<MagicalPlayer>(this);
            mpp.Draw(spriteBatch);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
            recipe.AddIngredient(null, "MercuryBoots", 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.SpectreBoots, 1);
            recipe.AddRecipe();
        
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PalladiumBar, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(null, "Twinkle", 1);
            recipe.AddRecipe();
       
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PalladiumBar, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddIngredient(ItemID.IceBlock, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(null, "IcingDeath", 1);
            recipe.AddRecipe();
        }

        public override void Unload()
        {
            instance = null;
        }
        public override void Load()
        {
            instance = this;
            if (!Main.dedServ)
            {
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Enkryption"), ItemType("EnkryptionMusicBox"), TileType("EnkryptionMusicBox"));
            }
        }
        public override void UpdateMusic(ref int music)
        {
            
        }
    }
}
