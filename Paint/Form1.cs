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
        private Tool _tool;

        public Form1()
        {
            InitializeComponent();

            // Create and add a new Canvas.
            _canvas = new Canvas();
            Controls.Add(_canvas.View);

            _tool = new BrushTool();

            // ---------------- Main menu that holds multiple menu items -------
            MenuStrip mainMenu = new MenuStrip();

            // fileMenu colors
            mainMenu.BackColor = Color.LightGray;
            mainMenu.ForeColor = Color.Black;

            mainMenu.Font = new Font("Roboto", 16);
            mainMenu.Text = "Menu";

            this.MainMenuStrip = mainMenu;
            Controls.Add(mainMenu);
            // ---------------- end -------


            // Add ToolStripMenuItem to the MainMenu with sub items
            ToolStripMenuItem fileMenu = new ToolStripMenuItem();
            fileMenu.Text = "Filer";
            AddFileMenuItems(fileMenu);

            mainMenu.Items.Add(fileMenu);
        }

        void AddFileMenuItems(ToolStripMenuItem fileMenu)
        {
            // Create needed menu items
            ToolStripMenuItem itemNew = new ToolStripMenuItem();
            itemNew.Text = "Ny";
            itemNew.ShortcutKeys = Keys.Control | Keys.N;
            itemNew.ShowShortcutKeys = true;
            itemNew.Click += Menu_New_click;

            ToolStripMenuItem itemOpen = new ToolStripMenuItem();
            itemOpen.Text = "Åbn";
            itemOpen.ShortcutKeys = Keys.Control | Keys.O;
            itemOpen.ShowShortcutKeys = true;
            itemOpen.Click += Menu_Open_click;

            ToolStripMenuItem itemSaveAs = new ToolStripMenuItem();
            itemSaveAs.Text = "Gem som";
            itemSaveAs.ShortcutKeys = Keys.Control | Keys.S;
            itemSaveAs.ShowShortcutKeys = true;
            itemSaveAs.Click += Menu_SaveAs_click;

            ToolStripSeparator separator1 = new ToolStripSeparator();

            ToolStripMenuItem itemClose = new ToolStripMenuItem();
            itemClose.Text = "Luk";
            itemClose.ShortcutKeyDisplayString = "Alt+F4"; // Alt+F4 is already implemented to close current program, so we are not changing the shortcut, but adding text instead
            itemClose.ShowShortcutKeys = true;
            itemClose.Click += Menu_SaveAs_click;

            // Add items to the file menu
            fileMenu.DropDownItems.Add(itemNew);
            fileMenu.DropDownItems.Add(itemOpen);
            fileMenu.DropDownItems.Add(itemSaveAs);
            fileMenu.DropDownItems.Add(separator1);
            fileMenu.DropDownItems.Add(itemClose);
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

        public void CanvasView_MouseDown(object sender, MouseEventArgs e)
        {
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
    }
}
