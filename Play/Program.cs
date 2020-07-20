using System;

namespace Play
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.Parse("John");
            person.Introduce("Alan");

            var customer = new Customer();
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);
        }
    }
}
