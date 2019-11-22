using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dotnet_5780_3958_6619
{
    public class GuestRequest
    {
        int day, month, year;
        public int lengthOfStay;
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public bool IsApproved;
        public override string ToString()
        {
            return "entry date: {0},  release date: {1},  is approved:  {this.EntryDate,this.ReleaseDate,this.isApproved }";
        }
        public GuestRequest()
        {
            this.IsApproved = false;
        }
        public GuestRequest(ref DateTime arrival,int length)
        {
            EntryDate = arrival ;
            year = arrival.Year;
            day = arrival.Day;
            month = arrival.Month;
            lengthOfStay = length;
            if (length + day > 31)
            {
                day = day + length - 31;
                month++;
            }
            else
                day = day + length;
            ReleaseDate = new DateTime(year, month, day);
        }
    }


}
