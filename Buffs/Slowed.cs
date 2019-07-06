using Terraria;
using Terraria.ModLoader;
using MagicalThings.NPCs;
using Terraria.ID;

namespace MagicalThings.Buffs
{
	public class Slowed : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Slowed");
			Description.SetDefault("Movement speed is reduced");
			Main.debuff[Type] = true; //Is buff or debuff
			Main.pvpBuff[Type] = true; //Is allowed for pvp
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true; //extended duration in expert mode
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MagicalPlayer>(mod).ArmorBreak = true;
            int num1 = Dust.NewDust(player.position, player.width, player.height, 212);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 0.9f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 1.0f; //the dust velocity
            Main.dust[num1].noGravity = true;
			player.velocity *= 0.80f; //slow
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MagicalGlobalNPC>(mod).ArmorBreak = true;
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 212);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 0.9f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 1.0f; //the dust velocity
            Main.dust[num1].noGravity = true;
            npc.velocity *= 0.80f; //slow
        }      
    }
}
