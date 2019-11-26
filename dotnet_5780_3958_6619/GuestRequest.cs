using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dotnet_5780_3958_6619
{
    public class GuestRequest
    {
        
        public int lengthOfStay;
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public bool IsApproved;
        public override string ToString() // switches request to string form for printing
        {
            return "entry date:" + this.EntryDate + "  release date:" + this.ReleaseDate + "is approved: " + this.IsApproved;
        }
        public GuestRequest() // constructor
        {
            this.IsApproved = false;
        }
        public GuestRequest(DateTime arrival, int length)
        {
            EntryDate = arrival;
            lengthOfStay = length;
            ReleaseDate = EntryDate.AddDays(lengthOfStay);// real date form - there isnt 31 days in each month
        }
    }


}