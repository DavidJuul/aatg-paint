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

        public Form1()
        {
            InitializeComponent();

            // Create and add a new Canvas.
            _canvas = new Canvas();
            Controls.Add(_canvas.View);
        }
    }
}
