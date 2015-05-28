﻿using System;
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




namespace WeMo_Switch
{
    public partial class Form1 : Form
    {
        const string COMMAND_OFF = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>0</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
        const string COMMAND_ON = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>1</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
        const string COMMAND_GET = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:GetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""></u:GetBinaryState></s:Body></s:Envelope>";
        private string WeMo_Status;
        private Timer Timer_Status;
        private string port = "49153";              // typical port
        private string baseUrl = "192.168.2.28";    // your WeMo IP

        public Form1(string ipAddr)
        {
            InitializeComponent(); ;
            baseUrl = ipAddr;

            try
            {
                lblStatus.Text = getStatus();
                InitTimer();
            }
            catch
            {
                MessageBox.Show("Invalid IP Address");
                this.Close();
            }
           
        }

        private string getStatus()
        {
            //
            //  Pull presentation URL from device and extract IP and PORT
            //

            //
            //  Build new target URL including the basicevent1 path
            //
            string targetUrl = "http://" + baseUrl + ":" + port + "/upnp/control/basicevent1";

            //
            //  Create the packet and payload to send to the endpoint to get the switch to process the command
            //
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "\"urn:Belkin:service:basicevent:1#GetBinaryState\"");
            request.ContentType = @"text/xml; charset=""utf-8""";
            request.KeepAlive = false;
            Byte[] bytes = UTF8Encoding.ASCII.GetBytes(COMMAND_GET);
            request.ContentLength = bytes.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd(); // do something fun...
                        return getStatusName(getStatusFromXML(result));
                    }
                }
                
            }

        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            SendCommand(COMMAND_ON);
            lblStatus.Text = getStatus();
        }

        private void SendCommand(string command)
        {
            //
            //  Pull presentation URL from device and extract IP and PORT
            //

            //
            //  Build new target URL including the basicevent1 path
            //
            string targetUrl = "http://" + baseUrl + ":" + port + "/upnp/control/basicevent1";

            //
            //  Create the packet and payload to send to the endpoint to get the switch to process the command
            //
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            request.Method = "POST";
            request.Headers.Add("SOAPAction", "\"urn:Belkin:service:basicevent:1#SetBinaryState\"");
            request.ContentType = @"text/xml; charset=""utf-8""";
            request.KeepAlive = false;
            Byte[] bytes = UTF8Encoding.ASCII.GetBytes(command);
            request.ContentLength = bytes.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                request.GetResponse();
            }

            //
            //  HACK: If we don't abort the result the device holds on to the connection sometimes and prevents other commands from being received
            //
            request.Abort();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            SendCommand(COMMAND_OFF);
            lblStatus.Text = getStatus();
        }

        private string getStatusFromXML(string statusXML)
        {
            // load xml
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(statusXML);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("BinaryState");
            Console.WriteLine(elemList[0].InnerXml);
            return (string)elemList[0].InnerXml;
 
        }

        private string getStatusName(string status)
        {
            string name = "";

            btnOff.Enabled = true;
            btnOn.Enabled = true;

            switch(status)
            {
                case "1":
                    name = "ON";
                    btnOn.Enabled = false;
                    break;
                case "0":
                    name = "OFF";
                    btnOff.Enabled = false;
                    break;
                default:
                    name = "ERROR";
                    break;
            }

            WeMo_Status = name;
            return name;
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
            Console.WriteLine("Checking WeMo Status...");
            lblStatus.Text = getStatus();
        }

    }
}