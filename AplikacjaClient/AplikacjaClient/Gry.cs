using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaClient
{
     /// <summary>
    /// Klasa GryBiblioteka określa obiekty które będą możlwe do przeglądania przez urzytkownika i możlwe do kupienia.
    /// </summary>
    /// <remarks>
    /// Klasa ta pozwala dostęp do poszczególnych właściwości obiektów typu Gry które będą zawierać podstawowe własciowsci i typy gier sprzedawanych.
    /// Dostęp do nich jest swobodny.
    /// </remarks>
    class Gry
    {
        /// <summary>
        /// Konstruktor bezargumentowy klasy.
        /// </summary>
        public Gry()
        {

        }
        /// <summary>
        /// Konstruktor klasy z sześcioma argumentami określającymi cechy objektu.
        /// </summary>
        /// <remarks>
        /// Właściwości określane są na podstawie tych atrybutów a operacja przypisania następuje właśnie w konstruktorze.
        /// </remarks>
        public Gry(Uri zdj,string nazwa,Uri zdjtutulowe,string video,string opis,string videoOnko)
        {
            Nazwa = nazwa;
            Zdjecie = zdj;
            ZdjTytulowe = zdjtutulowe;
            SciezkaVideo = video;
            Opis = opis;
            sciezKaVideoOkno = videoOnko;

        }
        /// <summary>
        /// Konstruktor klasy z jedynastoma argumentami określającymi cechy objektu.
        /// </summary>
        /// <remarks>
        /// Właściwości określane są na podstawie tych atrybutów a operacja przypisania następuje właśnie w konstruktorze.
        /// </remarks>
        public Gry(string nazwa,string opis,double cena,string gatunek,Uri zdj,string p1, string p2, string p3, string p4,string tworca,int rokwyd)
        {

            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            Gatunek = gatunek;
            Podgatunek1 = p1;
            Podgatunek2 = p2;
            Podgatunek3 = p3;
            Podgatunek4 = p4;
            Twórca = tworca;
            Rokwydania = rokwyd;
            Zdjecie = zdj;


        }
        /// <value>
        /// Własciwość ta określa ścieżkę do video typu string do której dostęp będzie w aplikacji a dokładniej w bibliotece urzytkownika.
        /// </value>
        public string sciezKaVideoOkno { get; set; }

        /// <value>
        /// Własciwość ta określa ścieżkę do video typu string.
        /// </value>
        public string SciezkaVideo { get; set; }

        /// <value>
        /// Własciwość ta określa Twórce/wydawcę danej gry.
        /// </value>
        public string Twórca { get; set; }

        /// <value>
        /// Własciwość ta określa rok wydania danej gry.
        /// </value>
        public int Rokwydania { get; set; }


        /// <value>
        /// Własciwość ta określa zdjęcie tytułowe danej gry i jest typu Uri.
        /// </value>
        public Uri ZdjTytulowe { get; set;}


        /// <value>
        /// Własciwość ta określa nazwę gry.
        /// </value>
        public string Nazwa { get; set; }


        /// <value>
        /// Własciwość ta określa Opis danej gry.
        /// </value>
        public string Opis { get; set; }

        /// <value>
        /// Własciwość ta określa Cenę danej gry.
        /// </value>
        public double Cena { get; set; }

        /// <value>
        /// Własciwość ta określa Gatunek (1 z 5) danej gry.
        /// </value>
        public string Gatunek { get; set; }

        /// <value>
        /// Własciwość ta określa Zdjęcie (miniaturkę) danej gry.
        /// </value>
        public Uri Zdjecie { get; set; }


        /// <value>
        /// Własciwość ta określa podgatunek danej gry.
        /// </value>
        public string Podgatunek1 { get; set; }

        /// <value>
        /// Własciwość ta określa podgatunek danej gry.
        /// </value>
        public string Podgatunek2 { get; set; }

        /// <value>
        /// Własciwość ta określa podgatunek danej gry.
        /// </value>
        public string Podgatunek3 { get; set; }

        /// <value>
        /// Własciwość ta określa podgatunek danej gry.
        /// </value>
        public string Podgatunek4 { get; set; }

    }
}
