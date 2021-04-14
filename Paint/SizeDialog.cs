using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class SizeDialog : CommonDialog
    {
        public int Size { get; private set; }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("", "Size", Size.ToString());

            try
            {
                Size = Int32.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public override void Reset()
        {
            Size = 0;
        }
    }
}
