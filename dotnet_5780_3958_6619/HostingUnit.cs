using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    class HostingUnit : GuestRequest, IComparable 
    {
       public static int stSerialKey=10000000;
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
        public float GetAnnualBusyPercentage()
        {
            float counter = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] == true)
                        counter++;
                }
            }
            return (float)(counter / 3.75);
        }

        int IComparable.CompareTo(object obj)
        {
            return this.GetAnnualBusyDays().CompareTo(obj);
        }



     static int HostingUnitKey
        {
            private set => stSerialKey++;
            get => stSerialKey;
        }
       
    }
}





