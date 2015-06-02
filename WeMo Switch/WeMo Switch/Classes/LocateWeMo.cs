using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.NetworkInformation;
using WeMo_Switch.Classes;
using System.Windows.Forms;

namespace WeMo_Switch.Classes
{

    // Searches for WeMo devices from 192.168.0.1 to 192.168.255.254
    class LocateWeMo
    {
        private List<WeMo> WeMoList = new List<WeMo>();

        /*
         * Functions
         * 
        */

        // SUPER SLOW!!
        public void findAllDevices(ref TextBox txtResults, ref ProgressBar progFind)
        {
            for (int ip3 = 0; ip3 <= 255; ip3++)
            {
                for (int ip4 = 1; ip4 <= 254; ip4++)
                {
                    progFind.PerformStep();
                    WeMo tmpWeMo = new WeMo();
                    tmpWeMo.setBaseURL("192.168." + ip3.ToString() + "." + ip4.ToString());

                    // current time
                    DateTime now = DateTime.Now;

                    if (PingHost("192.168." + ip3.ToString() + "." + ip4.ToString()))
                    {
                        if (tmpWeMo.isWeMo("192.168." + ip3.ToString() + "." + ip4.ToString()))
                        {
                            Console.WriteLine("Found a WeMo at " + tmpWeMo.getBaseURL() + "  -- TIME: " + now);
                            txtResults.Text += "Found a WeMo at " + tmpWeMo.getBaseURL() + "\r\n";
                        }
                        else
                        {
                            Console.WriteLine("Not a WeMo at " + tmpWeMo.getBaseURL() + "  -- TIME: " + now);
                            txtResults.Text += "Not a WeMo at " + tmpWeMo.getBaseURL() + "\r\n";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid IP at " + tmpWeMo.getBaseURL() + "  -- TIME: " + now);
                        txtResults.Text += "Invalid IP at " + tmpWeMo.getBaseURL() + "\r\n";
                    }
                    
                    
                }
            }

        }

        public int getNumOfIPCombinations()
        {
            int count = 0;
            for (int ip3 = 0; ip3 <= 255; ip3++)
            {
                for (int ip4 = 1; ip4 <= 254; ip4++)
                {
                    count++;
                }
            }
            return count;
        }

        // Source: http://stackoverflow.com/questions/11800958/using-ping-in-c-sharp
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }

    }
}
