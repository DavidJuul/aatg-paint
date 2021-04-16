using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class TextDialog : CommonDialog
    {
        public string Text { get; set; }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            Text = Microsoft.VisualBasic.Interaction.InputBox("", "Tekst", Text);
            return true;
        }

        public override void Reset()
        {
            Text = "";
        }
    }
}
