using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items
{
    class FrozenHookItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Hook");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.StaticHook);
            item.shootSpeed = 30f; // how quickly the hook is shot.
            /*
				item.noUseGraphic = true;
				item.damage = 0;
				item.knockBack = 7f;
				item.useStyle = 5;
				item.name = "Diamond Hook";
				item.shootSpeed = 10f;
				item.shoot = 230;
				item.width = 18;
				item.height = 28;
				item.useSound = 1;
				item.useAnimation = 20;
				item.useTime = 20;
				item.rare = 1;
				item.noMelee = true;
				item.value = 20000;
			*/
            // Instead of copying these values, we can clone and modify the ones we want to copy

            //item.shoot = mod.ProjectileType("FrozenHookProjectile");
        }
        //     public override void AddRecipes()
        //     {
        //         ModRecipe recipe = new ModRecipe(mod);
        //         recipe.AddIngredient(ItemID.DirtBlock, 5);
        //         recipe.AddTile(TileID.WorkBenches);
        //         recipe.SetResult(this);
        //         recipe.AddRecipe();
        //     }
        class FrozenHookProjectile : ModProjectile
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("${ProjectileName.StaticHook}");
            }
            public override void SetDefaults()
            {
                //projectile.netImportant = true;
                //projectile.Name = "Frozen Hook";
                //projectile.width = 18;
                //projectile.height = 18;
                //projectile.aiStyle = 7;
                //projectile.friendly = true;
                //projectile.penetrate = -1;
                //projectile.tileCollide = false;
                //projectile.timeLeft *= 10;                
                projectile.CloneDefaults(ProjectileID.StaticHook);
            }

            // Use this hook for hooks that can have multiple hooks midflight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook
            //         public override bool? CanUseGrapple(Player player)
            //         {
            //             int hooksOut = 0;
            //             for (int l = 0; l < 1000; l++)
            //             {
            //                 if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
            //                 {
            //                     hooksOut++;
            //                }
            //             }
            //             if (hooksOut > 1) // This hook can have 2 hooks out.
            //             {
            //                 return false;
            //             }
            //             return true;
            //         }

            // Return true if it is like: Hook, CandyCaneHook, BatHook, GemHooks
            // public override bool? SingleGrappleHook(Player player)
            //  {
            //  	return true;
            //  }

            // Use this to kill oldest hook. For hooks that kill the oldest when shot, not when the newest latches on: Like SkeletronHand
            // You can also change the projectile like: Dual Hook, Lunar Hook
            //  public override void UseGrapple(Player player, ref int type)
            //  {
            //	int hooksOut = 0;
            //int oldestHookIndex = -1;
            //int oldestHookTimeLeft = 100000;
            //for (int i = 0; i < 1000; i++)
            //{
            //		if (Main.projectile[i].active && Main.projectile[i].owner == projectile.whoAmI && Main.projectile[i].type == projectile.type)
            // 		{
            //			hooksOut++;
            //			if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
            //			{
            //				oldestHookIndex = i;
            // 				oldestHookTimeLeft = Main.projectile[i].timeLeft;
            // 			}
            //		}
            //	}
            //  	if (hooksOut > 1)
            //   	{
            //   		Main.projectile[oldestHookIndex].Kill();
            //   	}
            //   }

            // Amethyst Hook is 300, Static Hook is 600
            public override float GrappleRange()
            {
                return 2200f;
            }

            //public override void NumGrappleHooks(Player player, ref int numHooks)
            //{
            //    numHooks = 2;
            //}

            // default is 11, Lunar is 24
            public override void GrappleRetreatSpeed(Player player, ref float speed)
            {
                speed = 34f;
            }

            //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
            //{
            //    //Normal Hook
            //    Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            //    Vector2 vector14 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            //    float num84 = mountedCenter.X - vector14.X;
            //    float num85 = mountedCenter.Y - vector14.Y;
            //    float rotation13 = (float)Math.Atan2((double)num85, (double)num84) - 1.57f;
            //    bool flag11 = true;
            //    while (flag11)
            //    {
            //        float num86 = (float)Math.Sqrt((double)(num84 * num84 + num85 * num85));
            //        if (num86 < 30f)
            //        {
            //            flag11 = false;
            //        }
            //        else if (float.IsNaN(num86))
            //        {
            //            flag11 = false;
            //        }
            //        else
            //        {
            //            num86 = 24f / num86;
            //            num84 *= num86;
            //            num85 *= num86;
            //            vector14.X += num84;
            //            vector14.Y += num85;
            //            num84 = mountedCenter.X - vector14.X;
            //            num85 = mountedCenter.Y - vector14.Y;
            //            Color color15 = Lighting.GetColor((int)vector14.X / 16, (int)(vector14.Y / 16f));
            //            Main.spriteBatch.Draw(mod.GetTexture("Items/FrozenHookChain"), new Vector2(vector14.X - Main.screenPosition.X, vector14.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain30Texture.Width, Main.chain30Texture.Height)), color15, rotation13, new Vector2((float)Main.chain30Texture.Width * 0.5f, (float)Main.chain30Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
            //        }
            //    }
            //    return true;
            //}
            //public override void PostAI() //nope still not correct override
            //public override void GrapplePullSpeed(Player player, ref float speed) //needs correct override
            //{
            //    if (Main.myPlayer == projectile.owner)
            //    {
            //        Main.player[projectile.owner].direction = projectile.direction;
            //        Vector2 vector3 = new Vector2(player.controlRight.ToInt() - player.controlLeft.ToInt(), (player.controlDown.ToInt() - player.controlUp.ToInt()) * player.gravDir);
            //        if (vector3 != Vector2.Zero)
            //        {
            //            vector3.Normalize();
            //        }
            //        Vector2 vector4 = player.Center - player.Center;
            //        Vector2 vector5 = vector4;
            //        if (vector5 != Vector2.Zero)
            //        {
            //            vector5.Normalize();
            //        }
            //        Vector2 vector6 = Vector2.Zero;
            //        if (vector3 != Vector2.Zero)
            //        {
            //            vector6 = vector5 * Vector2.Dot(vector5, vector3);
            //        }
            //        float num5 = 6f;
            //        if (Vector2.Dot(vector6, vector4) < 0f && vector4.Length() >= 600f)
            //        {
            //            num5 = 0f;
            //        }
            //        //num2 += -vector4.X + vector6.X * num5;
            //        //num3 += -vector4.Y + vector6.Y * num5;
            //    }
            //}
            //public override void GrapplePullSpeed(Player player, ref float speed) //More Static hook source wrong override
            //{
            //    if (Main.player[projectile.owner].dead || Main.player[projectile.owner].stoned || Main.player[projectile.owner].webbed || Main.player[projectile.owner].frozen)
            //    {
            //        projectile.Kill();
            //        return;
            //    }
            //    Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            //    Vector2 vector6 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
            //    float num70 = mountedCenter.X - vector6.X;
            //    float num71 = mountedCenter.Y - vector6.Y;
            //    float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
            //    projectile.rotation = (float)Math.Atan2(num71, num70) - 1.57f;
            //    if (Main.myPlayer == projectile.owner)
            //    {
            //        int num3 = projectile.frameCounter + 1;
            //        projectile.frameCounter = num3;
            //        if (num3 >= 7)
            //        {
            //            projectile.frameCounter = 0;
            //            num3 = projectile.frame + 1;
            //            projectile.frame = num3;
            //            if (num3 >= Main.projFrames[projectile.type])
            //            {
            //                projectile.frame = 0;
            //            }
            //        }
            //    }
            //}

            // Animated hook example
            // Multiple, 
            // only 1 connected, spawn mult
            // Light the path
            // Gem Hooks: 1 spawn only
            // Thorn: 4 spawns, 3 connected
            // Dual: 2/1 
            // Lunar: 5/4 -- Cycle hooks, more than 1 at once
            // AntiGravity -- Push player to position
            // Static -- move player with keys, don't pull to wall
            // Christmas -- light ends
            // Web slinger -- 9/8, can shoot more than 1 at once
            // Bat hook -- Fast reeling
        }
    }
}
