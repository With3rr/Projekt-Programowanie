using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplikacjaClient;
using System.Collections.ObjectModel;

namespace AplikacjaClinet.Tests
{

    /// <summary>
    /// Jest to testowa klasa.
    /// </summary>
    /// <remarks>
    /// W klasie tej znajdują sie dwie metody testowe które odpowiadają za testowanie różnych wariantów kodu.
    /// </remarks>
    [TestClass]
    public class AplikacjaClientTests
    {



        /// <summary>
        /// Metoda testowa która odpowiada za testowanie metody która przyjmuje dane w postaci teksu i zwraca wartość typu boolean jako to czy metoda spełnia warunki lub nie.
        /// </summary>
        [TestMethod]
        public void TestNiepoprawnosciWprowadzanychDanych()
        {
            bool czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia("tak");
            Assert.IsTrue(czySpelnia);



            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia("0");
            Assert.IsTrue(czySpelnia);



            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia("375956,50");
            Assert.IsTrue(czySpelnia);


            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia(">>>>>>>>>>>>>>>>");
            Assert.IsTrue(czySpelnia);

            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia("}}}}}}}}}}}}}}}}}}}}}}}}}}}");
            Assert.IsTrue(czySpelnia);


            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia("");
            Assert.IsTrue(czySpelnia);


            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia(string.Empty);
            Assert.IsTrue(czySpelnia);



            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia("taktaktaktaktak");
            Assert.IsFalse(czySpelnia);


            czySpelnia = AplikacjaClient.Obliczenia.CzyDaneSpelniajaZalozenia("373845039545");
            Assert.IsFalse(czySpelnia);

            
            


        }

        /// <summary>
        /// Testowa metoda która sprawdza sumowanie cen poszczególnych produktów typy Gry w kolekcji oraz zraca adekwatną zsumowaną kwotę.Metoda testowana jest różnymi danymi w celu sprawdzenia jej poprawności.
        /// </summary>
        [TestMethod]
        public void TestPoprawnosciWprowadzanychGier()
        {
            ObservableCollection<Gry> games = new ObservableCollection<Gry>()
                {
                    {new Gry(){ Cena=10 } },
                    {new Gry(){ Cena=3 } },
                    {new Gry(){ Cena=2 } },
                    {new Gry(){ Cena=5 } }



                };
            Assert.AreEqual(20, AplikacjaClient.Obliczenia.obliczanieFullPrice(games));


            games = new ObservableCollection<Gry>()
                {
                    {new Gry(){ Cena=0 } },
                    {new Gry(){ Cena=0 } },
                    {new Gry(){ Cena=0 } },
                    {new Gry(){ Cena=0 } }



                };

            Assert.AreEqual(0, AplikacjaClient.Obliczenia.obliczanieFullPrice(games));

            games = new ObservableCollection<Gry>()
            {




            };


            Assert.AreEqual(0, AplikacjaClient.Obliczenia.obliczanieFullPrice(games));



        }

    }
}
