using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs
{
	public class MonkfishMount : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("S.S. Monkfish");
            Description.SetDefault("A Submarine!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType<Mounts.SSMonkfish>(), player);
			player.buffTime[buffIndex] = 10;
            Lighting.AddLight((int)(player.position.X + (double)(player.width / 2)) / 16, (int)(player.position.Y + (double)(player.height / 2)) / 16, 50.8f, 50.95f, 51f); //default 0.8f, 0.95f, 1f
            player.gills = true;
        }
    }
}
