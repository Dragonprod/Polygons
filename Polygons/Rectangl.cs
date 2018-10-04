using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Polygons
{
    class Rectangl : Shape
    {
        public Rectangl(int x, int y) : base(x, y)
        {

        }
        public override void Draw(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(col), (float)(x - radius / Math.Sqrt(2)), (float)(y - radius / Math.Sqrt(2)), (float)(2 * radius / Math.Sqrt(2)), (float)(2 * radius / Math.Sqrt(2)));
            gr.DrawRectangle(new Pen(pen, 3), (float)(x - radius / Math.Sqrt(2)), (float)(y - radius / Math.Sqrt(2)), (float)(2 * radius / Math.Sqrt(2)), (float)(2 * radius / Math.Sqrt(2)));
        }
        public override bool IsInside(int mouse_x, int mouse_y)
        {
            if (mouse_x >= x - radius && mouse_x <= x + 2 * (radius / Math.Sqrt(2)) && mouse_y >= y - radius && mouse_y <= y + 2 * (radius / Math.Sqrt(2)))
                return true;
            else return false;
        }

    }
}
