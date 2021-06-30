using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Room
    {
        public int Number { get; }

        public Tuple<DateTime, int>[] period;
        
        public Room(int number)
        {
            Number = number;
            FreeDays = new List<DateTime>();
            for (int i = 0; i < 62; i++)
                FreeDays.Add(DateTime.Now.AddDays(i).Date);
            OcupDays = new List<DateTime>();
        }

        public List<DateTime> FreeDays { get; private set; }
        public List<DateTime> OcupDays { get; private set; }

        public void TakeClient(Customer contract)
        {
            for (var i = 0; i < contract.DaysCount; i++)
            {
                if (FreeDays.Contains(contract.CheckInDate.AddDays(i).Date))
                    FreeDays.Remove(contract.CheckInDate.AddDays(i).Date);
                OcupDays.Add(contract.CheckInDate.AddDays(i));
            }
        }

        public Tuple<bool,DateTime,int> CanTakeClient(Customer contract)
        {
            for (int i = 0; i < 3; i++)
            {
                var j = 0;
                for (j = 0; j < contract.DaysCount; j++)
                {
                    if (!FreeDays.Contains(contract.CheckInDate.Date.AddDays(i).AddDays(j)))
                        break;
                }
                if (j == contract.DaysCount)
                {
                    var k = 0;
                    while(FreeDays.Contains(contract.CheckInDate.Date.AddDays(i).AddDays(k)))
                    {
                        k++;
                    }
                    return Tuple.Create(true, contract.CheckInDate.Date.AddDays(i),k--);
                }
            }
            return Tuple.Create(false,DateTime.Now.Date,-1);
        }

        public abstract int Price { get; }
    }
}
