﻿using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons.SwarmSummons.Thorium
{
    [Autoload(false)]
    public class OverloadGranite : ModItem
    {
        private readonly Mod thorium = Fargowiltas.FargosGetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unstable Core 2.0");
            Tooltip.SetDefault("Summons several Granite Energy Storms");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 100;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }

        public override bool UseItem(Player player)
        {
            Fargowiltas.SwarmActive = true;
            Fargowiltas.SwarmTotal = 10 * player.inventory[player.selectedItem].stack;
            Fargowiltas.SwarmKills = 0;

            // Kill whole stack
            player.inventory[player.selectedItem].stack = 0;

            if (Fargowiltas.SwarmTotal <= 20)
            {
                Fargowiltas.SwarmSpawned = Fargowiltas.SwarmTotal;
            }
            else if (Fargowiltas.SwarmTotal <= 100)
            {
                Fargowiltas.SwarmSpawned = 20;
            }
            else if (Fargowiltas.SwarmTotal != 1000)
            {
                Fargowiltas.SwarmSpawned = 30;
            }
            else
            {
                Fargowiltas.SwarmSpawned = 30;
            }

            for (int i = 0; i < Fargowiltas.SwarmSpawned; i++)
            {
                //int boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), thorium.NPCType("GraniteEnergyStorm"));
                //Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().SwarmActive = true;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("It is unclear which rocks aren't enemies!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("It is unclear which rocks aren't enemies!", 175, 75, 255);
            }

            SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(thorium, "UnstableCore");
            recipe.AddIngredient(null, "Overloader");
            recipe.AddTile(TileID.DemonAltar);
            
            recipe.Register();
        }
    }
}