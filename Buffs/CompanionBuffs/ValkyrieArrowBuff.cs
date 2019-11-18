using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MagicalThings.NPCs;
using Terraria.ID;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class ValkyrieArrowBuff : ModBuff
	{
        public override bool Autoload(ref string name, ref string texture)
        {
            // NPC only buff so we'll just assign it a useless buff icon.
            texture = "MagicalThings/Buffs/CutDebuff";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
		{
			DisplayName.SetDefault("Valkyrie Arrow");
			Description.SetDefault("Losing life");
            //Main.debuff[Type] = true; //Is buff or debuff
            //Main.pvpBuff[Type] = true; //Is allowed for pvp
            //Main.buffNoSave[Type] = true;
            //longerExpertDebuff = true; //extended duration in expert mode
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MagicalGlobalNPC>().ValkyrieArrow = true;
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 218);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 0.6f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 0.2f; //the dust velocity
            Main.dust[num1].noGravity = false;
        }      
    }
}
