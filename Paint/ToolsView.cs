﻿using System;
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
            AddTool(new BucketTool(), "Bucket", Properties.Resources.Tool);

            AddOption(new SizeDialog(), "Size", Properties.Resources.Tool);
            AddOption(new ColorDialog(), "Color", Properties.Resources.Tool);
        }

        public void UpdateOptions(Tool tool)
        {
            foreach (Control control in Controls)
            {
                ToolView toolView = control as ToolView;
                if (toolView != null && toolView.OptionDialog != null)
                {
                    SizeDialog sizeDialog = toolView.OptionDialog as SizeDialog;
                    ColorDialog colorDialog = toolView.OptionDialog as ColorDialog;

                    if (sizeDialog != null)
                    {
                        sizeDialog.Size = tool.Size;
                        toolView.Label.Text = "Size: " + sizeDialog.Size;
                    }
                    else if (colorDialog != null)
                    {
                        colorDialog.Color = tool.Color;
                        toolView.BackColor = colorDialog.Color;
                    }
                }
            }
        }

        private void AddTool(Tool tool, string title, Bitmap icon)
        {
            ToolView toolView = new ToolView(tool, title, icon);
            Controls.Add(toolView);
        }

        private void AddOption(CommonDialog optionDialog, string title, Bitmap icon)
        {
            ToolView toolView = new ToolView(optionDialog, title, icon);
            Controls.Add(toolView);
        }
    }
}
