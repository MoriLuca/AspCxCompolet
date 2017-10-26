using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMRON.Compolet.CIP;

namespace CXCompolet_ASP.Classes
{
    public static class PLC_NJ
    {
        public static NJCompolet plc = new NJCompolet();
        public static bool connesso = false;

        public static bool CheckConnection()
        {
            plc.PeerAddress = "192.168.250.1";
            plc.LocalPort = 2;
            plc.Active = true;
            connesso = plc.IsConnected;
            plc.Active = false;
            return connesso;
        }

        public static int GetNumber(int Worker)
        {
            int number = 0;
            plc.PeerAddress = "192.168.250.1";
            plc.LocalPort = 2;
            plc.Active = true;
            number = (int)plc.ReadVariable($"Workers.AutoIncrementUpTo{Worker}");
            plc.Active = false;
            return number;
        }

    }
}