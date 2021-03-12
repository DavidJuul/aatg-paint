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
        public Form1()
        {
            InitializeComponent();


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


            // Add ToolStripMenuItem to the MainMenu with properties
            ToolStripMenuItem fileMenu = new ToolStripMenuItem();

            fileMenu.Text = "Filer";

            mainMenu.Items.Add(fileMenu);

        }
    }
}
