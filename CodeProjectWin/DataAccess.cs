using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net;
using System.ComponentModel;

namespace CodeProjectWin
{
    class BackgroundWorkerState
    {
        public string workerId { get; set; }
        public List<IPAddress> IPAddresses { get; set; } = new List<IPAddress>();
       

    }
    public class DataAccess
    {
        private readonly Random _random = new Random();
        private int _counter;

        public BackgroundWorker[] bw = null;
        BackgroundWorkerState[] d1 = null;
        

        private readonly List<string> _names;
        public DataAccess()
        {
            _names = new GenerateName().FullNames();
        }

        public static ObservableCollection<HostValue> Data = new ObservableCollection<HostValue>();

        public static int value = 0;

        public ObservableCollection<HostValue> Select()
        {
            var temp = new ObservableCollection<HostValue>();

            foreach (HostValue s in Data)
            {
                temp.Add(s);
            }

            return temp;
        }

        public void Update(ObservableCollection<HostValue> data)
        {
            value++;
          
            Data = new ObservableCollection<HostValue>();

            string[] temp = null;
           
            temp = data[0].Value.Split(new string[] { "-" }, StringSplitOptions.None);
            foreach (HostValue s in data)
            {
                Data.Add(s);
                
           
            }

            //  var k = _random.Next(0, 3);

            //for (var i = 0; i <int.Parse(temp[2]); i++)
            //{
            //    //Data.Add(new HostValue(_names[_counter],"","",false,false));
            //    //_counter = (_counter >= _names.Count()) ? 0 : _counter + 1;
            //}

            if (value > 1)
            {
                return;
            }

            int loadBalance = int.Parse(temp[2]);
            

            bw = new BackgroundWorker[loadBalance];
            d1 = new BackgroundWorkerState[loadBalance];
          
            int sayac = 0;
            foreach (IPAddress addr in new IPEnumeration(temp[0], temp[1]))
            {
                //HostApplication h = new HostApplication(addr.ToString(), 10, 100);
                if (d1[sayac % loadBalance]==null)
                {
                    d1[sayac % loadBalance] = new BackgroundWorkerState();
                }
                d1[sayac % loadBalance].IPAddresses.Add(addr);
                d1[sayac % loadBalance].workerId = "bg_" + (sayac % loadBalance).ToString();

                sayac++;

            }

            for (int i = 0; i < loadBalance; i++)
            {

                bw[i] = new BackgroundWorker();
                bw[i].WorkerSupportsCancellation = true;
                bw[i].WorkerReportsProgress = true;
                bw[i].DoWork += DataAccess_DoWork;
                bw[i].RunWorkerCompleted += DataAccess_RunWorkerCompleted;

                Tuple<int, BackgroundWorkerState> tuple = new Tuple<int, BackgroundWorkerState>(i, d1[i]);
                bw[i].RunWorkerAsync(tuple);
            }

        
        }

        private void DataAccess_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            Tuple<int, BackgroundWorkerState> tuple = (Tuple<int, BackgroundWorkerState>)e.Argument;

            if (bw[tuple.Item1].CancellationPending)
            {
                e.Cancel = true;

            }
            ObservableCollection<HostValue> data = new ObservableCollection<HostValue>();
            for (int i = 0; i < tuple.Item2.IPAddresses.Count; i++)
            {

                HostApplication h = new HostApplication(tuple.Item2.IPAddresses[i].ToString(), 75, 76);
                h.Scan();

                for (int k = 0; k < h.ClosedPorts.Count; k++)
                {
                    data.Add(new HostValue(tuple.Item2.workerId.ToString(), tuple.Item2.IPAddresses[i].ToString(), h.ClosedPorts[k].ToString(), false, true));
                    Data.Add(new HostValue(tuple.Item2.workerId.ToString(), tuple.Item2.IPAddresses[i].ToString(), h.ClosedPorts[k].ToString(), false, true));
                    if (DatabaseUpdated != null)
                        DatabaseUpdated(Data);

                }

                //for (int k = 0; k < h.OpenPorts.Count; k++)
                //{
                //    data.Add(new HostValue(tuple.Item2.workerId.ToString(), tuple.Item2.IPAddresses[i].ToString(), h.OpenPorts[k].ToString(), false, true));
                //    Data.Add(new HostValue(tuple.Item2.workerId.ToString(), tuple.Item2.IPAddresses[i].ToString(), h.OpenPorts[k].ToString(), false, true));
                //    if (DatabaseUpdated != null)
                //        DatabaseUpdated(Data);

                //}

            }

            e.Result = data;//return temp


        }

        private void DataAccess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            if (e.Cancelled)
            {

            }
            else
            {
               var d  =(ObservableCollection<HostValue>) e.Result;
                int git = 0;
                foreach (var item in d)
                {
                    git++;
                    if (!Data.Contains(item))
                    {
                       
                    }
                }       
            }
        }

     

        public delegate void UpdateHandler(ObservableCollection<HostValue> list);
        public UpdateHandler DatabaseUpdated;
    }
}
