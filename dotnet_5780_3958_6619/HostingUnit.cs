using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    class HostingUnit
    {
       static int stSerialKey;
        public int HostiningUnitKey;
        public bool[,] Diary = new bool[12, 31];
        public virtual string ToString();
        public bool ApproveRequest(GuestRequest guestReq);
        public int GetAnnualBusyDays();
        public float GetAnnualBusyPercentege();
       // int IComparable.compareTo(object obj);

    }
}
