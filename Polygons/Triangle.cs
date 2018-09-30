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
    class Triangle : Shape
    {
        PointF[] p = new PointF[3];
        public Triangle(Color col, Color pen, int x, int y) : base(col, pen, x, y)
        {
            
        }
        public override void Draw(Graphics gr)
        {
            p[0] = new PointF((float)(x - Math.Sqrt(3) / 2 * radius), y + radius / 2);
            p[1] = new PointF(x, y - radius);
            p[2] = new PointF((float)(x + Math.Sqrt(3) / 2 * radius), y + radius / 2);
            gr.FillPolygon(new SolidBrush(col), p);
        }
        double Get_Dist(float X1, float Y1, float X2, float Y2)
        {
            return Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));
        }
        double Geron(float X1, float Y1, float X2, float Y2, float X3, float Y3)
        {
            double p1 = (Get_Dist(X1, Y1, X2, Y2) + Get_Dist(X1, Y1, X3, Y3) + Get_Dist(X2, Y2, X3, Y3)) / 2;
            return Math.Sqrt(p1 * (p1 - Get_Dist(X1, Y1, X2, Y2)) * (p1 - Get_Dist(X1, Y1, X3, Y3)) * (p1 - Get_Dist(X2, Y2, X3, Y3)));
        }
        public override bool IsInside(int mouse_x, int mouse_y)
        {
            if (1 + 3 * Math.Sqrt(3) * radius * radius / 4 >= Geron((float)(x - Math.Sqrt(3) / 2 * radius), (y + radius / 2), x, (y - radius), mouse_x, mouse_y) + Geron((float)(x - Math.Sqrt(3) / 2 * radius), (y + radius / 2), (float)(x + Math.Sqrt(3) / 2 * radius), (y + radius / 2), mouse_x, mouse_y) + Geron(x, (y - radius), (float)(x + Math.Sqrt(3) / 2 * radius), (y + radius / 2), mouse_x, mouse_y))
                return true;
            else return false;
        }
        public override bool ToRemove(int mouse_x, int mouse_y)
        {
            if (1 + 3 * Math.Sqrt(3) * radius * radius / 4 >= Geron((float)(x - Math.Sqrt(3) / 2 * radius), (y + radius / 2), x, (y - radius), mouse_x, mouse_y) + Geron((float)(x - Math.Sqrt(3) / 2 * radius), (y + radius / 2), (float)(x + Math.Sqrt(3) / 2 * radius), (y + radius / 2), mouse_x, mouse_y) + Geron(x, (y - radius), (float)(x + Math.Sqrt(3) / 2 * radius), (y + radius / 2), mouse_x, mouse_y))
                return true;
            else return false;
        }
    }
}
