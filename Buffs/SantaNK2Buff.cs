using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs
{
	public class SantaNK2Buff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Santa-NK2");
            Description.SetDefault("Drive a Santa-NK2!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
        }

		public override void Update(Player player, ref int buffIndex)
		{
            Lighting.AddLight((int)(player.position.X + (double)(player.width / 2)) / 16, (int)(player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
            player.mount.SetMount(MountType<Mounts.SantaNK2>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
