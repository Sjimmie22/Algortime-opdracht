using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeClasslibrary
{
    public class Rij
    {
        public int Rijnumber { get; set; }

        public List<Stoel> Stoelen { get; set; }

        public Rij() 
        { 
        
        }

        public Rij(int rijnumber)
        {
            Rijnumber= rijnumber;
        }

        //generate
        public List<Stoel> GenerateStoelen(int Stoelrandomnumber, string stoelname, int rijnumber)
        {
            int namenumber = 1;
            bool assigned = false;
            string resetstoelname = stoelname;

            List<Stoel> StoelList = new List<Stoel>();

            for (int i = 0; i < Stoelrandomnumber; i++)
            {
                stoelname = stoelname + "-" + namenumber;

                Stoel stoel = new Stoel(namenumber, assigned, stoelname, null, rijnumber);

                namenumber++;

                StoelList.Add(stoel);

                stoelname = resetstoelname;
            }
            return StoelList;
        }

        public bool ChildAssignchairs(Groep Currentgroep, List<Rij> Assignrijen)
        {
            Groep Childs = new Groep();
            Childs.Groepbezoekers = Currentgroep.Groepbezoekers.Where(b => b.Child == true).ToList();

            Groep Adults = new Groep();
            Adults.Groepbezoekers = Currentgroep.Groepbezoekers.Where(b => b.Child == false).ToList();

            if (Assignrijen[0].Stoelen.Count(s => s.assigned == false) >= Currentgroep.Groepbezoekers.Count)
            {
                int Currentbezoekerteller = 0;

                foreach (Stoel stoel in Assignrijen[0].Stoelen.Where(s => !s.assigned))
                {
                    stoel.assignchair(stoel, Currentgroep.Groepbezoekers[Currentbezoekerteller]);
                    Currentbezoekerteller++;

                    if (Currentbezoekerteller == Currentgroep.Groepbezoekers.Count)
                    {
                        break;
                    }
                }
                return true;
            }
            else if (Assignrijen.Count > 1 && Assignrijen[0].Stoelen.Count(s => s.assigned == false) >= Currentgroep.Groepbezoekers.Count(b => b.Child == true) +1 && Assignrijen[1].Stoelen.Count(s => s.assigned == false) >= Currentgroep.Groepbezoekers.Count(b => b.Child == false) - 1)
            {
                int ChildCurrentbezoekerteller = 0;
                int AdultCurrentbezoekerteller = 0;

                foreach (Stoel stoel in Assignrijen[0].Stoelen.Where(s => s.assigned == false))
                {
                    stoel.assignchair(stoel, Childs.Groepbezoekers[ChildCurrentbezoekerteller]);
                    ChildCurrentbezoekerteller++;

                    if(ChildCurrentbezoekerteller == Childs.Groepbezoekers.Count)
                    {
                        Stoel nextAvailableChair = Assignrijen[0].Stoelen.FirstOrDefault(s => !s.assigned);

                        stoel.assignchair(nextAvailableChair, Adults.Groepbezoekers[AdultCurrentbezoekerteller]);
                        AdultCurrentbezoekerteller++;
                        break;
                    }
                }

                if (Adults.Groepbezoekers.Count > 1)
                {
                    foreach (Stoel stoel in Assignrijen[1].Stoelen.Where(s => s.assigned == false))
                    {
                        stoel.assignchair(stoel, Adults.Groepbezoekers[AdultCurrentbezoekerteller]);
                        AdultCurrentbezoekerteller++;

                        if (AdultCurrentbezoekerteller == Adults.Groepbezoekers.Count)
                        {
                            break;
                        }
                    }
                }
                return true;
            }

            return false;
        }

        public bool AdultAssignchairs(Groep Currentgroep, Rij CurrentRij)
        {
            if (CurrentRij.Stoelen.Count(s => s.assigned == false) >= Currentgroep.Groepbezoekers.Count)
            {
                int Currentbezoekerteller = 0;

                foreach (Stoel stoel in CurrentRij.Stoelen.Where(s => s.assigned == false))
                {
                    stoel.assignchair(stoel, Currentgroep.Groepbezoekers[Currentbezoekerteller]);
                    Currentbezoekerteller++;

                    if (Currentbezoekerteller == Currentgroep.Groepbezoekers.Count)
                    {
                        break;
                    }
                }
                return true;
            }

            return false;
        }
    }
}
