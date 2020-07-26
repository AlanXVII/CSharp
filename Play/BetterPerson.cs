using System;
using System.Collections.Generic;
using System.Text;

namespace Play
{
    class BetterPerson
    {
        // auto implemented properties
        public DateTime BirthDate { get; private set; } //auto implemented property with private set acesser (read-only) 
        public string Name { get; set; }
        public string UserName { get; set; }

        //contructors
        public BetterPerson(DateTime birthDate)
        {
            BirthDate = birthDate;
        }
        
        //calculated properties
        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - BirthDate;
                var years = timeSpan.Days / 365;

                return years;
            }
        }
    }
}
