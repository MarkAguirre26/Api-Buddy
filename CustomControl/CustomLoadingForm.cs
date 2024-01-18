using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Buddy.CustomControl
{
    public class CustomLoadingForm
    {
        private LoadingForm waitForm;
       
        public CustomLoadingForm()
        {
           
            waitForm = new LoadingForm();
            //waitForm.StartPosition = FormStartPosition.CenterParent;
            waitForm.TopMost = true;
          
        }


        public void Show(Form parent, String msg)
        {
            waitForm.StartPosition = FormStartPosition.Manual;
            waitForm.Location = new System.Drawing.Point(parent.Location.X + parent.Width / 2 - waitForm.Width / 2,
                parent.Location.Y + parent.Height / 2 - waitForm.Height / 2);
            waitForm.SetMessage(msg);


            Thread waitThread = new Thread(() =>
            {
                if (!waitForm.IsDisposed)
                {
                    Application.Run(waitForm);
                }
            });

            waitThread.Start();

        }
        //
        public void setMessage(string msg)
        {
            waitForm.SetMessage(msg);

        }

        public void Close()
        {
            if (waitForm != null && !waitForm.IsDisposed)
            {
                waitForm.CloseWaitForm();
            }


        }

    }
}
