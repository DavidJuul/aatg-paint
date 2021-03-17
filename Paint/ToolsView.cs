using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class ToolsView : FlowLayoutPanel
    {
        public ToolsView()
        {
            Dock = DockStyle.Top;
            Height = 50;
        }

        public void AddTool(Tool tool, string title)
        {
            ToolView toolView = new ToolView(tool, title);
            Controls.Add(toolView);
        }
    }
}
