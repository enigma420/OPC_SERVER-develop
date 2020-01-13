using System;
using OPCServer1.Backend.Serwer;
using S7.Net;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCServer1.Backend.Serwer
{
    //S7-1200 => RACK:0 , SLOT:0
    public class S7NetPlusServerOPC : PlcS7NetLibraryInterface
    {

        Plc client;

        public S7NetPlusServerOPC(CpuType cpu, string ip, short rack, short slot)
        {
            client = new Plc(cpu, ip, rack, slot);
        }


        private ConnectionStatus _connectionStatus;

        public ConnectionStatus ConnectionStatus
        {
            get { return _connectionStatus; }
            private set { _connectionStatus = value; }
        }

        public void Connect()
        {
            ConnectionStatus = ConnectionStatus.Connecting;
            var error = client.Open();
            if(error != ErrorCode.NoError)
            {
                ConnectionStatus = ConnectionStatus.Offline;
                throw new Exception(error.ToString());
            }
            ConnectionStatus = ConnectionStatus.Online;
        }

        public void Disconnect()
        {
            ConnectionStatus = ConnectionStatus.Offline;
            client.Close();
        }

        public List<Tag> ReadItems(List<Tag> itemList)
        {
            if(this.ConnectionStatus != ConnectionStatus.Online)
            {
                throw new Exception("Can't read, Client is disconnected");
            }

            List<Tag> tags = new List<Tag>();
            foreach(var item in itemList)
            {
                Tag tag = new Tag(item.ItemName);
                var result = client.Read(item.ItemName);
                if (result is ErrorCode && (ErrorCode)result != ErrorCode.NoError)
                {
                    throw new Exception(((ErrorCode)result).ToString() + "\n" + "Tag: " + tag.ItemName);
                }
                tag.ItemValue = result;
                tags.Add(tag);
            }
            return tags;
        }

        public void WriteItems(List<Tag> itemList)
        {
            if(this.ConnectionStatus != ConnectionStatus.Online)
            {
                throw new Exception("Cant Write, Client is disconnected");
            }

            foreach(var tag in itemList)
            {
                object value = tag.ItemValue;
                if(tag.ItemValue is double)
                {
                    var bytes = S7.Net.Types.Double.ToByteArray((double)tag.ItemValue);
                    value = S7.Net.Types.DWord.FromByteArray(bytes);
                }
                else if(tag.ItemValue is bool)
                {
                    value = (bool)tag.ItemValue ? 1 : 0;
                }
                var result = client.Write(tag.ItemName, value);
                if(result is ErrorCode && (ErrorCode)result != ErrorCode.NoError)
                {
                    throw new Exception(((ErrorCode)result).ToString() + "\n" + "Tag: " + tag.ItemName);
                }
            }
        }

        public void ReadClass(object sourceClass, int db)
        {
            client.ReadClass(sourceClass, db);
        }

        public void WriteClass(object sourceClass, int db)
        {
            client.WriteClass(sourceClass, db);
        }















        //public string IpAddress { get; set; }
        //public int Rack { get; set; }
        //public int Slot { get; set; }
        //public string PlcLastErrorMessage { get; set; }

        //public Boolean connectionStatusPLC { get; set; }

        //private readonly Timer dataReadTimer;
        //private readonly Plc _s7Plc;
        //private readonly object _lockObject = new object();
        //private int _currentReadValue = 0;

        //public event EventHandler DataReadHandler;
        //public event EventHandler ConnectedHandler;
        //public event EventHandler DisconnectedHandler;
        //public event EventHandler ErrorHandler;

        //public S7NetPlusServerOPC()
        //{

        //}

        //public S7NetPlusServerOPC(int v, string ipAddress, int rack, int slot)
        //{
        //    IpAddress = ipAddress;
        //    Rack = rack;
        //    Slot = slot;

        //    _s7Plc = new Plc(CpuType.S71200, ipAddress, (short)Rack, (short)Slot);

        //    dataReadTimer = new Timer(500);
        //    dataReadTimer.Elapsed += DataReadTimer_Elapsed;
        //    dataReadTimer.Start();

        //}

        //public void RaiseDataReaded()
        //{
        //    DataReadHandler?.Invoke(this, new EventArgs());
        //}

        //public void RaiseIsConnected()
        //{
        //    ConnectedHandler?.Invoke(this, new EventArgs());
        //}

        //public void RaiseIsDisconnected()
        //{
        //    DisconnectedHandler?.Invoke(this, new EventArgs());
        //}

        //public void RaiseError()
        //{
        //    ErrorHandler?.Invoke(this, new EventArgs());
        //}

        //private void DataReadTimer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    if (!_s7Plc.IsConnected)
        //    {
        //        RaiseIsDisconnected();
        //        return;
        //    }

        //    //Do the read
        //    //lock (_lockObject)
        //    //{
        //    //    var readResult = ((ushort)_s7Plc.Read("DB10.DBW4")).ConvertToShort();
        //    //    _currentReadValue = readResult;
        //    //}
        //    RaiseDataReaded();
        //}

        //private bool IsPlcConnected()
        //{
        //    if (_s7Plc.IsConnected) return true;

        //    //PlcLastErrorMessage = "PLC is not connected";
        //    //RaiseError();
        //    //RaiseIsDisconnected();

        //    return false;
        //}

        //public bool Connect()
        //{
        //    //if (!_s7Plc.IsAvailable)
        //    //{
        //    //    PlcLastErrorMessage = "Connection not available";
        //    //    RaiseError();
        //    //}
        //    _s7Plc.Open();
        //    dataReadTimer.Start();
        //    return true;
        //}

        //public bool Disconnect()
        //{
        //    if (!IsPlcConnected()) return false;

        //    dataReadTimer.Stop();
        //    _s7Plc.Close();

        //    RaiseIsDisconnected();
        //    return true;
        //}

        //public bool SetStart()
        //{
        //    if (!IsPlcConnected()) return false;

        //    lock (_lockObject)
        //    {
        //        _s7Plc.Write("DB10.DBX0.0", 1);

        //    }
        //    return true;
        //}

        //public bool SetStop()
        //{
        //    if (!IsPlcConnected()) return false;

        //    lock (_lockObject)
        //    {
        //      _s7Plc.Write("DB10.DBX0.1", 1);
        //    }
        //    return true;
        //}

        //public bool SetSetPoint(int value)
        //{
        //    if (!IsPlcConnected()) return false;

        //    lock (_lockObject)
        //    {
        //        _s7Plc.Write("DB10.DBW2", ((ushort)value).ConvertToShort());

        //    }
        //    return true;
        //}

        //public int GetLastReadedValue()
        //{
        //    return _currentReadValue;
        //}


        //private static void ReadSingleVariables(Plc plc)
        //{

        //    Console.WriteLine("\n--- DB 3 ---\n");

        //    var db3Bool1 = (bool)plc.Read("DB3.DBX0.0");
        //    Console.WriteLine("DB3.DBX0.0: " + db3Bool1);

        //    var db3Bool2 = (bool)plc.Read("DB3.DBX0.1");
        //    Console.WriteLine("DB3.DBX0.1: " + db3Bool2);


        //}
    }
}
