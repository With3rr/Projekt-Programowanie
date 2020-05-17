using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplikacjaClient
{
    public static class Obliczenia
    {

        /// <summary>
        /// Ta metoda sprawdza czy założenia zostały spełnione
        /// </summary>
        /// <param name="tekst"></param>
        /// <returns></returns>
        static public bool CzyDaneSpelniajaZalozenia(string tekst)
        {
            if (tekst.Length < 8)
            {
                return true;
            }
            else if (tekst.Contains(",") || tekst.Contains(".") || tekst.Contains("/") || tekst.Contains("'") || tekst.Contains(";") || tekst.Contains("[") || tekst.Contains("]") || tekst.Contains("{") || tekst.Contains("}") || tekst.Contains("|") || tekst.Contains(":") || tekst.Contains(@"""") || tekst.Contains("<") || tekst.Contains(">") || tekst.Contains("!") || tekst.Contains(")") || tekst.Contains("(") || tekst.Contains("*"))
            {
                return true;

            }
            else if (tekst == "")
            {
                return true;
            }
            else
            {
                return false;
            }
            

           


        }


        public static  double  obliczanieFullPrice(ObservableCollection<Gry> gry)
        {
            double max = 0;
            if(gry.Count!=0)
            {
                for (int i = 0; i < gry.Count; i++)
                {
                    if (gry[i].Cena < 0)
                    {
                        gry[i].Cena = 0;
                    }
                    max += gry[i].Cena;


                }

            }
            else
            {
                return 0;
            }

           

            return max;

        }

    }
}
