using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class CheckRow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        // вкратце
        //public string Host { get; set }
        //public StatusChecking ResultPing { get; set }
        //public string Uri { get; set }
        //public StatusChecking ResultGet { get; set }



        public string host;
        public string Host
        {
            get { return host; }
            set
            {
                host = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Host"));
            }
        }

        public StatusChecking resultPing;
        public StatusChecking ResultPing
        {
            get { return resultPing; }
            set
            {
                resultPing = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ResultPing"));
            }
        }
        
        private string uri;
        public string Uri
        {
            get { return uri; }
            set
            {
                uri = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Uri"));
            }
        }

        private StatusChecking resultGet;
        public StatusChecking ResultGet
        {
            get { return resultGet; }
            set
            {
                resultGet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ResultGet"));
            }
        }
    }
}
