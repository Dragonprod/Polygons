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
        public Rectangl(Color col, Color pen, int x, int y) :base(col, pen, x, y)
        {
            
        }
        public override void Draw(Graphics gr)
        {
            Rectangle r = new Rectangle((int)(x - radius / Math.Sqrt(2)), (int)(y - radius / Math.Sqrt(2)), (int)(2 * radius / Math.Sqrt(2)), (int)(2 * radius / Math.Sqrt(2)));
            gr.FillRectangle(new SolidBrush(col), r);
            gr.DrawRectangle(new Pen(pen,3), r);
        }
        public override bool IsInside(int mouse_x, int mouse_y)
        {
            if (mouse_x >= x && mouse_x <= x + 2 * (radius / Math.Sqrt(2)) && mouse_y >= y && mouse_y <= y + 2 * (radius / Math.Sqrt(2)))
                return true;
            else return false;
        }
        public override bool ToRemove(int mouse_x, int mouse_y)
        {
            if (mouse_x >= x && mouse_x <= x + 2 * (radius / Math.Sqrt(2)) && mouse_y >= y && mouse_y <= y + 2 * (radius / Math.Sqrt(2)))
                return true;
            else return false;
        }
    }
}
