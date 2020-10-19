using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CodeProjectWin
{
    public class GenerateName
    {
        private readonly string[] _firstNames = new [] { "Bill", "Robert", "Eric", "Barry", "Sean", "Michael", "Roger", "Fanya", "Ahmed", "Alolita", "Partha", "Alasdair", "Ipke", "Wim", "Peter", "Gerhard", "Cathy", "Susanne", "Anita", "Danese" };

        private readonly string[] _lastNames = new [] { "Gates", "Kozma", "Horvitz", "Smith", "McGrath", "Montalbano", "Sisson", "Montalvo", "Elmagarmid", "Sharma", "Niyogi", "Turner", "Wachsmuth", "Sweldens", "Norton", "Fischer", "Hudgins", "Albers", "Borg", "Cooper" };

        private readonly string[] _midleNames = new [] { "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J.", "K.", "L.", "M.", "N.", "O.", "P.", "Q.", "R.", "S.", "T.", "U.", "V.", "W.", "X.", "Y.", "Z." };

        public List<string> FullNames()
        {
            var temp1 = new List<string>();
            var temp2 = new List<string>();

            for (int i = 0; i < 20; i++)
                temp1.Add(string.Format("{0} {1}", _firstNames[i], _lastNames[i]));

            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 26; j++)
                    for (int k = 0; k < 20; k++)
                        temp2.Add(string.Format("{0} {1} {2}", _firstNames[i], _midleNames[j], _lastNames[k]));

            var rnd = new Random();
            temp2 = temp2.OrderBy(s => rnd.Next()).ToList();

            temp1.AddRange(temp2);

            return temp1;
        }
    }


public class HostApplication
    {
        private const int PORT_MIN_VALUE = 1;
        private const int PORT_MAX_VALUE = 65535;
        public bool IsHost { get; set; }

        public string Host { get; set; }

        public int MinPort { get; } = PORT_MIN_VALUE;
        public int MaxPort { get; } = PORT_MAX_VALUE;

        public ReadOnlyCollection<int> OpenPorts => new ReadOnlyCollection<int>(_openPorts);
        public ReadOnlyCollection<int> ClosedPorts => new ReadOnlyCollection<int>(_closedPorts);

        private List<int> _openPorts;
        private List<int> _closedPorts;

        public HostApplication()
        {
            SetupLists();
        }
        public HostApplication(string host, int minPort, int maxPort)
        {
            if (minPort > maxPort)
                throw new ArgumentException("Min port cannot be greater than max port");

            if (minPort < PORT_MIN_VALUE || minPort > PORT_MAX_VALUE)
                throw new ArgumentOutOfRangeException(
                    $"Min port cannot be less than {PORT_MIN_VALUE} " +
                    $"or greater than {PORT_MAX_VALUE}");

            if (maxPort < PORT_MIN_VALUE || maxPort > PORT_MAX_VALUE)
                throw new ArgumentOutOfRangeException(
                    $"Max port cannot be less than {PORT_MIN_VALUE} " +
                    $"or greater than {PORT_MAX_VALUE}");

            Host = host;
            MinPort = minPort;
            MaxPort = maxPort;

            SetupLists();
        }


        private void SetupLists()
        {
            // set up lists with capacity to hold half of range
            // since we can't know how many ports are going to be open
            // so we compromise and allocate enough for half

            // rangeCount is max - min + 1
            int rangeCount = (MaxPort - MinPort) + 1;

            // if there are an odd number, bump by one to get one extra slot
            if (rangeCount % 2 != 0)
            {
                rangeCount += 1;
            }

            // reserve half the ports in the range for each
            _openPorts = new List<int>(rangeCount / 2);
            _closedPorts = new List<int>(rangeCount / 2);
        }

        internal class PortScanResult
        {
            public int PortNum { get; set; }
            public bool IsPortOpen { get; set; }
        }

           public  void Scan()
        {
            for (int port = MinPort; port <= MaxPort; port++)
            {
                if (IsPortOpen(port))
                {
                    _openPorts.Add(port);
                }
                else
                {
                    _closedPorts.Add(port);  
                }


            }
       }
        public  bool IsPortOpen(int port)
        {
            Socket socket = null;

            try
            {
                // make a TCP based socket
                socket = new Socket(AddressFamily.InterNetwork, SocketType
                    .Stream, ProtocolType.Tcp);

                // connect
                socket.Connect(Host, port);

                return true;
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionRefused)
                {
                    return false;
                }

                //An error occurred when attempting to access the socket
              
                Console.WriteLine(ex);
            }
            finally
            {
                if (socket?.Connected ?? false)
                {
                    socket?.Disconnect(false);
                }
                socket?.Close();
            }

            return false;
        }
    }


    public class IPEnumeration : IEnumerable
    {
        private string startAddress;
        private string endAddress;

        internal static Int64 AddressToInt(IPAddress addr)
        {
            byte[] addressBits = addr.GetAddressBytes();

            Int64 retval = 0;
            for (int i = 0; i < addressBits.Length; i++)
            {
                retval = (retval << 8) + (int)addressBits[i];
            }

            return retval;
        }

        internal static Int64 AddressToInt(string addr)
        {
            return AddressToInt(IPAddress.Parse(addr));
        }

        internal static IPAddress IntToAddress(Int64 addr)
        {
            return IPAddress.Parse(addr.ToString());
        }


        public IPEnumeration(string startAddress, string endAddress)
        {
            this.startAddress = startAddress;
            this.endAddress = endAddress;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IPEnumerator GetEnumerator()
        {
            return new IPEnumerator(startAddress, endAddress);
        }

    }

    public class IPEnumerator : IEnumerator
    {
        private string startAddress;
        private string endAddress;
        private Int64 currentIP;
        private Int64 endIP;

        public IPEnumerator(string startAddress, string endAddress)
        {
            this.startAddress = startAddress;
            this.endAddress = endAddress;

            currentIP = IPEnumeration.AddressToInt(startAddress);
            endIP = IPEnumeration.AddressToInt(endAddress);
        }

        public bool MoveNext()
        {
            currentIP++;
            return (currentIP <= endIP);
        }

        public void Reset()
        {
            currentIP = IPEnumeration.AddressToInt(startAddress);
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public IPAddress Current
        {
            get
            {
                try
                {
                    return IPEnumeration.IntToAddress(currentIP);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
