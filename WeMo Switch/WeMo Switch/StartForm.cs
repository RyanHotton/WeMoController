using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeMo_Switch.Classes;

namespace WeMo_Switch
{
    public partial class StartForm : Form
    {
        private string ipAddr;

        public StartForm()
        {
            InitializeComponent();
            txtIPAddr.Text = "192.168.2.28";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ipAddr = txtIPAddr.Text;
            this.Cursor = Cursors.WaitCursor;
            Form1 newForm = new Form1(ipAddr);
            this.Hide();
            try
            {
                newForm.ShowDialog();
            }
            catch
            {

            }
            this.Cursor = Cursors.Default;
            this.Show();

            
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnRefresh.Enabled = false;
            //txtResults.Cursor = Cursors.WaitCursor;
            LocateWeMo pingTest = new LocateWeMo();
            pingTest.findAllDevices(ref txtResults);
            btnRefresh.Enabled = true;
            //txtResults.Cursor = Cursors.IBeam;
            this.Cursor = Cursors.Default;
        }
    }
}
