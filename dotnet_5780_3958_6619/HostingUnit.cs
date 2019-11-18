using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    class HostingUnit: IComparable
    {
        //static byte[]stSerialKey = Guid.NewGuid().ToByteArray();
        //  readonly public int HostiningUnitKey;
        public bool[,] Diary = new bool[12, 31];
        public override string ToString()
        {
            return base.ToString();
        }
        public bool ApproveRequest(GuestRequest guestReq)
        {

            return true;
        }
        public int GetAnnualBusyDays()
        {
            int counter = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] == true)
                        counter++;

                }
            }
            return counter;
        }
        public double  GetAnnualBusyPercentege()
        {
            int counter = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] == true)
                        counter++;

                }
            }
            return (counter / 3.75);
        }
       int IComparable.CompareTo(object obj)
        {
            return GetAnnualBusyDays().CompareTo(obj);
        }

        int HostingUnitKey;
        public int []host;
    }
}
