﻿using System.Text.RegularExpressions;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.CaughtNPCs
{
    public abstract class BaseCaughtNPC : ModItem
    {
        public virtual int Type => NPCID.None;

        public override string Texture => $"Terraria/NPC_{Type}";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault($"The {Regex.Replace(Name, "([A-Z])", " $1").Trim()}");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 10;
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.Swing;
            item.useAnimation = 15;
            item.useTime = 10;
            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item44;
            if (Type != NPCID.None)
            {
                item.makeNPC = (short)Type;
                Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, Main.npcFrameCount[Type]));
            }
        }
    }
}