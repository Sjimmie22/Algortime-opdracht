using AlgoritmeClasslibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeClasslibrary
{
    public class Evenement
    {
        public List<Groep> Groups = new List<Groep>();
        
        public List<Vak> Vakken = new List<Vak>();   

        public List<Groep> NotAddedGroups = new List<Groep>();

        public int maximumvakken = 5;

        public Evenement() 
        { 
        
        }

        //generate of maak methodes
        public List<Groep> Generategroups()
        {
            int uniquebezoekernummer = 0;

            Groep Assignergroep = new Groep();
            Random random = new Random();

            List<Groep> Groups = new List<Groep>();

            int Grouprandomnumber = random.Next(10, 20);

            int Assigngroupnumber = 1;

            for (int i = 0; i < Grouprandomnumber; i++)
            {
                Groep Newgroep = Assignergroep.Makegroup(Assigngroupnumber, uniquebezoekernummer);
                uniquebezoekernummer = Newgroep.Groepbezoekers.Last().uniquenumber;

                Assigngroupnumber++;

                Groups.Add(Newgroep);
            }

            return Groups;
        }
        
        private string GetVakName(int index)
        {
            int base26 = 26;
            int letterCount = 1;

            while (index >= base26)
            {
                index -= base26;
                base26 *= 26;
                letterCount++;
            }

            string vakName = string.Empty;
            for (int i = 0; i < letterCount; i++)
            {
                vakName = (char)('A' + (index % 26)) + vakName;
                index /= 26;
            }

            return vakName;
        }

        public void Makevak()
        {
            string name = GetVakName(Vakken.Count);
            Vak newvak = new Vak(name);
            newvak.rijen = newvak.GenerateRijen(name);
            Vakken.Add(newvak);
        }
        // tot hier

        public void organise(List<Groep> groups)
        {
            //bij unittesten checken of iedereen een stoel heeft behalve degene in de notaddedgroupslijst
            Makevak();

            foreach (Groep groep in groups)
            {
                bool Childingroup = groep.Childingroup(groep);
                bool assigned = false;

                int vakcounter = 0;
                bool canrestart = true;

                while (canrestart)
                {
                    foreach (Vak vak in Vakken)
                    {
                        assigned = vak.seatsetter(Childingroup, groep, vak);

                        if (assigned)
                        {
                            canrestart = false;
                            break;
                        }
                        vakcounter++;
                    }

                    if (vakcounter < maximumvakken && !assigned)
                    {
                        Makevak();
                    }
                    else if (vakcounter >= maximumvakken)
                    {
                        canrestart = false;
                    }
                }

                if (!assigned)
                {
                    NotAddedGroups.Add(groep);
                }
                
            }
        }

    }
}



