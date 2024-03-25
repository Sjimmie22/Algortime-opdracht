using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeClasslibrary
{
    public class Stoel
    {
        public int number { get; set; }

        public string name { get; set; }

        public bool assigned { get; set; }

        public string sitter { get; set; }

        public int rij { get; set; }

        public Stoel(int number, bool assigned, string name, string sitter, int rij)
        {
            this.number = number;
            this.assigned = assigned;
            this.name = name;
            this.sitter = sitter;
            this.rij = rij;
        }

        public void assignchair(Stoel Chair, Bezoeker Currentbezoeker)
        {
            Chair.assigned = true;
            Chair.sitter = Currentbezoeker.Name;
            Currentbezoeker.AssignedStoel = Chair;
        }
    }
}
