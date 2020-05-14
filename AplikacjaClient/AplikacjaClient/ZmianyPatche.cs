using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Postawowa przestrzeń nazw Aplikacji
/// </summary>
namespace AplikacjaClient
{

    /// <summary>
    /// Klasa ZmianyPatche określa kolejno wprowadzone Zmiany w aplikacji przez zespól za to odpowiedzialny
    /// </summary>
    /// <remarks>
    /// Na podstawie tej klasy twożone są obiekty które wykorzystywane są do dokumentacji zmian wprowadzanych w aplikacji a ich wyniki są wyświetlane w samej aplikacji.
    /// Dostęp do nich jest swobodny.
    /// </remarks>
    class ZmianyPatche
    {
        /// <summary>
        /// Konstruktor bezargumentowy klasy
        /// </summary>
        public ZmianyPatche()
        {

        }

        /// <value>
        /// Własciwość NR_patch jest właściwością o dostępie publicznym zwracającą oraz pobierającą wartość typu string reperezentującą nr seryjny patcha który został wprowadzony.
        /// </value>
        
        public string NR_patch { get; set; }

        /// <value>
        /// Własciwość ta określa wprowadzone zmiany dla określonego nr_patcha jako jeden obiekt,jest to wartość typu string i może być ustawiana i pobierana przy dostępie publicznym
        /// </value>
        public string WprowadzoneZmiany { get; set; }
    }
}
