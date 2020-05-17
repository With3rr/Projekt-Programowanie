using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaClient
{
    class AplikacjaKlientaTests
    {


        [Test]
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

        [Test]
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
