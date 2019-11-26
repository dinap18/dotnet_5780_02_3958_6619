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


        public List<HostingUnit> HostingUnitCollection = new List<HostingUnit>();
        public List<HostingUnit> MyList
        {
            private set { HostingUnitCollection = new List<HostingUnit>(); }
            get { return HostingUnitCollection; }
        }

        public Host(int id, int numOfPlaces) //constructor
        {
            HostKey = id;
            for (int i = 0; i < numOfPlaces; i++)
            {
                HostingUnit newUnit = new HostingUnit();
                HostingUnitCollection.Add(newUnit);
            }

        }

        public override string ToString() // converts host to string form so it can be printed
        {

            string output = "";

            for (int i = 0; i < this.HostingUnitCollection.Count; i++)
                output += this.HostingUnitCollection[i].ToString();

            return output;
        }
        private long SubmitRequest(GuestRequest guestReq) // checks if a vacation request can be aprroved
        {
            foreach (var unit in HostingUnitCollection)
                if (unit.ApproveRequest(guestReq)==true)
                    return unit.HostingUnitKey;

            return -1;
        }
        public int GetHostAnnualBusyDays() // returns how many days are taken from all the units a host has
        {
            int counter = 0;
            foreach (var unit in HostingUnitCollection)
            {
                counter += unit.GetAnnualBusyDays();
            }

            return counter;
        }
        public void SortUnits() // sorts units- using compareTo from hosting unit
        {
            HostingUnitCollection.Sort();

        }
        public bool AssignRequests(params GuestRequest[] requests) // sends unknown amount of requests to submit request to be approved
        {
            for (int i = 0; i < requests.Length; i++)
            {
                if (SubmitRequest(requests[i]) == -1)
                    return false;


            }
            return true;
        }

        public HostingUnit this[int key] // indexer
        {


            get { if (this.HostingUnitCollection[key] != null)
                    return this.HostingUnitCollection[key];
                else
                    return null;
                }
           set { this.HostingUnitCollection[key] = value; }
        }

        public IEnumerator GetEnumerator() // enumerator
        {
            for (int i = 0; i < HostingUnitCollection.Count; i++)
                yield return HostingUnitCollection[i];
        }
      
    }
}