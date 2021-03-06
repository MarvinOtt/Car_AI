using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Car_AI.UI.UI_Configs;
using static Car_AI.UI.UI_STRUCTS;

namespace Car_AI.UI
{
    public class UI_Button : UI_Element
    {
        public Generic_Conf conf;
        public bool IsHovered, IsActivated, IsToggle, DrawBorder;

        public delegate void Button_Activated_Handler(object sender);
        public event Button_Activated_Handler GotActivatedLeft = delegate { };
        public event Button_Activated_Handler GotActivatedRight = delegate { };

        public UI_Button(Pos pos, Point size, bool DrawBorder, Generic_Conf conf) : base(pos, size)
        {
            this.DrawBorder = DrawBorder;
            this.conf = conf;
        }

        protected override void UpdateSpecific()
        {
            Rectangle hitbox = new Rectangle(absolutpos, size);
            IsToggle = false;
            if (conf.behav == 2)
                IsActivated = false;
            if (hitbox.Contains(Game1.mo_states.New.Position))
            {
                IsHovered = true;
                if (Game1.mo_states.IsLeftButtonToggleOff())
                {
                    IsActivated ^= true;
                    IsToggle = true;
                    if (IsActivated)
                        GotActivatedLeft(this);
                }

                if (Game1.mo_states.IsRightButtonToggleOff())
                {
                    GotActivatedRight(this);
                }
            }
            else
                IsHovered = false;
        }

        protected override void UpdateAlways()
        {
            Rectangle hitbox = new Rectangle(absolutpos, size);
            if (!hitbox.Contains(Game1.mo_states.New.Position) || UI_Handler.UI_Element_Pressed)
                IsHovered = false;
        }

        protected override void DrawSpecific(SpriteBatch spritebatch)
        {
            spritebatch.DrawFilledRectangle(new Rectangle(absolutpos, size), conf.BGColor);
            if (DrawBorder)
                spritebatch.DrawHollowRectangle(new Rectangle(absolutpos, size), conf.BorderColor, 1);
        }
    }
}
