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

        public ControllerForm(string ipAddr)
        {
            InitializeComponent(); 
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
            lblStatus.Text = myWeMo.getStatus(ref btnOff, ref btnOn);
            Console.WriteLine("WeMo Status: " + myWeMo.getWeMo_Status());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    }
}
