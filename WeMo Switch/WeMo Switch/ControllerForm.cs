using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Xml;
using WeMo_Switch.Classes;



namespace WeMo_Switch
{
    public partial class ControllerForm : Form
    {
        private Timer Timer_Status;
        private WeMo myWeMo = new WeMo();
        private bool disableBool = false;

        public ControllerForm(string ipAddr)
        {
            InitializeComponent();
            lblVersion.Text = Program.devVersion;
            myWeMo.setBaseURL(ipAddr);
            try
            {
                myWeMo.getWeMoIcon(ref picIcon);
                lblStatus.Text = myWeMo.getStatus(ref btnOff, ref btnOn);
                InitTimer();
            }
            catch
            {
                MessageBox.Show("Invalid IP Address");
                this.Close();
            }
           
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            myWeMo.SendPowerCommand(myWeMo.getCommandOn());
            lblStatus.Text = myWeMo.getStatus(ref btnOff, ref btnOn);
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            myWeMo.SendPowerCommand(myWeMo.getCommandOff());
            lblStatus.Text = myWeMo.getStatus(ref btnOff, ref btnOn);
        }

        public void InitTimer()
        {
            Timer_Status = new Timer();
            Timer_Status.Tick += new EventHandler(Timer_Status_Tick);
            Timer_Status.Interval = 2000; // in miliseconds
            Timer_Status.Start();
        }

        private void Timer_Status_Tick(object sender, EventArgs e)
        {
            disableButtons();
            Console.WriteLine("WeMo Status: " + myWeMo.getWeMo_Status());
        }

        private void disableButtons()
        {
            lblStatus.Text = myWeMo.getStatus(ref btnOff, ref btnOn);
            if (disableBool)
            {
                btnOff.Enabled = false;
                btnOn.Enabled = false;
            }
        }

        private void ControllerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void chkDisable_CheckedChanged(object sender, EventArgs e)
        {
            disableBool = chkDisable.Checked;
            disableButtons();
        }

    }
}
