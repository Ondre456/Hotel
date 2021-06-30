using System;

namespace Domain
{
    public class Customer
    {
        public Customer(Type recueredNumber, DateTime checkInDate, int daysCount) 
        {
            CheckInDate = checkInDate;
            DaysCount = daysCount;
            if (recueredNumber.BaseType == typeof(Room))
                RequiredRoom = recueredNumber;
            else throw new ArgumentException();
        }

        public bool IsAdopted { get; set; }
        public Type RequiredRoom { get; }
        public DateTime CheckInDate { get; set; }
        public int DaysCount { get; }
    }
}
