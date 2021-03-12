using System;
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
            AddMenuStripItem("Ny", fileMenu);
            AddMenuStripItem("Åbn", fileMenu);
            //AddMenuStripItem("Gem", fileMenu);
            //AddMenuStripItem("Gem som", fileMenu);

            // seperator 
            ToolStripSeparator separator1 = new ToolStripSeparator();
            fileMenu.DropDownItems.Insert(fileMenu.DropDownItems.Count, separator1);


            string[] test = { "Gem", "Gem som" };

            AddMenuStripRange(test, fileMenu);


            mainMenu.Items.Add(fileMenu);
        }
        
        // test for multiple use cases
        // inspiration from https://stackoverflow.com/questions/1757574/dynamically-adding-toolstripmenuitems-to-a-menustrip-c-winforms
        void AddMenuStripRange(string[] texts, ToolStripMenuItem menu)
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[texts.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Text = texts[i];
            }

            menu.DropDownItems.AddRange(items);
        }
        
        void AddMenuStripItem(string text, ToolStripMenuItem menu)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            // item.Image 
            // item.ShortcutKeys
            // item.ShowShortcutKeys
            // TODO flere egenskaber

            // TODO eventhandler logik

            menu.DropDownItems.Insert(menu.DropDownItems.Count, item);
        }
    }
}
