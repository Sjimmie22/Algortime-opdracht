using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeClasslibrary
{
    public class Groep
    {
        public int Groepnumber { get; set; }

        public List<Bezoeker> Groepbezoekers { get; set; }

        public Groep()
        {

        }

        public Groep(int groepnumber)
        {
            Groepnumber = groepnumber;
            Groepbezoekers = new List<Bezoeker>();
        }

        public Groep Makegroup(int Assigngroupnumber, int uniquenumber)
        {
            Random random = new Random();

            Groep Newgroep = new(Assigngroupnumber);

            int Bezoekerrandomnumber = random.Next(1, 4);

            for (int j = 0; j < Bezoekerrandomnumber; j++)
            {
                uniquenumber++;
                string name = Assigngroupnumber.ToString() + "-" + j.ToString();
                Bezoeker Newbezoeker = new(name, uniquenumber);

                Newgroep.Groepbezoekers.Add(Newbezoeker);
            }

            if (Newgroep.Groepbezoekers.All(b => b.Child))
            {
                uniquenumber++;

                DateTime minDate = DateTime.Now.AddYears(-60);
                DateTime maxDate = DateTime.Now.AddYears(-18);
                int days = (maxDate - minDate).Days;

                string name = Assigngroupnumber.ToString() + "-" + Newgroep.Groepbezoekers.Count.ToString();

                Bezoeker Newbezoeker = new(name, uniquenumber)
                {
                    Birthday = minDate.AddDays(random.Next(days)),
                    uniquenumber = uniquenumber
                };

                Newbezoeker.Child = Newbezoeker.Birthday > DateTime.Now.AddYears(-18);

                Newgroep.Groepbezoekers.Add(Newbezoeker);
            }

            return Newgroep;
        }

        public bool Childingroup(Groep groep)
        {
            bool child = false;

            foreach (Bezoeker bezoeker in groep.Groepbezoekers)
            {
                if (bezoeker.Child == true)
                {
                    child = true;
                    break;
                }
                else
                {
                    child = false;
                }
            }

            return child;
        }
    }
}
