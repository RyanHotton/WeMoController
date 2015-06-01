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

        public void findAllDevices(ref TextBox txtResults)
        {
            for (int ip3 = 0; ip3 <= 255; ip3++)
            {
                for (int ip4 = 1; ip4 <= 254; ip4++)
                {
                    WeMo tmpWeMo = new WeMo();
                    if (tmpWeMo.isWeMo("192.168." + ip3.ToString() + "." + ip4.ToString()))
                    {
                        Console.WriteLine("Found a WeMo at " + tmpWeMo.getBaseURL());
                        txtResults.Text += "Found a WeMo at " + tmpWeMo.getBaseURL() + "\r\n";
                    }
                    else
                    {
                        Console.WriteLine("Not a WeMo at " + tmpWeMo.getBaseURL());
                        txtResults.Text += "Not a WeMo at " + tmpWeMo.getBaseURL() + "\r\n";
                    }
                    
                }
            }

        }

    }
}
