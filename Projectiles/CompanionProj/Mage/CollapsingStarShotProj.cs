using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class CollapsingStarShotProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.CloneDefaults(ProjectileID.NebulaBlaze2); //440
            aiType = ProjectileID.NebulaBlaze2;
            projectile.aiStyle = 1;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1; //must be at least 1
            projectile.tileCollide = true;
            projectile.timeLeft = 800;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Collapsing Star");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void Kill(int timeLeft) //act like a flask explosion
        {
            #region Vanilla nebula blaze eplode
            int num47 = Utils.SelectRandom<int>(Main.rand, new int[]
                {
                    242,
                    73,
                    72,
                    71,
                    255
                });
            int num48 = 255;
            int num49 = 255;
            int height = 50;
            float num50 = 1.7f;
            float num51 = 0.8f;
            float num52 = 2f;
            Vector2 value3 = (projectile.rotation - 1.57079637f).ToRotationVector2();
            Vector2 value4 = value3 * projectile.velocity.Length() * (float)projectile.MaxUpdates;
            if (projectile.owner == Main.myPlayer)
            {
                num48 = 88;
                num49 = 88;
                num47 = Utils.SelectRandom<int>(Main.rand, new int[]
                {
                    242,
                    59,
                    88
                });
                num50 = 3.7f;
                num51 = 1.5f;
                num52 = 2.2f;
                value4 *= 0.5f;
            }
            Main.PlaySound(SoundID.Item14, projectile.position);
            projectile.position = projectile.Center;
            projectile.width = (projectile.height = height);
            projectile.Center = projectile.position;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.Damage();
            int num3;
            for (int num53 = 0; num53 < 40; num53 = num3 + 1)
            {
                num47 = Utils.SelectRandom<int>(Main.rand, new int[]
                {
                        242,
                        73,
                        72,
                        71,
                        255
                });
                if (projectile.owner == Main.myPlayer)
                {
                    num47 = Utils.SelectRandom<int>(Main.rand, new int[]
                    {
                            242,
                            59,
                            88
                    });
                }
                int num54 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num47, 0f, 0f, 200, default(Color), num50);
                Main.dust[num54].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * (float)projectile.width / 2f;
                Main.dust[num54].noGravity = true;
                Dust dust = Main.dust[num54];
                dust.velocity *= 3f;
                dust = Main.dust[num54];
                dust.velocity += value4 * Main.rand.NextFloat();
                num54 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num48, 0f, 0f, 100, default(Color), num51);
                Main.dust[num54].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * (float)projectile.width / 2f;
                dust = Main.dust[num54];
                dust.velocity *= 2f;
                Main.dust[num54].noGravity = true;
                Main.dust[num54].fadeIn = 1f;
                Main.dust[num54].color = Color.Crimson * 0.5f;
                dust = Main.dust[num54];
                dust.velocity += value4 * Main.rand.NextFloat();
                num3 = num53;
            }
            for (int num55 = 0; num55 < 20; num55 = num3 + 1)
            {
                int num56 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num49, 0f, 0f, 0, default(Color), num52);
                Main.dust[num56].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2)) * (float)projectile.width / 3f;
                Main.dust[num56].noGravity = true;
                Dust dust = Main.dust[num56];
                dust.velocity *= 0.5f;
                dust = Main.dust[num56];
                dust.velocity += value4 * (0.6f + 0.6f * Main.rand.NextFloat());
                num3 = num55;
            }
            #endregion
        }

        //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //{
        //    target.AddBuff(BuffID.Venom, 210);
        //    target.AddBuff(BuffID.CursedInferno, 210);
        //    target.immune[projectile.owner] = 7;
        //}

    }
}
