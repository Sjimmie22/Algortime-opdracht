using AlgoritmeClasslibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_AlgoritmeCLasslibrary
{
    [TestClass]
    public class Rij_unittests
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange & act
            Rij rij = new Rij();

            // assert
            Assert.IsNotNull(rij, "Rij zou niet null moeten zijn.");
        }

        [TestMethod]
        public void Secondconstructortest()
        {
            //arrange
            int rijnummer = 1;

            //act
            Rij rij = new Rij(1);

            //asseert
            Assert.IsNotNull(rij, "Rij zou niet null moeten zijn.");

            Assert.AreEqual(rijnummer, rij.Rijnumber, "rijnummers kloppen niet");
        }

        [TestMethod]
        public void generatestoelen()
        {
            //arrange
            Rij rij = new Rij();
            int stoelnummer = 5;
            string stoelname = "B2";

            //act
            rij.Stoelen = rij.GenerateStoelen(stoelnummer, stoelname, 1);

            //assert
            Assert.IsNotNull(rij.Stoelen, "Er moeten stoelen zijn dus hij hoort niet null te zijn");
            Assert.IsTrue(rij.Stoelen.Count == 5, "Er moeten 5 stoelen nu in de rij zitten");
            Assert.IsTrue(rij.Stoelen.Last().name == "B2-5", "De laatste naam moet de naam van de stoelnaam hebben met een streepje en de de hoeveelheid hoeveelheid stoelen aangezien dat de laatste is die is aangemaakt dus B2-5");
        }

        [TestMethod]
        public void firstcheckchilds()
        {
            //arrange
            bool assigned = false;

            Groep groep = new Groep(1);

            Groep Childs = new Groep();
            Childs.Groepbezoekers = groep.Groepbezoekers.Where(b => b.Child == true).ToList();

            Bezoeker firstbezoeker = new Bezoeker("1.0", 1);
            firstbezoeker.Child = true;
            
            Bezoeker secondbezoeker = new Bezoeker("1.1", 2);
            Bezoeker thirdbezoeker = new Bezoeker("1.2", 3);
            Bezoeker fourthbezoeker = new Bezoeker("1.3", 4);

            groep.Groepbezoekers.Add(firstbezoeker);
            groep.Groepbezoekers.Add(secondbezoeker);
            groep.Groepbezoekers.Add(thirdbezoeker);
            groep.Groepbezoekers.Add(fourthbezoeker);


            List<Rij> rijen = new List<Rij>();
            
            Rij firstrij = new Rij();

            Stoel firststoel = new Stoel(1, false, "A1-01", null, 1);
            Stoel secondstoel = new Stoel(2, false, "A1-02", null, 1);
            Stoel thirdstoel = new Stoel(3, false, "A1-03", null, 1);
            Stoel fourthstoel = new Stoel(4, false, "A1-04", null, 1);

            List<Stoel> stoelen = new List<Stoel>
            {
                firststoel,
                secondstoel,
                thirdstoel,
                fourthstoel
            };

            firstrij.Stoelen = stoelen;

            rijen.Add(firstrij);
            //act
            assigned = firstrij.ChildAssignchairs(groep, rijen);

            //assert
            foreach (Bezoeker kind in Childs.Groepbezoekers)
            {
                Assert.IsTrue(kind.AssignedStoel.rij == 1);
            }

            foreach (Bezoeker bezoeker in groep.Groepbezoekers)
            {
                Assert.IsTrue(bezoeker.AssignedStoel != null);
            }

            Assert.IsTrue(assigned == true, "Het assigenen is niet goed gegaan");
        }

        [TestMethod]
        public void secondcheckchilds()
        {
            //arrange
            bool assigned = false;

            Groep groep = new Groep(1);

            Bezoeker firstbezoeker = new Bezoeker("1.0", 1);
            firstbezoeker.Child = true;

            Bezoeker secondbezoeker = new Bezoeker("1.1", 2);
            secondbezoeker.Child = false;

            Bezoeker thirdbezoeker = new Bezoeker("1.2", 3);
            thirdbezoeker.Child = false;

            Bezoeker fourthbezoeker = new Bezoeker("1.3", 4);
            fourthbezoeker.Child = false;

            groep.Groepbezoekers.Add(firstbezoeker);
            groep.Groepbezoekers.Add(secondbezoeker);
            groep.Groepbezoekers.Add(thirdbezoeker);
            groep.Groepbezoekers.Add(fourthbezoeker);

            Groep Childs = new Groep();
            Childs.Groepbezoekers = groep.Groepbezoekers.Where(b => b.Child == true).ToList();

            List<Rij> rijen = new List<Rij>();

            Rij firstrij = new Rij();
            Rij secondrij = new Rij();

            Stoel firststoel = new Stoel(1, false, "A1-01", null, 1);
            Stoel secondstoel = new Stoel(2, false, "A1-02", null, 1);
            Stoel thirdstoel = new Stoel(3, false, "A1-03", null, 2);
            Stoel fourthstoel = new Stoel(4, false, "A1-04", null, 2);

            List<Stoel> firststoelen = new List<Stoel>
            {
                firststoel,
                secondstoel,
            };

            List<Stoel> secondstoelen = new List<Stoel>
            {
                thirdstoel,
                fourthstoel
            };

            firstrij.Stoelen = firststoelen;
            secondrij.Stoelen = secondstoelen;

            rijen.Add(firstrij);
            rijen.Add(secondrij);
            //act
            assigned = firstrij.ChildAssignchairs(groep, rijen);

            //assert
            foreach (Bezoeker kind in Childs.Groepbezoekers)
            {
                Assert.IsTrue(kind.AssignedStoel.rij == 1);
            }

            foreach(Bezoeker bezoeker in groep.Groepbezoekers)
            {
                Assert.IsTrue(bezoeker.AssignedStoel != null);
            }

            Assert.IsTrue(assigned == true, "Het assigenen is niet goed gegaan");
        }

        [TestMethod]
        public void thirdcheckchilds()
        {
            //arrange
            bool assigned = false;

            Groep groep = new Groep(1);

            Bezoeker firstbezoeker = new Bezoeker("1.0", 1);
            firstbezoeker.Child = true;

            Bezoeker secondbezoeker = new Bezoeker("1.1", 2);
            Bezoeker thirdbezoeker = new Bezoeker("1.2", 3);
            Bezoeker fourthbezoeker = new Bezoeker("1.3", 4);

            groep.Groepbezoekers.Add(firstbezoeker);
            groep.Groepbezoekers.Add(secondbezoeker);
            groep.Groepbezoekers.Add(thirdbezoeker);
            groep.Groepbezoekers.Add(fourthbezoeker);


            List<Rij> rijen = new List<Rij>();

            Rij firstrij = new Rij();

            Stoel firststoel = new Stoel(1, false, "A1-01", null, 1);
            Stoel secondstoel = new Stoel(2, false, "A1-02", null, 1);
            Stoel thirdstoel = new Stoel(3, false, "A1-03", null, 1);

            List<Stoel> stoelen = new List<Stoel>
            {
                firststoel,
                secondstoel,
                thirdstoel,
            };

            firstrij.Stoelen = stoelen;

            rijen.Add(firstrij);
            //act
            assigned = firstrij.ChildAssignchairs(groep, rijen);

            //assert
            Assert.IsTrue(assigned == false, "Het assigenen is goed gegaan");
        }

        [TestMethod]
        public void fourthcheckchilds()
        {
            //arrange
            bool assigned = false;

            Groep groep = new Groep(1);

            Bezoeker firstbezoeker = new Bezoeker("1.0", 1);
            firstbezoeker.Child = true;

            Bezoeker secondbezoeker = new Bezoeker("1.1", 2);
            secondbezoeker.Child = false;

            Bezoeker thirdbezoeker = new Bezoeker("1.2", 3);
            thirdbezoeker.Child = false;

            Bezoeker fourthbezoeker = new Bezoeker("1.3", 4);
            fourthbezoeker.Child = false;

            Bezoeker fifthbezoeker = new Bezoeker("1.4", 5);
            fourthbezoeker.Child = false;

            groep.Groepbezoekers.Add(firstbezoeker);
            groep.Groepbezoekers.Add(secondbezoeker);
            groep.Groepbezoekers.Add(thirdbezoeker);
            groep.Groepbezoekers.Add(fourthbezoeker);
            groep.Groepbezoekers.Add(fifthbezoeker);


            List<Rij> rijen = new List<Rij>();

            Rij firstrij = new Rij();
            Rij secondrij = new Rij();

            Stoel firststoel = new Stoel(1, false, "A1-01", null, 1);
            Stoel secondstoel = new Stoel(2, false, "A1-02", null, 1);
            Stoel thirdstoel = new Stoel(3, false, "A1-03", null, 2);
            Stoel fourthstoel = new Stoel(4, false, "A1-04", null, 2);

            List<Stoel> firststoelen = new List<Stoel>
            {
                firststoel,
                secondstoel,
            };

            List<Stoel> secondstoelen = new List<Stoel>
            {
                thirdstoel,
                fourthstoel
            };

            firstrij.Stoelen = firststoelen;
            secondrij.Stoelen = secondstoelen;

            rijen.Add(firstrij);
            rijen.Add(secondrij);

            //act
            assigned = firstrij.ChildAssignchairs(groep, rijen);

            //assert
            Assert.IsTrue(assigned == false, "Het assigenen is niet goed gegaan");
        }

        [TestMethod]
        public void firstcheckadult()
        {
            //arrange
            bool assigned = false;

            Groep groep = new Groep(1);

            Bezoeker firstbezoeker = new Bezoeker("1.0", 1);
            firstbezoeker.Child = true;

            Bezoeker secondbezoeker = new Bezoeker("1.1", 2);
            Bezoeker thirdbezoeker = new Bezoeker("1.2", 3);
            Bezoeker fourthbezoeker = new Bezoeker("1.3", 4);

            groep.Groepbezoekers.Add(firstbezoeker);
            groep.Groepbezoekers.Add(secondbezoeker);
            groep.Groepbezoekers.Add(thirdbezoeker);
            groep.Groepbezoekers.Add(fourthbezoeker);

            Rij rij = new Rij();

            Stoel firststoel = new Stoel(1, false, "A1-01", null, 1);
            Stoel secondstoel = new Stoel(2, false, "A1-02", null, 1);
            Stoel thirdstoel = new Stoel(3, false, "A1-03", null, 2);
            Stoel fourthstoel = new Stoel(4, false, "A1-04", null, 2);

            List<Stoel> stoelen = new List<Stoel>
            {
                firststoel,
                secondstoel,
                thirdstoel,
                fourthstoel
            };

            rij.Stoelen = stoelen;

            //act
            assigned = rij.AdultAssignchairs(groep, rij);

            //assert
            Assert.IsTrue(assigned == true, "Het assigenen is niet goed gegaan");

            foreach (Bezoeker bezoeker in groep.Groepbezoekers)
            {
                Assert.IsTrue(bezoeker.AssignedStoel != null);
            }
        }

        [TestMethod]
        public void secondcheckadult()
        {
            //arrange
            bool assigned = false;

            Groep groep = new Groep(1);

            Bezoeker firstbezoeker = new Bezoeker("1.0", 1);
            firstbezoeker.Child = true;

            Bezoeker secondbezoeker = new Bezoeker("1.1", 2);
            Bezoeker thirdbezoeker = new Bezoeker("1.2", 3);
            Bezoeker fourthbezoeker = new Bezoeker("1.3", 4);
            Bezoeker fifthbezoeker = new Bezoeker("1.4", 5);

            groep.Groepbezoekers.Add(firstbezoeker);
            groep.Groepbezoekers.Add(secondbezoeker);
            groep.Groepbezoekers.Add(thirdbezoeker);
            groep.Groepbezoekers.Add(fourthbezoeker);
            groep.Groepbezoekers.Add(fifthbezoeker);

            Rij rij = new Rij();

            Stoel firststoel = new Stoel(1, false, "A1-01", null, 1);
            Stoel secondstoel = new Stoel(2, false, "A1-02", null, 1);
            Stoel thirdstoel = new Stoel(3, false, "A1-03", null, 1);
            Stoel fourthstoel = new Stoel(4, false, "A1-04", null, 1);

            List<Stoel> stoelen = new List<Stoel>
            {
                firststoel,
                secondstoel,
                thirdstoel,
                fourthstoel
            };

            rij.Stoelen = stoelen;

            //act
            assigned = rij.AdultAssignchairs(groep, rij);

            //assert
            Assert.IsTrue(assigned == false, "Het assigenen is goed gegaan");
        }
    }
}
