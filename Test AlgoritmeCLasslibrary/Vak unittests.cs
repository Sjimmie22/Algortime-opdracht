using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AlgoritmeClasslibrary;

namespace Test_AlgoritmeCLasslibrary
{
    [TestClass]
    public class Vak_unittests
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            //arrange
            string name = "1";
            
            //act
            Vak vak = new Vak(name);

            // assert
            Assert.IsNotNull(vak, "Rij zou niet null moeten zijn.");

            Assert.AreEqual(name, vak.Name, "Namen komen niet overheen");
        }

        [TestMethod]
        public void generaterijen() 
        {
            //arrange 
            string vakname = "1";
            Vak newvak = new Vak(vakname);

            //act
            newvak.rijen = newvak.GenerateRijen(vakname);

            //arrange
            foreach (Rij rij in newvak.rijen)
            {
                Assert.IsTrue(rij.Rijnumber != null, "maken is fout gegaan");
            }
        }

        [TestMethod]
        public void firstseatsetter()
        {
            // Arrange
            Bezoeker firstbezoeker = new Bezoeker("1-0", 1);
            firstbezoeker.Child = true;

            Bezoeker secondbezoeker = new Bezoeker("1-1", 2);
            Bezoeker thirdbezoeker = new Bezoeker("1-2", 3);

            List<Bezoeker> bezoekers = new List<Bezoeker>() 
            { 
                firstbezoeker, secondbezoeker, thirdbezoeker
            };

            Groep groep = new Groep();
            groep.Groepbezoekers = bezoekers;

            Stoel firststoel = new Stoel(1 , false, "A1-1", null, 1);
            Stoel secondstoel = new Stoel(2, false, "A1-2", null, 1);
            Stoel thirdstoel = new Stoel(3, false, "A1-3", null, 1);

            List<Stoel> stoelen = new List<Stoel>() 
            { 
                firststoel, secondstoel, thirdstoel
            };

            Rij rij = new Rij(1);
            rij.Stoelen = stoelen;

            List<Rij> rijen = new List<Rij>() 
            {
                rij 
            };

            Vak vak = new Vak("1");
            vak.rijen = rijen;

            bool assigned;

            // Act
            assigned = vak.seatsetter(true, groep, vak);

            // Assert
            Assert.IsTrue(assigned);
        }
    }
}
