using AlgoritmeClasslibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test_AlgoritmeCLasslibrary
{
    [TestClass]
    public class Groep_unittests
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange & act
            Groep groep = new Groep();

            // assert
            Assert.IsNotNull(groep, "Groep zou niet null moeten zijn.");
        }

        [TestMethod]
        public void Secondconstructortest()
        {
            //arrange
            int groepnumber = 5;

            //act
            Groep groep = new Groep(groepnumber);

            //assert
            Assert.IsNotNull(groep, "Groep zou niet null moeten zijn.");
            Assert.IsNotNull(groep.Groepbezoekers, "de lijst voor bezoekers zou niet null moeten zijn.");

            Assert.AreEqual(groepnumber, groep.Groepnumber, "Groepnumbers matchen niet");
        }

        [TestMethod] 
        public void makegroup()
        {
            //arrange
            int groepnumber = 6;
            int uniquenumber = 2;
            Groep newgroep = new Groep();

            //act
            newgroep = newgroep.Makegroup(groepnumber, uniquenumber);

            //arrange
            Assert.IsNotNull(newgroep, "Groep zou niet null moeten zijn.");
            Assert.IsNotNull(newgroep.Groepbezoekers, "de lijst voor bezoekers zou niet null moeten zijn.");

            Assert.AreEqual(groepnumber, newgroep.Groepnumber, "groepnummers komen niet overheen");
            Assert.IsTrue(newgroep.Groepbezoekers.Last().uniquenumber > 2, "Het unique nummer is niet omhoog gegaan dus er zijn geen bezoekers aangemaakt");
        }
        
        [TestMethod]
        public void truechildingroup()
        {
            //assert
            bool childingroup;

            Groep groep = new Groep(1);

            Bezoeker child = new Bezoeker("C-05", 5);
            child.Child = true;

            groep.Groepbezoekers.Add(child);

            //act
            childingroup = groep.Childingroup(groep);

            //assert
            Assert.IsTrue(childingroup == true, "Check is niet goed gegaan er zit een kind in de groep");
        }

        [TestMethod]
        public void falsechildingroup()
        {
            //assert
            bool adultingroup;

            Groep groep = new Groep(1);

            Bezoeker Volwassen = new Bezoeker("C-01", 5);
            Volwassen.Child = false;

            groep.Groepbezoekers.Add(Volwassen);

            //act
            adultingroup = groep.Childingroup(groep);

            //assert
            Assert.IsTrue(adultingroup == false, "Check is niet goed gegaan er zit alleen een volwassene in de groep");
        }
    }
}
