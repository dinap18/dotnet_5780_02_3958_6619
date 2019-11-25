﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    public class HostingUnit : IComparable
    {
        public static int stSerialKey=10000000;
        // public int indexer = 0;
        int help = 0;
        public bool[,] Diary = new bool[12, 31];
        public override string ToString()
        {
            string output = "Unit Number: " + this.HostingUnitKey + " @";
            int helpI = 0, helpJ = 0;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                {
                    help = j + 1;
                    helpI = i;
                    helpJ = j;
                    if (j != 0 && Diary[i, j] == true && Diary[i, --helpJ] == false)//prints the first date in the block if taken dates

                    {
                        
                        output+= i+1 + "/" + help + " / 2019   ";


                    }
                    helpJ = j;
                    if (i != 0 && j == 0 && Diary[i, j] == true && Diary[--helpI, 30] == false)//prints the first date in the block if taken dates if j=0

                    {
                        output += i + 1 + "/" + help + " / 2019   ";


                    }
                    if (i == 0 && j == 0 && Diary[i, j] == true)//if january first is reserved there is no previous date to check
                    {
                        output += i + 1 + "/" + help + " / 2019   ";

                    }

                    helpI = i;
                    //printing the final date in the block of dates
                    if (Diary[i, j] == true && j != 30 && Diary[i, ++helpJ] == false)
                    {
                        output += i + 1 + "/" + help + " / 2019   @";

                    }
                    else

                        if (Diary[i, j] == true && j == 30 && Diary[++helpI, 0] == false)
                    {
                        output += i + 1 + "/" + help + " / 2019   @";
                        helpI = i;
                    }
                    else
                        if (Diary[i, j] == true && Diary[i, helpJ] == false)
                        output += i + 1 + "/" + help + " / 2019   @";
                    else
                        if (Diary[i, j] == true && i == 11 && j == 30)
                        output += i + 1 + "/" + help + " / 2019   @";

                }
            output = output.Replace("@", Environment.NewLine);
            return output;
        }
        public bool ApproveRequest(GuestRequest guestReq)
        {
            if ((Diary[guestReq.EntryDate.Month-1, guestReq.EntryDate.Day-1] == true) || (Diary[guestReq.ReleaseDate.Month-1, guestReq.ReleaseDate.Day-1] == true))
            {
                return false;
            }

            for (int k = 0; k < guestReq.lengthOfStay - 1; k++) //Verifie pr tt les jours du milieu du sejour
            {
                int month;
                int day = k;
                month = Convert.ToInt32((guestReq.EntryDate.Month));
                if (guestReq.EntryDate.Month!=12 && guestReq.EntryDate.Day == 31)
                {
                    month++;
                    day = 0;
                }
                DateTime added = (guestReq.EntryDate.AddDays(1));

                if (Diary[month-1, day] == true)
                    return false;
            }

            for (int b = guestReq.EntryDate.Day; b < (guestReq.EntryDate.Day + guestReq.lengthOfStay - 1); b++)
            {
                int month;
                int day=b;
                month = Convert.ToInt32((guestReq.EntryDate.Month));
                if (b == 31)
                {
                    month++;
                    day = 0;
                }
                else
                    day -= 1;
                Diary[month-1, day ] = true;
            }
            guestReq.IsApproved = true;

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
            HostingUnit help = (HostingUnit)obj;
            return Convert.ToInt32(this.GetAnnualBusyDays().CompareTo(help.GetAnnualBusyDays()));
        }
        public HostingUnit()
        {
            stSerialKey++;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    Diary[i,j] = false;
        }


        public  int HostingUnitKey
        {
            private set { stSerialKey++; }
            get { return stSerialKey; }
        }
    }
}