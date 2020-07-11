using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Progressbar : Form
    {     

        private static Progressbar frmProgressWait;

        private delegate void SetProgressBarHander(int value);

        private SetProgressBarHander setProgressBarHander;
        private Progressbar()
        {
            InitializeComponent();
            setProgressBarHander = new SetProgressBarHander(SetProgressBarValue);
        }
        public static Progressbar GetFrmProgressWait()
        {
            if (frmProgressWait == null || frmProgressWait.IsDisposed)
            {
                frmProgressWait = new Progressbar();
            }
            return frmProgressWait;
        }
        private void SetProgressBarValue(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(setProgressBarHander, value);
            }
            else
            {
                progressBar1.Value = value;
            }
        }
        public void RefreshProgressbar(int v)
        {
            SetProgressBarValue(v);
        }


        public void CloseWaitingDialog()
        {
            BeginInvoke(new Action(() =>
            {
                this.Close();
            }));
        }
    }
}
