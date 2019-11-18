﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
    class SpiritHookItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Hook");
        }
        public override void SetDefaults()
        {
            /*
				this.noUseGraphic = true;
				this.damage = 0;
				this.knockBack = 7f;
				this.useStyle = 5;
				this.name = "Diamond Hook";
				this.shootSpeed = 10f;
				this.shoot = 230;
				this.width = 18;
				this.height = 28;
				this.useSound = 1;
				this.useAnimation = 20;
				this.useTime = 20;
				this.rare = 1;
				this.noMelee = true;
				this.value = 20000;
			*/
            // Instead of copying these values, we can clone and modify the ones we want to copy
            item.CloneDefaults(ItemID.DiamondHook);
            item.shootSpeed = 30f; // how quickly the hook is shot.
            item.shoot = ProjectileType<SpiritHookProjectile>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Hook, 1);
            recipe.AddIngredient(ItemID.Chain, 10);
            recipe.AddIngredient(ItemID.Ectoplasm, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        class SpiritHookProjectile : ModProjectile
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("${ProjectileName.GemHookDiamond}");
            }
            public override void SetDefaults()
            {
                /*	this.netImportant = true;
                    this.name = "Gem Hook";
                    this.width = 18;
                    this.height = 18;
                    this.aiStyle = 7;
                    this.friendly = true;
                    this.penetrate = -1;
                    this.tileCollide = false;
                    this.timeLeft *= 10;
                */
                projectile.CloneDefaults(ProjectileID.GemHookDiamond);
            }

            // Use this hook for hooks that can have multiple hooks midflight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook
            public override bool? CanUseGrapple(Player player)
            {
                int hooksOut = 0;
                for (int l = 0; l < 1000; l++)
                {
                    if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
                    {
                        hooksOut++;
                    }
                }
                if (hooksOut > 2) // This hook can have 3 hooks out.
                {
                    return false;
                }
                return true;
            }

            // Return true if it is like: Hook, CandyCaneHook, BatHook, GemHooks
            //public override bool? SingleGrappleHook(Player player)
            //{
            //	return true;
            //}

            // Use this to kill oldest hook. For hooks that kill the oldest when shot, not when the newest latches on: Like SkeletronHand
            // You can also change the projectile likr: Dual Hook, Lunar Hook
            //public override void UseGrapple(Player player, ref int type)
            //{
            //	int hooksOut = 0;
            //	int oldestHookIndex = -1;
            //	int oldestHookTimeLeft = 100000;
            //	for (int i = 0; i < 1000; i++)
            //	{
            //		if (Main.projectile[i].active && Main.projectile[i].owner == projectile.whoAmI && Main.projectile[i].type == projectile.type)
            //		{
            //			hooksOut++;
            //			if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
            //			{
            //				oldestHookIndex = i;
            //				oldestHookTimeLeft = Main.projectile[i].timeLeft;
            //			}
            //		}
            //	}
            //	if (hooksOut > 1)
            //	{
            //		Main.projectile[oldestHookIndex].Kill();
            //	}
            //}

            // Amethyst Hook is 300, Static Hook is 600
            public override float GrappleRange()
            {
                return 12000f;
            }

            public override void NumGrappleHooks(Player player, ref int numHooks)
            {
                numHooks = 2;
            }

            // default is 11, Lunar is 24
            public override void GrappleRetreatSpeed(Player player, ref float speed)
            {
                speed = 34f;
            }

            public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
            {
                Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
                Vector2 vector14 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num84 = mountedCenter.X - vector14.X;
                float num85 = mountedCenter.Y - vector14.Y;
                float rotation13 = (float)Math.Atan2((double)num85, (double)num84) - 1.57f;
                bool flag11 = true;
                while (flag11)
                {
                    float num86 = (float)Math.Sqrt((double)(num84 * num84 + num85 * num85));
                    if (num86 < 30f)
                    {
                        flag11 = false;
                    }
                    else if (float.IsNaN(num86))
                    {
                        flag11 = false;
                    }
                    else
                    {
                        num86 = 24f / num86;
                        num84 *= num86;
                        num85 *= num86;
                        vector14.X += num84;
                        vector14.Y += num85;
                        num84 = mountedCenter.X - vector14.X;
                        num85 = mountedCenter.Y - vector14.Y;
                        Color color15 = Lighting.GetColor((int)vector14.X / 16, (int)(vector14.Y / 16f));
                        Main.spriteBatch.Draw(mod.GetTexture("Items/SpiritHookChain"), new Vector2(vector14.X - Main.screenPosition.X, vector14.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain30Texture.Width, Main.chain30Texture.Height)), color15, rotation13, new Vector2((float)Main.chain30Texture.Width * 0.5f, (float)Main.chain30Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                    }
                }
                return true;
            }
        }

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
