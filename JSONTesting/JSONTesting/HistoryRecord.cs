using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONTesting
{
    class HistoryRecord
    {
        private Contact Me;
        public string MyInfo;
        public string Direct;
        private Contact Caller;
        public string CallerInfo;
        public DateTime Date;
        public string Time;
        public string Status;

        public HistoryRecord(string myinf, string dir, string calinf, DateTime dt, string ts, string st)
        {
            this.MyInfo = myinf;
            this.Direct = dir;
            this.CallerInfo = calinf;
            this.Date = dt;
            this.Time = ts;
            this.Status = st;
        }
    }
}
