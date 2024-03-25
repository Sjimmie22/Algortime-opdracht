using AlgoritmeClasslibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_AlgoritmeCLasslibrary
{
    [TestClass]
    public class Stoel_unittests
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange
            int stoelnumber = 5;
            bool assigned = false;
            string name = "B1-01";
            string sitter = null;

            //act
            Stoel stoel = new Stoel(stoelnumber, assigned, name, null, 1);

            // assert
            Assert.IsNotNull(stoel, "Stoel zou niet null moeten zijn.");

            Assert.AreEqual(stoelnumber, stoel.number, "Nummers matchen niet");
            Assert.AreEqual(assigned, stoel.assigned, "Assigned matchen niet");
            Assert.AreEqual(name, stoel.name, "names matchen niet");
            Assert.AreEqual(sitter, stoel.sitter, "sitters matchen niet");
        }

        [TestMethod]
        public void assignstoel()
        {
            //arrange
            Stoel stoel = new Stoel(4, false, "B1-01", null, 1);
            Bezoeker bezoeker = new Bezoeker("5-0", 75);

            //act
            stoel.assignchair(stoel, bezoeker);

            //assign
            Assert.IsTrue(stoel.assigned == true, "Stoel hoort nu assigned te zijn");
            Assert.AreEqual(bezoeker.Name, stoel.sitter, "Stoel hoort de naam van de sitter te bevatten");
            Assert.AreEqual(stoel, bezoeker.AssignedStoel, "Stoelen komen niet met elkaar overheen");
        }
    }
}
