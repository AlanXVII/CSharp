using System;
using System.Collections.Generic;
using System.Text;

namespace Play
{
    public class Customer
    {
        public int Id;
        public string Name;

        public Customer(int id)
        {
            this.Id = id;
        }

        public Customer(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public Customer(string name)
        {
            this.Name = name;
        }

        public Customer()
        {

        }
    }
}
