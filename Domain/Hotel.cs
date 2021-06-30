using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Hotel
    {
        public Hotel(IEnumerable<Room> rooms)
        {
            this.rooms = rooms.ToList();
        }

        private readonly List<Room> rooms;

        public void TakeClients(Customer[] contracts)
        {
            contracts = contracts.OrderBy(x => x.CheckInDate).ToArray();
            
            foreach (var contract in contracts)
            {
                var list = rooms
                    .Where(x => x.GetType() == contract.RequiredRoom)
                    .Where(x => x.CanTakeClient(contract).Item1)
                    .Select(x => Tuple.Create(x, x.CanTakeClient(contract).Item2,x.CanTakeClient(contract).Item3))
                    .OrderBy(x => x.Item3)
                    .ToList();
                contract.CheckInDate = list[0].Item2;
                if (list.Count != 0)
                    list[0].Item1.TakeClient(contract);
            }
        }
    }
}
