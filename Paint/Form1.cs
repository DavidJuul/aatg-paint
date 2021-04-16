﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private Canvas _canvas;
        private Bitmap _previousBitmap;
        private Tool _tool;
        private ToolsView _toolsView;

        public Form1()
        {
            InitializeComponent();

            // Create and add a new Canvas.
            _canvas = new Canvas();
            Controls.Add(_canvas.View);

            // TODO: Get BrushTool from ToolsView instead of creating a new one.
            // Add a SelectTool to ToolsView and also use that to choose a default one?
            _tool = new BrushTool();

            _toolsView = new ToolsView();
            _toolsView.UpdateOptions(_tool);
            Controls.Add(_toolsView);

            AddMenu();

            KeyDown += this_KeyDown;
        }

        private void AddMenu()
        {
            MenuStrip mainMenu = new MenuStrip();

            mainMenu.BackColor = Color.LightGray;
            mainMenu.ForeColor = Color.Black;

            mainMenu.Font = new Font("Roboto", 16);
            mainMenu.Text = "Menu";

            MainMenuStrip = mainMenu;
            Controls.Add(mainMenu);

            // Add ToolStripMenuItem to the MainMenu with sub items
            ToolStripMenuItem fileMenu = new ToolStripMenuItem();
            fileMenu.Text = "Filer";
            AddFileMenuItems(fileMenu);

            mainMenu.Items.Add(fileMenu);
        }

        private void AddFileMenuItems(ToolStripMenuItem fileMenu)
        {
            // Create needed menu items
            ToolStripMenuItem itemNew = new ToolStripMenuItem();
            itemNew.Text = "Ny";
            itemNew.ShortcutKeys = Keys.Control | Keys.N;
            itemNew.Click += Menu_New_click;

            ToolStripMenuItem itemOpen = new ToolStripMenuItem();
            itemOpen.Text = "Åbn";
            itemOpen.ShortcutKeys = Keys.Control | Keys.O;
            itemOpen.Click += Menu_Open_click;

            ToolStripMenuItem itemSaveAs = new ToolStripMenuItem();
            itemSaveAs.Text = "Gem som";
            itemSaveAs.ShortcutKeys = Keys.Control | Keys.S;
            itemSaveAs.Click += Menu_SaveAs_click;

            ToolStripSeparator separator1 = new ToolStripSeparator();

            ToolStripMenuItem itemClose = new ToolStripMenuItem();
            itemClose.Text = "Luk";
            itemClose.ShortcutKeyDisplayString = "Alt+F4"; // Alt+F4 is already implemented to close current program, so we are not changing the shortcut, but adding text instead
            itemClose.Click += Menu_Close_click;

            // Add items to the file menu
            fileMenu.DropDownItems.Add(itemNew);
            fileMenu.DropDownItems.Add(itemOpen);
            fileMenu.DropDownItems.Add(itemSaveAs);
            fileMenu.DropDownItems.Add(separator1);
            fileMenu.DropDownItems.Add(itemClose);
        }

        public void this_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Z)
            {
                Bitmap currentBitmap = _canvas.Bitmap;
                _canvas.Replace(_previousBitmap);
                _previousBitmap = currentBitmap;
            }
        }

        public void Menu_New_click(object sender, EventArgs e)
        {
            _canvas.Clear();
        }

        public void Menu_Open_click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _canvas.Open(openFileDialog.FileName);
            }
        }
        public void Menu_SaveAs_click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _canvas.Save(saveFileDialog.FileName);
            }
        }
        public void Menu_Close_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void CanvasView_MouseDown(object sender, MouseEventArgs e)
        {
            _previousBitmap = _canvas.Bitmap.Clone() as Bitmap;

            _tool.OnMouseDown(sender, e);
        }

        public void CanvasView_MouseUp(object sender, MouseEventArgs e)
        {
            _tool.OnMouseUp(sender, e);
        }

        public void CanvasView_MouseMove(object sender, MouseEventArgs e)
        {
            _tool.OnMouseMove(sender, e);
        }

        public void ToolView_Click(object sender, EventArgs e)
        {
            ToolView toolView = (sender as Label).Parent as ToolView;
            if (toolView.Tool != null)
            {
                _tool = toolView.Tool;
                _toolsView.UpdateOptions(_tool);
            }

            else if (toolView.OptionDialog != null)
            {
                DialogResult result = toolView.OptionDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SizeDialog sizeDialog = toolView.OptionDialog as SizeDialog;
                    ColorDialog colorDialog = toolView.OptionDialog as ColorDialog;

                    if (sizeDialog != null)
                    {
                        _tool.Size = sizeDialog.Size;
                        toolView.Label.Text = "Size: " + sizeDialog.Size;
                    }
                    else if (colorDialog != null)
                    {
                        _tool.Color = colorDialog.Color;
                        toolView.BackColor = colorDialog.Color;
                    }
                }
            }
        }
    }
}
