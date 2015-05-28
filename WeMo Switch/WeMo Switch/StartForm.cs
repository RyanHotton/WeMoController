﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try {
                newForm.ShowDialog();
            }
            catch {

            }
            this.Cursor = Cursors.Default;
            this.Show();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}