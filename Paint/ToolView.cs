using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class ToolView : PictureBox
    {
        public Tool Tool { get; }

        public ToolView(Tool tool, string title, Bitmap icon)
        {
            Tool = tool;

            Width = 40;
            Height = 40;
            BorderStyle = BorderStyle.FixedSingle;

            Image = icon;
            SizeMode = PictureBoxSizeMode.StretchImage;

            Label label = new Label();
            label.Text = title;
            label.Width = Width;
            label.Height = Height;
            label.TextAlign = ContentAlignment.BottomCenter;
            label.BackColor = Color.Transparent;
            label.Click += this_Click;
            Controls.Add(label);
        }

        private void this_Click(object sender, EventArgs e)
        {
            Form1 form = FindForm() as Form1;
            form.ToolView_Click(sender, e);
        }
    }
}
