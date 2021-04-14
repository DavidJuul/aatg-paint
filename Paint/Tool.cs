using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    abstract class Tool
    {
        public virtual float Size { get; set; }
        public virtual Color Color { get; set; }

        public abstract void OnMouseDown(object sender, MouseEventArgs e);
        public abstract void OnMouseUp(object sender, MouseEventArgs e);
        public abstract void OnMouseMove(object sender, MouseEventArgs e);
    }
}
