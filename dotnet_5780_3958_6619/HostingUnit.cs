using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_5780_3958_6619
{
    public class HostingUnit : IComparable
    {
        public static int stSerialKey=10000000;
        public int indexer = 0;
        public bool[,] Diary = new bool[12, 31];
        public override string ToString()
        {
            return " ";
        }
        public bool ApproveRequest(GuestRequest guestReq)
        {

             //on passe sur la matrice AH NON PAS BESOIN
            // si ya une suite de jour qui correspond au jour de la demande 
            // alors ecrit dans la matrice que cest true 
            // et ecrit dans la demande que isApproved egal a true
            // et erenvoie true
            //si pa tt la demande est executee renvoie false 
            //un guest request est compose de lengthOfStay , EntryDate , ReleaseDate , IsApproved
        
                    if( (Diary[guestReq.EntryDate.Month, guestReq.EntryDate.Day] == true) || (Diary[guestReq.ReleaseDate.Month, guestReq.ReleaseDate.Day] == true))
                    {
                            return false;
                    }

                    for (int k = 0; k < lengthOfStay-1; k++) //Verifie pr tt les jours du milieu du sejour
                    {
                            int month;
                            month = Convert.ToInt32((guestReq.EntryDate.Month));
                        if (guestReq.EntryDate.Day == 31)
                        { month++; }
                        DateTime added = (guestReq.EntryDate.AddDays(1));

                        if (Diary[month, k] == true)
                            return false;
                    }

                        for (int b = EntryDate.Day; b < (EntryDate.Day + lengthOfStay-1); b++)
                         {
                            int month;
                                month = Convert.ToInt32((guestReq.EntryDate.Month));
                                if (b == 31)
                                        month++;

                            Diary[b,month] = true;
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
            return this.GetAnnualBusyDays().CompareTo(obj);
        }
        public HostingUnit()
        {
            stSerialKey++;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    Diary[i,j] = false;
        }


        public int HostingUnitKey
        {
            private set => stSerialKey++;
            get => stSerialKey; 
        }
    }
}





