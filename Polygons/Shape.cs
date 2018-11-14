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
using System.Xml.Serialization;
namespace Polygons
{
    [Serializable]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Rectangl))]
    public abstract class Shape
    {
        protected static Color col, pen;
        protected static int radius;
        protected int x, y;
        protected bool flag, remove, ToRemove;
        [XmlElement("X")]
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        [XmlElement("Y")]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        [XmlIgnore]
        public bool FLAG
        {
            get { return flag; }
            set { flag = value; }
        }
        [XmlIgnore]
        public bool REMOVE
        {
            get { return remove; }
            set { remove = value; }
        }
        [XmlIgnore]
        public bool TOREMOVE
        {
            get { return ToRemove; }
            set { ToRemove = value; }
        }
        [XmlElement("RADIUS")]
        public int RADIUS
        {
            get { return radius; }
            set { radius = value; }
        }
        [XmlElement("INSIDECOLOR")]
        public Color COL
        {
            get { return col; }
            set { col = value; }
        }
        [XmlElement("OUTSIDECOLOR")]
        public Color PEN
        {
            get { return pen; }
            set { pen = value; }
        }
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        static Shape()
        {
            col = Color.Red;
            pen = Color.Green;
            radius = 20;
        }
        public abstract void Undo(Shape p);
        public abstract void Redo(Shape p);
        public abstract void Draw(Graphics gr);
        public abstract bool IsInside(int mouse_x, int mouse_y);
    }
}
