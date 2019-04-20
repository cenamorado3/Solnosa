using System;

namespace MyWebsite.Models
{
    public class PersonModels
    {
        public PersonModels(string dob)
        {
            BirthDate = calculateAge(dob);
        }

        public int BirthDate { get; set; }


        public int calculateAge(string dob)
        {
            int age;
            age = (DateTime.Now - Convert.ToDateTime(dob)).Days / 365;
            return age;
        }

    }
}