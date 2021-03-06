using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Car_AI.UI.UI_STRUCTS;

namespace Car_AI.UI.Specific
{
    public class UI_QuickHBElement : UI_MultiElement<UI_Element>
    {
        static Color BackgroundColor = new Color(new Vector3(0.15f));
        static Color BorderColor = new Color(new Vector3(0.45f));

        public UI_QuickHBElement(Pos pos) : base(pos)
        {

        }

        public void Add_UI_Element(UI_Element element)
        {
            int currentSizeX = ui_elements.Sum(x => x.size.X);
            element.pos = new Pos(currentSizeX, 0);

            base.Add_UI_Elements(element);
        }

        protected override void DrawSpecific(SpriteBatch spritebatch)
        {
            spritebatch.DrawFilledRectangle(new Rectangle(absolutpos, size), BackgroundColor);

            base.DrawSpecific(spritebatch);
        }
    }
}
