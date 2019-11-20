using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    internal class Host : HostingUnit, IEnumerator
    {
        public int HostKey { get; set; }

        public object Current => throw new NotImplementedException();

        public List<HostingUnit> HostingUnitCollection;

        public Host(int id, int numOfPlaces)
        {
            HostKey = id;
            IEnumerable<HostingUnit> e = HostingUnitCollection;

            IEnumerator<HostingUnit> enumerator = e.GetEnumerator();
            int counter = 0;
            while (counter < numOfPlaces)
            {
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 31; j++)
                        enumerator.Current.Diary[i, j] = false;
                enumerator.MoveNext();
            }


        }

        public override string ToString()
        {
            return base.ToString();
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            if (ApproveRequest(guestReq))
                return HostingUnitKey;
            else
                return -1;
        }
        public int GetHostAnnualBusyDays()
        {
            IEnumerable<HostingUnit> e = HostingUnitCollection;

            IEnumerator<HostingUnit> enumerator = e.GetEnumerator();
            int counter = 0;
           

                foreach (var hostingunit in HostingUnitCollection)
                {
                   counter+= GetAnnualBusyDays();
                }
            
            return counter;
        }
        public void SortUnits()
        {
            HostingUnitCollection.Sort();

        }
        public bool AssignRequests(params GuestRequest[] requests)
        {
            for (int i = 0; i < requests.Length; i++)
            {
                if (SubmitRequest(requests[i]) == -1)
                    return false;
                else
                    return true;

            }



            return true;
        }

        public HostingUnit this[int serialKey]
        {
                      

        set
            {
                if (serialKey==stSerialKey)
                {
                    return HostingUnitCollection[SerialKey];

                }
            }
            get
            {       }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        public int IEnumerator(object obj)
        {
            return 2;
        }
    }
}