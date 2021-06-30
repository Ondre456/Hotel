using System;
using System.Collections.Generic;
using Domain;

namespace App
{
    public class Program
    {
        public static Hotel Main()
        {
            int i;
            var rooms = new List<Room>();
            for (i = 0; i < 30; i++)
                rooms.Add(new Domain.Single(i));
            for (i = 30; i < 50; i++)
                rooms.Add(new Domain.Double(i));
            for (i = 50; i < 60; i++)
                rooms.Add(new Triple(i));
            for (i = 60; i < 65; i++)
                rooms.Add(new Vip(i));
            return new Hotel(rooms);
        }
    }
}
