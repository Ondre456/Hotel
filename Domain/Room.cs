using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Room
    {
        public int Number { get; }

        public Room(int number)
        {
            Number = number;
        }

        public bool HaveClient { get; private set; }

        public DateTime dateVacating;

        public void TakeKlient(DateTime date)
        {
            HaveClient = true;
            dateVacating = date;
        }
        public abstract int Price { get; }
    }
}
