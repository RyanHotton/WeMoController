using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using WeMo_Switch.Classes;
using System.Windows.Forms;
using System.Net.NetworkInformation;

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

        // Need to find a way to detect all WeMo devices.
        public void findAllDevices(ref TextBox txtResults, ref ProgressBar progFind)
        {
            progFind.Value = 0;
            for (int i = 0; i < progFind.Maximum; i++)
            {
                progFind.PerformStep();
            }
            txtResults.Text = "In Progress...";
        }

    }
}
