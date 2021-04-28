﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Fargowiltas.UI
{
    public class StatButton : UIState
    {
        public UIImage Icon;
        public UIHoverTextImageButton IconHighlight;

        public override void OnActivate()
        {
            Icon = new UIImage(Fargowiltas.UserInterfaceManager.StatsButtonTexture);
            Icon.Left.Set(26, 0f);
            Icon.Top.Set(262, 0f);
            Append(Icon);

            IconHighlight = new UIHoverTextImageButton(Fargowiltas.UserInterfaceManager.StatsButton_MouseOverTexture, "Stat Sheet");
            IconHighlight.Left.Set(-2, 0f);
            IconHighlight.Top.Set(-2, 0f);
            IconHighlight.SetVisibility(1f, 0f);
            IconHighlight.OnClick += IconHighlight_OnClick;
            Icon.Append(IconHighlight);

            base.OnActivate();
        }

        private void IconHighlight_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            Fargowiltas.UserInterfaceManager.ToggleStatSheet();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Main.playerInventory)
                base.Draw(spriteBatch);
        }
    }
}
