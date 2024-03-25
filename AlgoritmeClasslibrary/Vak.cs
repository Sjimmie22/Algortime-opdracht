using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeClasslibrary
{
    public class Vak
    {
        public string Name { get; private set; }

        public List<Rij> rijen { get; set; }

        public Vak(string name)
        {
            Name = name;
        }

        public List<Rij> GenerateRijen(string vakname)
        {
            Random random = new Random();

            int Rijrandomnumber = random.Next(1, 3);
            int Stoelrandomnumber = random.Next(3, 10);
            int namenumber = 1;

            List<Rij> RijList = new List<Rij>();

            string stoelname = vakname + namenumber;

            for (int i = 0; i < Rijrandomnumber; i++)
            {
                Rij rij = new Rij(namenumber);

                rij.Stoelen = rij.GenerateStoelen(Stoelrandomnumber, stoelname, namenumber);

                namenumber++;

                RijList.Add(rij);
            }
            return RijList;
        }

        public bool seatsetter(bool Childingroup, Groep Currentgroep, Vak Currentvak)
        {
            if (Childingroup) 
            {
                Rij assignrij = new Rij();
                
                bool checkchairs = assignrij.ChildAssignchairs(Currentgroep, Currentvak.rijen);

                return checkchairs;
            }
            else
            {
                bool checkchairs = false;

                foreach (Rij rij in Currentvak.rijen)
                {
                    checkchairs = rij.AdultAssignchairs(Currentgroep, rij);

                    if (checkchairs)
                    {
                        break;
                    }
                }

                return checkchairs;
            }
        }








        //not used
        public List<Rij> MaakRij(string vakname, List<Rij> rijen, int bezoekers)
        {
            int namenumber = 0;

            if (rijen == null)
            {
                namenumber = 1;
            }
            else if (rijen.Count == 1)
            {
                namenumber = 2;
            }
            else if (rijen.Count == 2)
            {
                namenumber = 3;
            }

            string stoelname = vakname + namenumber;

            if (rijen == null)
            {
                Rij rij = new Rij(namenumber);

                rij.Stoelen = rij.GenerateStoelen(bezoekers, stoelname, namenumber);

                rijen.Add(rij);
            }
            else
            {
                Rij rij = new Rij(namenumber);

                rij.Stoelen = rij.GenerateStoelen(rijen[0].Stoelen.Count, stoelname, namenumber);

                rijen.Add(rij);
            }

            return rijen;
        }
    }
}
