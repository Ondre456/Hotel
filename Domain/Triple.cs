using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Triple : Room
    {
        public Triple(int number) : base(number)
        { }
        public override int Price => 4500;
    }
}
