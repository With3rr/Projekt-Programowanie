using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaClient
{
    /// <summary>
    /// Klasa GryBiblioteka określa obiekty które wchodzą w skład biblioteki gier (które to dostępne są po zakupieniu przez urzytkownika)
    /// </summary>
    /// <remarks>
    /// Klasa ta pozwala dostęp do poszczególnych właściwości które są cechami określonego obiektu a w tym przypadku zakupionej gry i będącej w bibliotece urzytkownika
    /// Dostęp do nich jest swobodny.
    /// </remarks>
    class GryBiblioteka :Gry
    {
        /// <summary>
        /// Konstruktor bezargumentowy klasy
        /// </summary>
        public GryBiblioteka()
        {

        }
        /// <summary>
        /// Konstruktor klasy z ośmioma argumentami określającymi cechy objektu. 
        /// </summary>
        /// <remarks>
        /// Właściwości określane są na podstawie tych atrybutów a operacja przypisania następuje właśnie w konstruktorze.
        /// Pozostałe atrybuty przesyłane są do konstruktora klasy bazowej po której ta klasa dziedziczy.
        /// </remarks>
        public GryBiblioteka(Uri zdj,string nazwa, int liczbagodzin,Uri zdjtutul,string sciezka,string sciezkaVide,string opis,string videoOkno):base(zdj,nazwa, zdjtutul,sciezkaVide,opis,videoOkno)
        {
            liczbaGodzin = liczbagodzin;
            SciezkaGry = sciezka;

        }
        /// <value>
        /// Własciwość ta określa Sciezke do gry która dostępna będzie pużniej z poziomu programu i symulowała będzie dostęp do określonej gry,posiada dostęp publiczny i możlwość ustawienia oraz pobrania wartości
        /// </value>
        public string SciezkaGry { get; set; }

        /// <value>
        /// Własciwość ta określa liczbę godzin spędzonych z grę,wartość ta pobierana będzie 
        /// </value>
        public int liczbaGodzin { get; set; }

        
    }
}
