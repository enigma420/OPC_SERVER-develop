using OPCServer1.Backend.Database;
using OPCServer1.Backend.Serwer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using S7.Net;

namespace OPCServer1.Backend
{
    class Plc
    {
        //Singleton

        private static readonly Lazy<Plc> _instance = new Lazy<Plc>(() => new Plc());

        public static Plc instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public ConnectionStatus ConnectionState { get { return plcDriver != null ? plcDriver.ConnectionStatus : ConnectionStatus.Offline; } }


        public DB3 Db3 { get; set; }

        public TimeSpan CycleReadTime { get; private set; }



        

        S7NetPlusServerOPC plcDriver;

        System.Timers.Timer timer = new System.Timers.Timer();

        public DateTime lastReadTime;

       

        private Plc()
        {
            Db3 = new DB3();
            timer.Interval = 1; // ms
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
            lastReadTime = DateTime.Now;
        }

        

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (plcDriver == null || plcDriver.ConnectionStatus != ConnectionStatus.Online)
            {
                return;
            }

            timer.Enabled = false;
            CycleReadTime = DateTime.Now - lastReadTime;
            try
            {
                RefreshTags();
            }
            finally
            {
                timer.Enabled = true;
                lastReadTime = DateTime.Now;
            }
        }


        public void Connect(string ipAddress)
        {
            if (!IsValidIp(ipAddress))
            {
                throw new ArgumentException("Ip address is not valid");
            }
            plcDriver = new S7NetPlusServerOPC(CpuType.S71200, ipAddress, 0, 1);
            plcDriver.Connect();
        }

        public void Disconnect()
        {
            if (plcDriver == null || this.ConnectionState == ConnectionStatus.Offline)
            {
                return;
            }
            plcDriver.Disconnect();
        }

        public void Write(string name, object value)
        {
            if (plcDriver == null || plcDriver.ConnectionStatus != ConnectionStatus.Online)
            {
                return;
            }
            Tag tag = new Tag(name, value);
            List<Tag> tagList = new List<Tag>();
            tagList.Add(tag);
            plcDriver.WriteItems(tagList);
        }

        public void Write(List<Tag> tags)
        {
            if (plcDriver == null || plcDriver.ConnectionStatus != ConnectionStatus.Online)
            {
                return;
            }
            plcDriver.WriteItems(tags);
        }

    

    

        private bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }

        private void RefreshTags()
        {
            plcDriver.ReadClass(Db3, 1);
        }
    }
}
