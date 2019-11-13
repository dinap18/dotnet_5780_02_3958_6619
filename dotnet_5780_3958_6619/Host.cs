using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    class Host
    {
        private int HostKey;
        public List<HostingUnit> HostingUnitCollection;
  
        public Host(int a, int b)
        {

        }

        public virtual string ToString();
        private long SubmitRequest(GuestRequest guestReq) { return 2; }
        public int GetHostAnnualBusyDays() { }
        public int SortUnits() { }
        public bool AssignRequests() { }


        




    }
}
