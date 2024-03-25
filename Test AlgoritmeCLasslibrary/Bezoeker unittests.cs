using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AlgoritmeClasslibrary;

namespace Test_AlgoritmeCLasslibrary
{
    [TestClass]
    public class Bezoeker_unittests
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange
            string name = "C-01";
            int uniquenumber = 1;


            //act
            Bezoeker bezoeker = new Bezoeker(name, uniquenumber);

            // assert
            Assert.IsNotNull(bezoeker, "Game zou niet null moeten zijn.");
            Assert.IsNotNull(bezoeker.Birthday, "Birthday mag niet leeg zijn");
            Assert.IsNotNull(bezoeker.Child, "Of het een kind is mag niet leeg zijn");

            Assert.AreEqual(name, bezoeker.Name, "Names komen niet overheen");
            Assert.AreEqual(uniquenumber, bezoeker.uniquenumber, "Uniquenumbers komen niet overheen ");
        }

        [TestMethod]
        public void GetFormattedBirthdate()
        {
            //arrange
            DateTime birthday = DateTime.Now.AddYears(-60); ;

            //act
            string formattedbirthday = birthday.ToString("dd-MM-yyyy");

            //assert
            string expectedFormattedBirthday = DateTime.Now.AddYears(-60).ToString("dd-MM-yyyy");
            Assert.AreEqual(expectedFormattedBirthday, formattedbirthday);
        }
    }
}
