using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    public class HostingUnit : IComparable
    {
        private static int stSerialKey = 10000000;
        public bool[,] Diary = new bool[12, 31];
        public int HostingUnitKey;

        public override string ToString() //converts a hosting unit into string form so it can be printed
        {
            int help = 0;
            string output = "Unit Number: " + HostingUnitKey + " @";
            int helpI = 0, helpJ = 0;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                {

                    help = j + 1;
                    helpI = i;
                    helpJ = j;
                    if (j != 0 && Diary[i, j] == true && Diary[i, --helpJ] == false)//prints the first date in the block if taken dates

                    {

                        output += i + 1 + "/" + help + "/2020  - ";


                    }
                    helpJ = j;
                    if (i != 0 && j == 0 && Diary[i, j] == true && Diary[--helpI, 30] == false)//prints the first date in the block if taken dates if j=0

                    {
                        output += i + 1 + "/" + help + "/2020  - ";


                    }
                    if (i == 0 && j == 0 && Diary[i, j] == true)//if january first is reserved there is no previous date to check
                    {
                        output += i + 1 + "/" + help + "/2020   - ";

                    }

                    helpI = i;
                    //printing the final date in the block of dates
                    if (Diary[i, j] == true && j != 30 && Diary[i, ++helpJ] == false)
                    {
                        output += i + 1 + "/" + help + "/2020   @";

                    }
                    else

                      if (Diary[i, j] == true && i != 11 && j == 30 && Diary[++helpI, 0] == false)
                    {
                        output += i + 1 + "/" + help + "/2020   @";
                        helpI = i;
                    }
                    else
                        if (Diary[i, j] == true && Diary[i, helpJ] == false)
                        output += i + 1 + "/" + help + " / 2020   @";
                    else
                        if (Diary[i, j] == true && i == 11 && j == 30)
                        output += i + 1 + "/" + help + "/2020  @";

                }
            output += "@";
            output = output.Replace("@", Environment.NewLine); // adds a new line to the output string
            return output;
        }
        public bool ApproveRequest(GuestRequest guestReq) // checks the matrix and if able to, approves a vacation request
        {
            int helper = 0;
            int timeOfStay=(guestReq.lengthOfStay-1); // minus one because we are reserving the amount of nights stayed and not the amount of days
            for (int i = guestReq.EntryDate.Month-1; i < 12; i++)// checks if the dates are taken
                for (int j = 0; j < 31; j++)
                {
                    if (helper < timeOfStay)
                    {
                        if ((j >= (guestReq.EntryDate.Day -1 ) ) || (helper > 0 && helper < timeOfStay))
                        {
                            if (helper < timeOfStay )
                            {
                                if (this.Diary[i, j] == true)

                                {

                                    guestReq.IsApproved = false;
                                    return false;
                                }
                            }
                        }



                    }
                }
            helper = 0;
            for (int i = guestReq.EntryDate.Month -1; i < 12; i++)//switches the dates to true
                for (int j = 0; j < 31; j++)
                {
                    if (helper == (timeOfStay ))

                    {
                        guestReq.IsApproved = true;

                        return true;
                    }
                    else
                    if ((j >= (guestReq.EntryDate.Day - 1 ) )|| (helper > 0 && helper <= timeOfStay ))
                    {
                      
                            this.Diary[i, j] = true;
                            helper++;
                        
                    }

                }


            return true;

        }
        public int GetAnnualBusyDays() // returns the amount of days taken
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
        public float GetAnnualBusyPercentage() //returns percent of year that is taken
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

        int IComparable.CompareTo(object obj) // function to determine how to sort hosting units
        {
            HostingUnit help = obj as HostingUnit;
            return Convert.ToInt32(this.GetAnnualBusyDays().CompareTo(help.GetAnnualBusyDays()));
        }
        public HostingUnit() // constructor
        {
           HostingUnitKey= stSerialKey++;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    Diary[i, j] = false;
        }


       
    }
}