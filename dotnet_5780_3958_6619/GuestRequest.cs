using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dotnet_5780_3958_6619
{
    class GuestRequest
    {
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsApproved { get; set; }
        public override string ToString()
        {
            return "entry date: {0},  release date: {1},  is approved:  {EntryDate,ReleaseDate,isApproved }";
        }
    }


}