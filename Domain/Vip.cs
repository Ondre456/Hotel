using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Vip : Room
    {
        public Vip(int number) : base(number)
        { }
        public override int Price => 5000;
    }
}
