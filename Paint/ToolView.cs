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

        public bool Highlighted
        {
            get { return BorderStyle == BorderStyle.Fixed3D; }
            set { BorderStyle = value ? BorderStyle.Fixed3D : BorderStyle.FixedSingle; }
        }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                Highlighted = value;
            }
        }

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
            Width = 40;
            Height = 40;
            Highlighted = false;
            Image = icon;
            SizeMode = PictureBoxSizeMode.StretchImage;

            Label = new Label();
            Label.Text = title;
            Label.Width = Width;
            Label.Height = Height;
            Label.TextAlign = ContentAlignment.BottomCenter;
            Label.Padding = new Padding(0, 0, 0, 3);
            Label.BackColor = Color.Transparent;
            Label.MouseHover += this_MouseHover;
            Label.MouseLeave += this_MouseLeave;
            Label.Click += this_Click;
            Controls.Add(Label);
        }

        private void this_MouseHover(object sender, EventArgs e)
        {
            Highlighted = true;
        }

        private void this_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                Highlighted = false;
            }
        }

        private void this_Click(object sender, EventArgs e)
        {
            Form1 form = FindForm() as Form1;
            form.ToolView_Click(sender, e);
        }
    }
}
