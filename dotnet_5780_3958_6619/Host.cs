using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    public class Host : IEnumerable
    {
        public int HostKey;

        public object Current => throw new NotImplementedException();

        public List<HostingUnit> HostingUnitCollection=new List<HostingUnit>();
        public List<HostingUnit>MyProperty
        {
            private set =>HostingUnitCollection = new List<HostingUnit>();
            get => HostingUnitCollection;
        }

        public Host(int id, int numOfPlaces)
        {
            HostKey = id;
            for (int i = 0; i < numOfPlaces; i++)
            {
                HostingUnit newUnit = new HostingUnit();
                HostingUnitCollection.Add(newUnit);
            }

        }

        public override string ToString()
        {
            string output = "the information for each unit  ";
            foreach (var unit in HostingUnitCollection)
                unit.ToString();
            return output;
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach(var unit in HostingUnitCollection)
                if (unit.ApproveRequest(guestReq))
                    return unit.HostingUnitKey;
            
             return -1;
        }
        public int GetHostAnnualBusyDays()
        {
            int counter = 0;
            foreach (var unit in HostingUnitCollection)
            {
                counter += unit.GetAnnualBusyDays();
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
                

            }
             return true;
        }

        public HostingUnit this[int serialKey]
        {

        
            get { return HostingUnitCollection[serialKey]; }
            set { HostingUnitCollection[serialKey] = value; }
        }
    
        public  IEnumerator GetEnumerator()
        {
            for (int i = 0; i < HostingUnitCollection.Count; i++)
                yield return HostingUnitCollection[i];
        }
    }
}
