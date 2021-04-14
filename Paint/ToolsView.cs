using System;
using System.Collections.Generic;
using System.Drawing;
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
            BorderStyle = BorderStyle.FixedSingle;

            AddTools();
        }

        private void AddTools()
        {
            AddTool(new BrushTool(), "Brush", Properties.Resources.Tool);
            AddTool(new EraseTool(), "Erase", Properties.Resources.Tool);
        }

        private void AddTool(Tool tool, string title, Bitmap icon)
        {
            ToolView toolView = new ToolView(tool, title, icon);
            Controls.Add(toolView);
        }
    }
}
