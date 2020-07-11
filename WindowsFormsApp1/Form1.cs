using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetProcessBarValue(int v)
        {
            frmProgressWait.RefreshProgressbar(v);
        }
        Progressbar frmProgressWait;
        private void ShowProcessBar()
        {
            frmProgressWait = Progressbar.GetFrmProgressWait();
            frmProgressWait.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var saveTask = new Task(() => ShowProcessBar());
            saveTask.Start();
            Thread.Sleep(1000);
            SetProcessBarValue(5);
            Thread.Sleep(1000);
            SetProcessBarValue(10);
            Thread.Sleep(500);

            //excute some method

            SetProcessBarValue(15);
            Thread.Sleep(2000);
            SetProcessBarValue(25);
            Thread.Sleep(1000);
            SetProcessBarValue(55);
            Thread.Sleep(1000);
            SetProcessBarValue(85);
            Thread.Sleep(1000);
            SetProcessBarValue(100);
            frmProgressWait.CloseWaitingDialog();
        }
    }
}
