using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MagicalThings.NPCs;
using Terraria.ID;

namespace MagicalThings.Buffs
{
	public class ArmorBreak : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Armor Break");
			Description.SetDefault("Armor reduced by half");
			Main.debuff[Type] = true; //Is buff or debuff
			Main.pvpBuff[Type] = true; //Is allowed for pvp
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true; //extended duration in expert mode
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MagicalPlayer>().ArmorBreak = true;
            int num1 = Dust.NewDust(player.position, player.width, player.height, DustID.GoldFlame);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 0.9f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 3f; //the dust velocity
            Main.dust[num1].noGravity = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MagicalGlobalNPC>().ArmorBreak = true;
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldFlame);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 0.9f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 3f; //the dust velocity
            Main.dust[num1].noGravity = true;
            //npc.velocity *= 0.25f; //very slow
        }      
    }
}
