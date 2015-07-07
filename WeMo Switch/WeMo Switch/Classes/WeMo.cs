using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Xml;

namespace WeMo_Switch.Classes
{
    class WeMo
    {
        private const string COMMAND_OFF = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>0</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
        private const string COMMAND_ON = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>1</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
        private const string COMMAND_GET = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:GetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""></u:GetBinaryState></s:Body></s:Envelope>";
        private const string port = "49153";              // typical port
        private string baseURL = "192.168.2.36";    // your WeMo IP
        private string WeMo_Status;

        // for the future http://192.168.2.36:49153/setup.xml

        /*
         * CONSTRUCTOR 
        */

        /*
         * FUNCTIONS:
         * All WeMo class functions.
         * 
        */

        public bool isWeMo(string IPAddr)
        {
            this.setBaseURL(IPAddr);
            try
            {
                return this.checkWeMo();
            }
            catch
            {
                return false;
            }
        }

        private bool checkWeMo()
        {
            string targetUrl = "http://" + this.baseURL + ":" + port + "/upnp/control/basicevent1";
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
                        string status = getStatusFromXML(result);
                        if (status == "0" || status == "1")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }
        }

        public void SendPowerCommand(string command)
        {
            //
            //  Pull presentation URL from device and extract IP and PORT
            //

            //
            //  Build new target URL including the basicevent1 path
            //
            string targetUrl = "http://" + this.baseURL + ":" + port + "/upnp/control/basicevent1";

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

        /*
         *  Getters: 
         *  All the Getters for the WeMo class
        */

        public string getStatus(ref Button btnOff, ref Button btnOn)
        {
            //
            //  Pull presentation URL from device and extract IP and PORT
            //

            //
            //  Build new target URL including the basicevent1 path
            //
            string targetUrl = "http://" + this.baseURL + ":" + port + "/upnp/control/basicevent1";

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
                        return getStatusName(getStatusFromXML(result), ref btnOff, ref btnOn);
                    }
                }

            }

        }

        // NOTE: implement for the future to not hard code icon.jpg, since it can be renamed
        // and another file format.
        public void getWeMoIcon(ref PictureBox picIcon)
        {
            string iconURL = "http://" + this.baseURL + ":" + port + "/icon.jpg";
            var request = WebRequest.Create(iconURL);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                picIcon.Image = Bitmap.FromStream(stream);
            }
        }

        private string getStatusFromXML(string statusXML)
        {
            // load xml
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(statusXML);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("BinaryState");
            //Console.WriteLine(elemList[0].InnerXml);
            return (string)elemList[0].InnerXml;

        }

        private string getStatusName(string status, ref Button btnOff, ref Button btnOn)
        {
            string name = "";

            btnOff.Enabled = true;
            btnOn.Enabled = true;

            switch (status)
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

            this.setWeMo_Status(name);
            return name;
        }

        public string getCommandOff()
        {
            return COMMAND_OFF;
        }

        public string getCommandOn()
        {
            return COMMAND_ON;
        }

        public string getCommandGet()
        {
            return COMMAND_GET;
        }

        public string getPort()
        {
            return port;
        }

        public string getBaseURL()
        {
            return this.baseURL;
        }

        public string getWeMo_Status()
        {
            return this.WeMo_Status;
        }

        /*
         *  Setters: 
         *  All the Setters for the WeMo class
        */
        public void setBaseURL(string IPAddr)
        {
            this.baseURL = IPAddr;
        }

        public void setWeMo_Status(string name)
        {
            this.WeMo_Status = name;
        }
    }
}
