﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    internal class Host: HostingUnit,IEnumerator
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
            while (counter <numOfPlaces )
            {
                for (int i = 0; i < 12;  i++)
                    for(int j=0;j<31;j++)
                        enumerator.Current.Diary[i,j]=false;
                enumerator.MoveNext();
            }
            

        }

        public override string ToString()
        {
            return base.ToString();
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            return 2;
        }
        public int GetHostAnnualBusyDays()
        {
            return 2;
        }
        public int SortUnits()
        {
            return 2;
        }
        public bool AssignRequests(params GuestRequest[] requests)
        {
            return true;
        }

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
