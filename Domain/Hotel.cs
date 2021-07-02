using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public static class Hotel
    {
        static Hotel()
        {
            int i;
            Rooms = new List<Room>();
            for (i = 1; i <= 30; i++)
                Rooms.Add(new Domain.Single(i));
            for (i = 30; i <= 50; i++)
                Rooms.Add(new Domain.Double(i));
            for (i = 50; i <= 60; i++)
                Rooms.Add(new Triple(i));
            for (i = 60; i <= 65; i++)
                Rooms.Add(new Vip(i));
        }

        public static readonly List<Room> Rooms;

        public static void TakeClients(params Customer[] contracts)
        {
            contracts = contracts.OrderBy(x => x.CheckInDate).ToArray();
            
            foreach (var contract in contracts)
            {
                var list = Rooms
                    .Where(x => x.GetType() == contract.RequiredRoom)
                    .Where(x => x.CanTakeClient(contract).Item1)
                    .Select(x => Tuple.Create(x, x.CanTakeClient(contract).Item2,x.CanTakeClient(contract).Item3))
                    .OrderBy(x => x.Item3)
                    .ToList();
                if (list.Count > 0)
                {
                    contract.CheckInDate = list[0].Item2;
                    if (list.Count != 0)
                        list[0].Item1.TakeClient(contract);
                }
            }
        }
    }
}
