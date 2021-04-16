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
        public CommonDialog OptionDialog { get; }
        
        public Label Label { get; private set; }

        public ToolView(Tool tool, string title, Bitmap icon)
        {
            Tool = tool;

            CreateView(title, icon);
        }

        public ToolView(CommonDialog optionDialog, string title, Bitmap icon)
        {
            OptionDialog = optionDialog;

            CreateView(title, icon);
        }

        private void CreateView(string title, Bitmap icon)
        {
            Width = 60;
            Height = 40;
            BorderStyle = BorderStyle.FixedSingle;

            Image = icon;
            SizeMode = PictureBoxSizeMode.StretchImage;

            Label = new Label();
            Label.Text = title;
            Label.Width = Width;
            Label.Height = Height;
            Label.TextAlign = ContentAlignment.BottomCenter;
            Label.BackColor = Color.Transparent;
            Label.Click += this_Click;
            Controls.Add(Label);
        }

        private void this_Click(object sender, EventArgs e)
        {
            Form1 form = FindForm() as Form1;
            form.ToolView_Click(sender, e);
        }
    }
}
