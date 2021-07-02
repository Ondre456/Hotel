using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersGenerator
{
    public class CustomerGenerator
    {
        public Customer[] Generate()
        {
            var Customers = new List<Customer>();
            var rnd = new Random();
            for (int i = 0; i < rnd.Next(100,200); i++)
            {
                Customers.Add(new Customer(typeof(Domain.Single), DateTime.Now.Date.AddDays(rnd.Next(0,30)), rnd.Next(20)));
            }
            for (int i = 0; i < rnd.Next(100, 200); i++)
            {
                Customers.Add(new Customer(typeof(Domain.Double), DateTime.Now.Date.AddDays(rnd.Next(0,30)), rnd.Next(20)));
            }
            for (int i = 0; i < rnd.Next(50, 100); i++)
            {
                Customers.Add(new Customer(typeof(Triple), DateTime.Now.Date.AddDays(rnd.Next(0,30)), rnd.Next(20)));
            }
            for (int i = 0; i < rnd.Next(25, 50); i++)
            {
                Customers.Add(new Customer(typeof(Vip), DateTime.Now.Date.AddDays(rnd.Next(0,30)), rnd.Next(20)));
            }
            return Customers.ToArray();
        }
    }
}
