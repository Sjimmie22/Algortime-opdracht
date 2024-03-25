using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeClasslibrary
{
    public class Bezoeker
    {
        public DateTime Birthday { get; set; }

        public bool Child { get; set; }

        public string Name { get; set; }

        public Stoel AssignedStoel { get; set; }

        public int uniquenumber { get; set; }

        public Bezoeker(string name, int uniquenumber)
        {
            this.Name = name;
            this.uniquenumber = uniquenumber;

            Random random = new();

            DateTime minDate = DateTime.Now.AddYears(-60);
            DateTime maxDate = DateTime.Now.AddYears(-1);
            int days = (maxDate - minDate).Days;

            Birthday = minDate.AddDays(random.Next(days));

            Child = Birthday > DateTime.Now.AddYears(-12);
        }

        public string GetFormattedBirthdate()
        {
            return Birthday.ToString("dd-MM-yyyy");
        }
    }
}
