using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class ToolView : FlowLayoutPanel
    {
        public Tool Tool { get; }

        public ToolView(Tool tool, string title)
        {
            Tool = tool;

            Width = 40;
            Height = 40;

            Label label = new Label();
            label.Text = title;
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
