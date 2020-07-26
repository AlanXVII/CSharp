using System;
using System.Collections.Generic;
using System.Text;

namespace Play
{
    public class Person
    {
        public string Name;
        private DateTime _birthDate;

        public void SetBirthDate(DateTime birthdate)
        {
            _birthDate = birthdate;
        }

        public DateTime GetBirthDate()
        {
            return _birthDate;
        }

        public void Introduce(string to)
        {
            Console.WriteLine("Hi  {0}, I am {1}", to, Name);
        }

        public static Person Parse(string str) // declare a parse method as a class so that we don't have to create a person object before we can call the method
        {
            var person = new Person();
            person.Name = str;

            return person;
        }
    }
}
