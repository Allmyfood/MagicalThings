using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.Pets
{
	public class MedicProj : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Nurse");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }
        public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
			aiType = ProjectileID.Bunny;
            projectile.width = 28;
            projectile.height = 45;
			
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

        //int Nurse = NPC.FindFirstNPC(NPCID.Nurse);

		public override void AI()
		{
            drawOffsetX = -2;
            Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.dead)
			{
				modPlayer.Medic = false;
			}
			if (modPlayer.Medic)
			{
				projectile.timeLeft = 2;
			}

            if (Main.rand.Next(450) == 0)
            {
                Item.NewItem(projectile.getRect(), ItemID.Heart, Main.rand.Next(1, 8)); // 1-8 hearts
            }
        }
	}
}