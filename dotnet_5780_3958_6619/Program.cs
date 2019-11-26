//Dina Pinchuck 337593958 and Eve Bibas 322276619
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{

    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        private static GuestRequest CreateRandomRequest()
        {
            GuestRequest gs = new GuestRequest();
            DateTime beginningOfYear = new System.DateTime(2020, 1, 1);
            DateTime endOfYear = new System.DateTime(2020, 12, 31);
            TimeSpan difference = endOfYear.Date - beginningOfYear.Date;
            int range = (endOfYear - beginningOfYear).Days;
            DateTime today = beginningOfYear.AddDays(rand.Next(range));
            int length = rand.Next(2, 11);
            gs = new GuestRequest(today, length);
            return gs;
        }
        static void Main(string[] args)
        {
            List<Host> lsHosts;
            lsHosts = new List<Host>()
             {
             new Host(1, rand.Next(1,5)),
             new Host(2, rand.Next(1,5)),
             new Host(3, rand.Next(1,5)),
             new Host(4, rand.Next(1,5)),
             new Host(5, rand.Next(1,5))
             };
            for (int i = 0; i < 100; i++)
            {
                foreach (var host in lsHosts)
                {

                    GuestRequest gs1 = CreateRandomRequest();
                    GuestRequest gs2 = CreateRandomRequest();
                    GuestRequest gs3 = CreateRandomRequest();
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                           host.AssignRequests(gs1);
                            break;
                        case 2:
                              host.AssignRequests(gs1, gs2);
                            break;
                        case 3:
                              host.AssignRequests(gs1, gs2, gs3);
                            break;
                        default:
                            break;
                    }
                }
            }
            //Create dictionary for all units <unitkey, occupancy_percentage>
            Dictionary<long, float> dict = new Dictionary<long, float>();
            foreach (var host in lsHosts)
            {
                //test Host IEnuramble is ok
                foreach (HostingUnit unit in host)
                {
                    dict[unit.HostingUnitKey] = unit.GetAnnualBusyPercentage();
                }
            }
            //get max value in dictionary
            float maxVal = dict.Values.Max();
            //get max value key name in dictionary
            long maxKey =
           dict.FirstOrDefault(x => x.Value == dict.Values.Max()).Key;
            //find the Host that its unit has the maximum occupancy percentage
            foreach (var host in lsHosts)
            {
                //test indexer of Host
                for (int i = 0; i < host.HostingUnitCollection.Count; i++)
                {
                    if (host[i].HostingUnitKey == maxKey)
                    {
                        //sort this host by occupancy of its units
                        host.SortUnits();
                        //print this host detailes
                        Console.WriteLine("**** Details of the Host with the most occupied unit:\n");

                        Console.WriteLine(host);
                        break;
                    }
                }

            }
          
            Console.ReadKey();
        }

    }
}
/***** Details of the Host with the most occupied unit:

Unit Number: 10000000
1/12/2020  - 1/14/2020
3/13/2020  - 3/21/2020
3/30/2020  - 4/1/2020
5/15/2020  - 5/22/2020
5/27/2020  - 6/9/2020
7/31/2020  - 8/7/2020
11/27/2020  - 11/30/2020
12/24/2020  - 12/26/2020
12/28/2020  - 12/31/2020

Unit Number: 10000001
3/21/2020  - 3/21/2020
5/2/2020  - 5/3/2020
5/14/2020  - 5/17/2020
6/14/2020  - 6/19/2020
6/24/2020  - 6/24/2020
7/6/2020  - 7/6/2020
7/21/2020  - 7/22/2020
7/26/2020  - 7/29/2020
9/6/2020  - 9/13/2020
9/24/2020  - 9/26/2020
10/18/2020  - 10/25/2020
10/29/2020  - 11/2/2020
11/28/2020  - 12/1/2020
12/4/2020  - 12/8/2020
12/19/2020  - 12/19/2020
12/22/2020  - 12/27/2020

Unit Number: 10000002
1/23/2020  - 1/24/2020
2/26/2020  - 2/28/2020
4/5/2020  - 4/12/2020
5/11/2020  - 5/16/2020
7/17/2020  - 7/22/2020
7/29/2020  - 8/4/2020
8/12/2020  - 8/17/2020
9/8/2020  - 9/10/2020
9/25/2020  - 9/28/2020
10/22/2020  - 10/23/2020
11/1/2020  - 11/6/2020
11/11/2020  - 11/19/2020
11/26/2020  - 12/1/2020
12/7/2020  - 12/10/2020
12/19/2020  - 12/27/2020


*/