using System;

namespace Play
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void Fields()
        {
            var person = new Person();
            person.SetBirthDate(new DateTime(1995, 3, 30));
            Console.WriteLine(person.GetBirthDate());

            var newperson = new BetterPerson(new DateTime(1995, 3, 30));
            // newperson.BirthDate = new DateTime(1995, 3, 30); this won't work since setter is private, when creating a new instance of a person you to set birthday and cannot change it again
            Console.WriteLine("Better Person is {1} year old", newperson.Age);
        }

        static void Methods()
        {
            var calc = new Calculator();
            Console.WriteLine(calc.Add(12, 13, 24));
            Console.WriteLine(calc.Add(new int[] { 12, 13, 24 }));
        }

        static void MethodsnClasses()
        {
            var person = new Person
            {
                Name = "Alan",
            };
            person.Introduce("Alan");

            var customer = new Customer();
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);

            var order = new Order();
            customer.Orders.Add(order);

            try
            {
                var point = new Point(10, 20);
                point.Move(new Point(40, 60));
                Console.WriteLine("Point is at ({0},{1})", point.X, point.Y);

                point.Move(100, 200);
                Console.WriteLine("Point is at ({0},{1})", point.X, point.Y);
            }
            catch
            {
                Console.WriteLine("An unexpected error occured");
            }

        }
    }
}
