using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class HellBurstFireballProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(207);
            Main.projFrames[projectile.type] = 4;
            projectile.damage = 60;
            projectile.width = 36;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.magic = true;
            //aiType = 207;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.timeLeft = 1800;
            //projectile.alpha = 255;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Burst Fireball");
            ProjectileID.Sets.Homing[projectile.type] = true;

        }
        public override void AI()
        {
            //int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //Main.dust[dust].noGravity = true;

            if (projectile.frameCounter < 5)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
                projectile.frame = 3;
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;
            if (projectile.alpha > 30)
            {
                projectile.alpha -= 15;
                if (projectile.alpha < 30)
                {
                    projectile.alpha = 250;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 74);
                Vector2 vel = new Vector2(-1, 0);
                vel *= 10f;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, ProjectileType<ExplosionFake>(), projectile.damage, 0, Main.myPlayer); //Initial projectile death
                Vector2 vel1 = new Vector2(-1, -1);
                vel1 *= 10f;
                Projectile.NewProjectile(projectile.Center.X + 50, projectile.Center.Y + 50, vel1.X, vel1.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#6 bottom right
                Vector2 vel2 = new Vector2(1, 1);
                vel2 *= 10f;
                Projectile.NewProjectile(projectile.Center.X - 50, projectile.Center.Y - 50, vel2.X, vel2.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#1 top left
                Vector2 vel3 = new Vector2(1, -1);
                vel3 *= 10f;
                Projectile.NewProjectile(projectile.Center.X - 50, projectile.Center.Y + 50, vel3.X, vel3.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#4 bottom left
                Vector2 vel4 = new Vector2(-1, 1);
                vel4 *= 10f;
                Projectile.NewProjectile(projectile.Center.X + 50, projectile.Center.Y - 50, vel4.X, vel4.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#3 top right
                Vector2 vel5 = new Vector2(0, -1);
                vel5 *= 10f;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 75, vel5.X, vel5.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#5 center bottom
                Vector2 vel6 = new Vector2(0, 1);
                vel6 *= 10f;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 75, vel6.X, vel6.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#2 center top
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 74);
                Vector2 vel = new Vector2(0, -1);
                vel *= 0f;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, ProjectileType<ExplosionFake>(), projectile.damage, 0, Main.myPlayer);
            }
            Vector2 vel1 = new Vector2(-1, -1);
            vel1 *= 10f;
            Projectile.NewProjectile(target.position.X + 50, target.position.Y + 50, vel1.X, vel1.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#6 bottom right
            Vector2 vel2 = new Vector2(1, 1);
            vel2 *= 10f;
            Projectile.NewProjectile(target.position.X - 50, target.position.Y - 50, vel2.X, vel2.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#1 top left
            Vector2 vel3 = new Vector2(1, -1);
            vel3 *= 10f;
            Projectile.NewProjectile(target.position.X - 50, target.position.Y + 50, vel3.X, vel3.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#4 bottom left
            Vector2 vel4 = new Vector2(-1, 1);
            vel4 *= 10f;
            Projectile.NewProjectile(target.position.X + 50, target.position.Y - 50, vel4.X, vel4.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#3 top right
            Vector2 vel5 = new Vector2(0, -1);
            vel5 *= 10f;
            Projectile.NewProjectile(target.position.X, target.position.Y + 75, vel5.X, vel5.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#5 center bottom
            Vector2 vel6 = new Vector2(0, 1);
            vel6 *= 10f;
            Projectile.NewProjectile(target.position.X, target.position.Y - 75, vel6.X, vel6.Y, ProjectileType<HellBurstBoltProj>(), projectile.damage, 0, Main.myPlayer); //#2 center top
        }

    }
}
