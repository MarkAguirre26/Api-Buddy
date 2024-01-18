using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Api_Buddy
{
    public partial class LoadingForm : Form
    {
      
        public LoadingForm()
        {
            InitializeComponent();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fmain.TerminateGitBash();
            
            this.Close();
        }


        public void SetMessage(string message)
        {
            if (labelMessage.InvokeRequired)
            {
                labelMessage.Invoke((Action)(() => labelMessage.Text = message));
            }
            else
            {
                labelMessage.Text = message;

            }
        }

        public void CloseWaitForm()
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => Close()));
            }
            else
            {
                Close();
            }
        }



    }
}
