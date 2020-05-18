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
        /// <param name="tekst"> Jest to parametr który określa dane urzytkownika przesyłane w celu sprawdzenia poprawności</param>
        /// <returns>Zwraca true jeżeli tekst nie spełnia wymagań i false jeśli spełnia</returns>
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

        /// <summary>
        /// Metoda która odpowiada na sumowanie wartości zakupionych gier.
        /// </summary>
        /// <remarks>
        /// Działanie tej metody polega na przyjmowaniu zestawu gier oraz zwracaniu zsumowanej ceny tych gier.
        /// </remarks>
        /// <param name="gry">
        /// Kolekcja obiektów typu Gry.
        /// </param>
        /// <returns>
        /// Zwracany jest zsumowana cena gier w koszyku
        /// </returns>
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
