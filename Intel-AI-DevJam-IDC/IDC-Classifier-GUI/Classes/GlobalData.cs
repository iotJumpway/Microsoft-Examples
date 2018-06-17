using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC_Classifier_GUI
{
    class GlobalData
    {
        public string protocol = "http://";
        public string ip = "192.168.1.50";
        public int port = 8080;
        public string endpoint = "/api/TASS/infer";
        public string endpointIDC = "/api/IDC/infer";
        //public string dataFolder = "Data\\1";
        public string dataFolder = "Data\\2";

        public double threshold = 0.80;
        public int expectedCount = 50;
    }
}