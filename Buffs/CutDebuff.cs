using Terraria;
using Terraria.ModLoader;
using MagicalThings.NPCs;
using Terraria.ID;

namespace MagicalThings.Buffs
{
	public class CutDebuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bleeding");
			Description.SetDefault("Bleeding and losing life");
			Main.debuff[Type] = true; //Is buff or debuff
			Main.pvpBuff[Type] = true; //Is allowed for pvp
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true; //extended duration in expert mode
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MagicalPlayer>(mod).Cut = true;
            int num1 = Dust.NewDust(player.position, player.width, player.height, 90);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 0.8f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 0.5f; //the dust velocity
            Main.dust[num1].noGravity = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MagicalGlobalNPC>(mod).Cut = true;
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 90);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 0.8f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 0.5f; //the dust velocity
            Main.dust[num1].noGravity = false;
        }      
    }
}
