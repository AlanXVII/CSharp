using System;
using System.Collections.Generic;
using System.Text;

namespace Play
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Order> Orders; //list object of type Orders

        public Customer()
        {
            Orders = new List<Order>();
        }

        public Customer(int id)
            : this()
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
