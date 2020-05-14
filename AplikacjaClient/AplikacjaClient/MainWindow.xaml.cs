using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using System.IO;

namespace AplikacjaClient
{
    /// <summary>
    /// Głowna klasa aplikacji
    /// </summary>
    /// <remarks>
    /// Klasa ta za w sobie wszystkie wiekszość metod manipulacji nad aplikacją,kupowania gier,dostęp do metody płatności,biblioteka gier i różnych opcji personalizacji konta.
    ///
    /// </remarks>
    public partial class MainWindow : Window
    {
        private double max = 0;


        /// <summary>
        /// Zmienna która przechowuje w sobie obiekty gier.
        /// </summary>
        private List<Gry> Allgames = null;

        /// <summary>
        /// Zmienna która przechowuje w sobie obiekty gier.
        /// </summary>
        private ObservableCollection<Gry> Actiongames = null;

        /// <summary>
        /// Zmienna która przechowuje w sobie obiekty gier.
        /// </summary>
        private ObservableCollection<Gry> Racinggames = null;

        /// <summary>
        /// Zmienna która przechowuje w sobie obiekty gier.
        /// </summary>
        private ObservableCollection<Gry> Strategygames = null;

        /// <summary>
        /// Zmienna która przechowuje w sobie obiekty gier.
        /// </summary>
        private ObservableCollection<Gry> Sportgames = null;

        /// <summary>
        /// Zmienna która przechowuje w sobie obiekty gier.
        /// </summary>
        private ObservableCollection<Gry> Scifigames = null;

        /// <summary>
        /// Zmienna która przechowuje w sobie obiekty gier.
        /// </summary>
        private ObservableCollection<Gry> Rpggames = null;


        /// <summary>
        /// lista z obiektami zmian w aplikacji które będą wyswietlane w samej aplikacji w polu "lista zmian"
        /// </summary>
        private ObservableCollection<ZmianyPatche> listapatchy = null;

       
        private Gry leftPanelBiblioteki = null;

        /// <summary>
        /// lista z przyciskami które określają która tabela z konkretnym gatunkiem gry ma być wyswietlona.
        /// </summary>
        private List<Button> przysiski = null;

        /// <summary>
        /// lista gridami w których to znajdują się kontrolki datagrid zastosowane do wizualiacji listy gier przy pomocy bindingu i datakontext.
        /// </summary>
        private List<Grid> gridyGier = null;


        /// <summary>
        /// Zmienna która pozwala na dostęp do bazy danych i pobieranie oraz zapisywanie do niej odpowiedznich wartości.
        /// </summary>
        private BazaUżytkownikowEntities bazadanych = null;

        /// <summary>
        /// Lista która zawiera w sobie widoki poszczególnych datagrid co będzie pozwalać na manipulację wyświetlania ich na ekran(filtry,sortowanie).
        /// </summary>
        private ObservableCollection<CollectionView> widoki = null;

        /// <summary>
        /// Lista która zawiera obiekty będące grami w koszyku czekającymi na zakup.
        /// </summary>
        private ObservableCollection<Gry> gryWkoszyku = null;


        /// <summary>
        /// Gry w bibliotece użytkownika.
        /// </summary>
        private List<GryBiblioteka> gryWBibliotece =null;

        DispatcherTimer timer;

        /// <summary>
        /// Zmienna która posłuży do logowania.
        /// </summary>
        DaneKonta logowanie = null;

       
        List<GrywMojejBibliotece> listagier = null;


        Kody kody = null;


        CollectionView widok = null;

        List<HistoriaZakupow> listazakupow = null;


        List<HistoriaZakupow> listaZakupoowDoprzeglodania= new List<HistoriaZakupow>();




        private GrywMojejBibliotece updateSciezki = null;

        /// <summary>
        /// Metoda main aplikacji.
        /// </summary>
        /// <remarks>
        /// Odpowiada ona za inicjalizację obiektu Aplikacji i to od niej zaczyna się wykonywanie programu
        /// </remarks>
        public MainWindow()
        {



            //Dodawanie kart płatniczych do bazy danych
            //aaa.Karties.Add(new Karty { Imie = "Marcin", Nazwisko = "Rak", nrKarty = "3425503858399503", nrID="234", Stan=234 });
            //aaa.Karties.Add(new Karty { Imie = "Jan", Nazwisko = "Marian", nrKarty = "3423203558390903", nrID = "273", Stan = 2867 });
            //aaa.Karties.Add(new Karty { Imie = "Robert", Nazwisko = "Pyk", nrKarty = "3225505850379503", nrID = "734", Stan = 580.67 });
            //aaa.SaveChanges();

            //Dodanie gier do biblioteki użytkownika
            //aaa.GrywMojejBiblioteces.Add( new GrywMojejBibliotece { Użytkownik = 2003, godzinywGrze = 240, Nazwa_gry = "Frostpunk" } );
            //aaa.GrywMojejBiblioteces.Add(new GrywMojejBibliotece { Użytkownik = 2003, godzinywGrze = 50, Nazwa_gry = "Arma 3" });
            //aaa.GrywMojejBiblioteces.Add(new GrywMojejBibliotece { Użytkownik = 2003, godzinywGrze = 20, Nazwa_gry = "Metro exodus" });

            //aaa.SaveChanges();

            //dodanie znajomych do bazy
            //aa.Friends.Add(new Friend { Id_kogo = 2003, Nick = "Wald202" });
            //aa.Friends.Add(new Friend { Id_kogo = 2003, Nick = "Mar12" });
            //aa.Friends.Add(new Friend { Id_kogo = 2003, Nick = "KataBycJakJa" });
            //aa.SaveChanges();





            InitializeComponent();
            przysiski = new List<Button>();
            przysiski.Add(leftbt1);
            przysiski.Add(leftbt2);
            przysiski.Add(leftbt3);
            przysiski.Add(leftbt4);
            przysiski.Add(leftbt5);
            przysiski.Add(leftbt6);
            przysiski.Add(leftbt7);

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            bazadanych = new BazaUżytkownikowEntities( );
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "123456789", Nazwa_gry = "Arma 3" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "567490053", Nazwa_gry = "Ori 2" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "578937581", Nazwa_gry = "Dota 2" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "084936417", Nazwa_gry = "Misbits" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "123321678", Nazwa_gry = "The surge 2" });



            //bazadanych.Kodies.Add(new Kody { Kod_gry = "223456789", Nazwa_gry = "Arma 3" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "467490053", Nazwa_gry = "Ori 2" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "878937581", Nazwa_gry = "Dota 2" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "184936417", Nazwa_gry = "Misbits" });
            //bazadanych.Kodies.Add(new Kody { Kod_gry = "223321678", Nazwa_gry = "The surge 2" });
            //bazadanych.SaveChanges();


            gridyGier = new List<Grid>();
            gridyGier.Add(gridgames1);
            gridyGier.Add(gridgames2);
            gridyGier.Add(gridgames3);
            gridyGier.Add(gridgames4);
            gridyGier.Add(gridgames5);
            gridyGier.Add(gridgames6);
            gridyGier.Add(gridgames7);
            gryWBibliotece = new List<GryBiblioteka>();
            gridBiblioteka.ItemsSource = gryWBibliotece;
            historiaZak.ItemsSource = listaZakupoowDoprzeglodania;
            
            kody = new Kody();
            inicjalizacjaGier();
            


            



















        }
        /// <summary>
        /// Metoda ta inicjalizuje widoki poszczegulnych datagrid
        /// </summary>
        /// <remarks>
        /// Do listy widoki dodawane są kolejjno Domyślne widoki gażdego z data grid (tabeli gier) co pozowli na puźniejsze filtrowanie wyświetlanych gier lub odpowiednie ich sortowanie według wybranego kryterium.
        /// 
        /// </remarks>
        public void inicjalizacjaWidokow()
        {
            widoki = new ObservableCollection<CollectionView>();
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(gridProdukty1.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(gridProdukty2.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(gridProdukty3.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(gridProdukty4.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(gridProdukty5.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(gridProdukty6.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(gridProdukty7.ItemsSource));

            widok = ((CollectionView)CollectionViewSource.GetDefaultView(gridBiblioteka.ItemsSource));
            


        }
        /// <summary>
        /// Inicjalizuje obiekty poszczególnych typów gier
        /// </summary>
        /// <remarks>
        /// Metoda ta dodatkowo inicjalizuje właściwość itemsrource dla każdej z kontrolek Datagrid co pozlowi na pobieranie obiektów różnych klas z obpowiednich list przy pomocy Bindingu i datakontext.
        /// Wywołuje ona równiez metodę inicjalizacjaWidokow;
        /// </remarks>
        public void inicjalizacjaGier()
        {
            string sciezka2 = "pack://application:,,,/MainPict/";
            string sciezka = "pack://application:,,,/Games/";
            Actiongames = new ObservableCollection<Gry>();
            Actiongames.Add(new Gry("Resident evil 3", "Resident Evil 3: Nemesis is a survival horror game where the player controls the protagonist, Jill Valentine,  from  a third-person  perspective to interact with the environment and enemies. The player takes control  of another character for a brief portion of the game.", 240,"Akcja", new Uri(sciezka + "actGames/header.jpg"), "akcja", "horror", "coop", "apokalipsa","Capcom",2020));
            Actiongames.Add(new Gry("One piece", "The One Piece video games series is published by Bandai and Banpresto, later as part of Bandai Namco  Entertainment, and  is  based on Eiichiro Oda's shonen manga and anime series of the same name. The games   take place in the fictional world of One Piece, and the stories revolve around the adventures of Monkey D.", 120, "Akcja", new Uri(sciezka + "actGames/header1.jpg"), "piraci", "anime", "walka", "fantasy", "Capcom", 2020));
            Actiongames.Add(new Gry("Doom eternal", "Doom Eternal is a first person shooter video game developed by id Software and published by Bethesda  Softworks. ... The game  received critical acclaim, with praise for its campaign, graphics, level design, soundtrack  and  combat mechanics, while some disliked the game's increased focus on storytelling.", 255, "Akcja", new Uri(sciezka + "actGames/header6.jpg"), "diabły", "piekło", "walka", "krew","Bethesda",2020));
            Actiongames.Add(new Gry("Dragon ball kakkarott", "Dragon Ball Z: Kakarot (ドラゴンボールZ カカロット, Doragon Bōru Zetto Kakarotto) is a semi open  world action role-playing  game developed by CyberConnect2 and published by Bandai Namco Entertainment, based  on the Dragon  Ball franchise, released for Microsoft Windows, PlayStation 4, and Xbox One.", 180, "Akcja", new Uri(sciezka + "actGames/header8.jpg"), "anime", "walka", "opowieść", "turniej","Capcom",2020));
            Actiongames.Add(new Gry("Metro exodus", "Metro Exodus is a first-person shooter game with survival horror and stealth elements. ... The game  features  a mixture of linear levels  and sandbox environments. It also includes a dynamic weather  system, a day-night cycle, and environments that change along with the seasons as the story progresses.", 245, "Akcja", new Uri(sciezka + "actGames/header9.jpg"), "rosja", "apokalipsa", "samotność", "przetrwanie","4A Games",2019));
            Actiongames.Add(new Gry("Assassin's creed origins", "Assassin's Creed Origins is an action-adventure stealth game played from a third-person  perspective. ... The player  can take control of Senu and scout an area in advance, highlighting  enemies which will then be  visible when they return to controlling Bayek, the game's main character.", 110, "Akcja", new Uri(sciezka + "actGames/header17.jpg"), "pustynia", "walka", "skradanie", "open-world","Ubisoft",2017));
            Actiongames.Add(new Gry("Deus ex human revolution", "Deus Ex: Human Revolution is an action role-playing game with incorporated first-person shooter  and stealth  mechanics. Players take the role of Adam Jensen, a man equipped with mechanical cybernetic implants  called augmentations.", 140, "Akcja", new Uri(sciezka + "actGames/header25.jpg"), "skradanie", "cyber", "walka", "futuryzm", "Eidos Montreal",2014));
            Actiongames.Add(new Gry("Arma 3", "ARMA 3. ARMA 3 is an open-world, realism-based, military tactical shooter video game developed  and published  by Bohemia  Interactive.  It was released for Microsoft Windows in September 2013, and   later announced for macOS and Linux  in August 2015.", 260, "Akcja", new Uri(sciezka + "actGames/header28.jpg"), "broń", "walka", "multiplayer", "wojna","Sonic",2015));
            Actiongames[7].ZdjTytulowe = new Uri(sciezka2 + "tytul.jpg");
            Actiongames[5].SciezkaVideo = "https://www.youtube.com/watch?v=cK4iAjzAoas&t=53s";
            Actiongames[5].sciezKaVideoOkno = @"C:\Users\With3rr\source\repos\Platforma\AplikacjaClient\AplikacjaClient\Movies\acs.mp4";

            Racinggames = new ObservableCollection<Gry>();
            Racinggames.Add(new Gry("Street Racing", "", 240, "Wyscigi", new Uri(sciezka + "racingGames/header36.jpg"), "akcja", "open world", "multiplayer", "rywalizacja", "Capcom", 2000));
            Racinggames.Add(new Gry("Drift", "", 120, "Wyścigi", new Uri(sciezka + "racingGames/header37.jpg"), "akcja", "open world", "szybkie auta", "rywalizacja","Capcom", 2010));
            Racinggames.Add(new Gry("Car mechanic 2018", "", 255, "Wyścigi", new Uri(sciezka + "racingGames/header40.jpg"), "akcja", "open world", "szybkie auta", "rywalizacja", "Capcom", 2015));
            Racinggames.Add(new Gry("Mad max", "", 180, "Wiścigi", new Uri(sciezka + "racingGames/header41.jpg"), "akcja", "open world", "coop", "rywalizacja", "Capcom", 2015));
            Racinggames.Add(new Gry("Just drift it", "", 154, "Wyścigi", new Uri(sciezka + "racingGames/header42.jpg"), "akcja", "open world", "szybkie auta", "rywalizacja", "Capcom", 2015));
            Racinggames.Add(new Gry("Silicon rising", "", 180, "Wiścigi", new Uri(sciezka + "racingGames/header43.jpg"), "akcja", "open world", "szybkie auta", "rywalizacja", "Capcom", 2015));


            Strategygames = new ObservableCollection<Gry>();
            Strategygames.Add(new Gry("Frostpunk", "", 260, "Strategia", new Uri(sciezka + "stratGames/header31.jpg"), "coop", "potyczka", "kreatury", "taktyka", "steam", 2013));
            Strategygames.Add(new Gry("Jurrasic World", "", 222, "Strategia", new Uri(sciezka + "stratGames/header32.jpg"), "tury", "potyczka", "kreatury", "taktyka", "steam", 2013));
            Strategygames.Add(new Gry("Total war warharmer", "", 170, "Strategia", new Uri(sciezka + "stratGames/header30.jpg"), "tury", "potyczka", "kreatury", "taktyka", "steam", 2013));
            Strategygames.Add(new Gry("Dota 2", "", 30, "Strategia", new Uri(sciezka + "stratGames/header29.jpg"), "oddanie", "potyczka", "multiplayer", "taktyka","steam",2013));
            Strategygames.Add(new Gry("Ori 2", "W Ori and the Will of the Wisps po raz kolejny wcielamy się w tytułowego Oriego. Tym razem młody duch wybiera się poza teren lasu Nibel, by odkryć swoje prawdziwe przeznaczenie. Choć w egzotycznym świecie czyhają na niego liczne niebezpieczeństwa, są tam też sojusznicy, którzy chętnie wyciągną do niego pomocną dłoń.", 160, "Strategia", new Uri(sciezka + "stratGames/header7.jpg"), "fantasy", "potyczka", "magia", "taktyka", "steam", 2013));
            Strategygames.Add(new Gry("Gordian Quest", "", 170, "Strategia", new Uri(sciezka + "stratGames/header47.jpg"), "coop", "potyczka", "kreatury", "taktyka", "steam", 2012));
            Strategygames[4].SciezkaVideo = "https://www.youtube.com/watch?v=2reK8k8nwBc";
            Strategygames[4].sciezKaVideoOkno = @"C:\Users\With3rr\source\repos\Platforma\AplikacjaClient\AplikacjaClient\Movies\acs.mp4";



            Sportgames = new ObservableCollection<Gry>();
            Sportgames.Add(new Gry("Misbits", "", 160, "Sportowe", new Uri(sciezka + "sportGames/header39.jpg"), "fantasy", "coop", "kreatury", "sport", "Amda", 2012));
            Sportgames.Add(new Gry("Broken spell", "", 55, "Sportowe", new Uri(sciezka + "sportGames/header38.jpg"), "chiny", "techniki", "rywalizacja", "sport", "Sanda In", 2012));
            Sportgames.Add(new Gry("Horse Racing", "", 33, "Sportowe", new Uri(sciezka + "sportGames/header35.jpg"), "konie", "rywalizacja", "przeszkody", "sport", "Amda", 2012));
            Sportgames.Add(new Gry("Kick online", "", 40, "Sportowe", new Uri(sciezka + "sportGames/header34.jpg"), "piłka", "rywalizacja", "drużyny", "boisko", "Amda", 2012));
            Sportgames.Add(new Gry("Rbi 20", "", 125, "Sportowe", new Uri(sciezka + "sportGames/header33.jpg"), "widowisko", "pałki", "apokalipsa", "sport","Amda",2012));
            Sportgames.Add(new Gry("Vikubb", "", 33, "Sportowe", new Uri(sciezka + "sportGames/header46.jpg"), "konie", "multiplayer", "przeszkody", "zabawki", "Amda", 2012));

            Scifigames = new ObservableCollection<Gry>();
            Scifigames.Add(new Gry("The surge 2", "", 115, "Futurystyczne", new Uri(sciezka + "scifGames/header23.jpg"), "cyber", "elektryczność", "apokalipsa", "pancerz", "Deck13",2020));
            Scifigames.Add(new Gry("Cyberpunk 2077", "", 225, "Futurystyczne", new Uri(sciezka + "scifGames/header19.jpg"), "cyber", "wszczepy", "fabuła", "retrofuturyzm", "Cdp red", 2020));
            Scifigames.Add(new Gry("Jedi fallen order", "", 215, "Futurystyczne", new Uri(sciezka + "scifGames/header13.jpg"), "statki", "moc", "kreatury", "galaktyka","Ea games",2019));
            Scifigames.Add(new Gry("Borderlands 3", "", 250, "Futurystyczne", new Uri(sciezka + "scifGames/header23.jpg"), "dziwne", "apokalipsa", "kreatury", "kolory", "2K Games",2019));
            Scifigames.Add(new Gry("Comanche", "", 215, "Futurystyczne", new Uri(sciezka + "scifGames/header44.jpg"), "statki", "moc", "kreatury", "galaktyka", "Ea games", 2019));
            Scifigames.Add(new Gry("Ark", "", 250, "Futurystyczne", new Uri(sciezka + "scifGames/header45.jpg"), "dziwne", "bajkowość", "kreatury", "kolory", "2K Games", 2019));

            Rpggames = new ObservableCollection<Gry>();
            Rpggames.Add(new Gry("Mount blade bannerlord ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header2.jpg"), "potyczki", "multiplayer", "rezbudowa królestwa", "walka", "Piranha bytes", 2000));
            Rpggames.Add(new Gry("Wolcen ", "", 125, "Fantasy", new Uri(sciezka + "rpgGames/header10.jpg"), "potwory", "batalie", "coop", "walka", "Piranha bytes", 2000));
            Rpggames.Add(new Gry("Wiedzmin 3 ", "Główna oś fabularna obraca się wokół kilku oddzielnych wątków. Wśród nich znalazło się poszukiwanie utraconej miłości Geralta oraz inwazja Nilfgaardu na Królestwa Północy. Spróbujemy też powstrzymać tytułowy Dziki Gon, prześladujący wiedźmina zarówno w powieściach, jak i obecny w pierwszej i w nikłym stopniu w drugiej części serii. Wszystkie te główne zadania oferują filmową jakość opowiadanej historii, z rozgałęzionymi ścieżkami wydarzeń, imponującymi scenkami przerywnikowymi i starannie wyreżyserowanymi sekwencjam", 215, "Fantasy", new Uri(sciezka + "rpgGames/header11.jpg"), "Potwory", "Kasta", "Rycerze", "walka", "Cdp red", 2015));
            Rpggames.Add(new Gry("Teso online ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header12.jpg"), "online", "exp", "multiplayer", "walka", "Piranha bytes", 2000));
            Rpggames.Add(new Gry("Greed fall ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header15.jpg"), "coop", "levelowanie", "magia", "zło", "Piranha bytes", 2000));
            Rpggames.Add(new Gry("Gothic 1 ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header21.jpg"), "kasty", "magia", "orowie", "walka", "Piranha bytes", 2000));
            Rpggames.Add(new Gry("Wiedzmin 1 ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header18.jpg"), "Potwory", "Kasta", "Rycerze", "walka","Cdp red",2007));
            Rpggames.Add(new Gry("Wiedzmin 2 ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header16.jpg"), "Potwory", "Kasta", "Rycerze", "walka","Cdp red", 2012));
            Rpggames.Add(new Gry("Gothic 3 ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header24.jpg"), "kasty", "magia", "orowie", "walka","Piranha bytes", 2011));
            Rpggames[2].ZdjTytulowe = new Uri(sciezka + "rpgGames/600255.jpg");
            Rpggames.Add(new Gry("Gothic 4 ", "", 215, "Fantasy", new Uri(sciezka + "rpgGames/header27.jpg"), "kasty", "magia", "orowie", "walka","Piranha bytes",2014));
            Rpggames[2].SciezkaVideo = "https://www.youtube.com/watch?v=ehjJ614QfeM";
            Rpggames[2].sciezKaVideoOkno = @"C:\Users\With3rr\source\repos\Platforma\AplikacjaClient\AplikacjaClient\Movies\Wiedmin 3 Dziki Gon - trailer PL.mp4";


            listapatchy = new ObservableCollection<ZmianyPatche>();
            listapatchy.Add(new ZmianyPatche() { NR_patch = " Wersja:1.0", WprowadzoneZmiany = "Podstawowe funkcje aplikacji tj. logowanie i rejestracja konta na platformie" });
            listapatchy.Add(new ZmianyPatche() { NR_patch = " Wersja:1.1", WprowadzoneZmiany = "Mozliwosc przeszukiwania sklepu z grami podzielonego na różne kategorie wedle różnej charakterystyki i garunku" });
            listapatchy.Add(new ZmianyPatche() { NR_patch = " Wersja:1.2", WprowadzoneZmiany = "Wprowadzenie mozliwosci kupowania kier ze sklepu,dodawania ich do koszyka oraz autoryzacja płatnosci i kupno (jak narazie przy pomocy karty visa)" });
            listapatchy.Add(new ZmianyPatche() { NR_patch = " Wersja:1.3", WprowadzoneZmiany = "Dołączenie kontrolki z listą znajomych z mozliwoscią dodawania znajomych oraz połączenie z bazą danych" });
            listapatchy.Add(new ZmianyPatche() { NR_patch = " Wersja:1.4", WprowadzoneZmiany = "Modernizacja i dodawanie różnych kontrolek pozwalającyh na wykonywanie róznych operacji np.odniesienia do stron internetowych platformy,wprowadzenie zbiorczej listy zmian" });







            Allgames = new List<Gry>();

            Allgames = Racinggames.Concat(Actiongames).ToList().Concat(Strategygames).ToList().Concat(Sportgames).ToList().Concat(Scifigames).ToList().Concat(Rpggames).ToList();

            listofChanges.ItemsSource = listapatchy;
            lastUpdate.DataContext = listapatchy[0];

            gridProdukty1.ItemsSource=Allgames;
            gridProdukty2.ItemsSource = Actiongames;
            gridProdukty3.ItemsSource = Racinggames;
            gridProdukty4.ItemsSource = Strategygames;
            gridProdukty5.ItemsSource = Sportgames;
            gridProdukty6.ItemsSource = Scifigames;
            gridProdukty7.ItemsSource = Rpggames;

            

            gryWkoszyku = new ObservableCollection<Gry>();

            datagridKoszyk.ItemsSource = gryWkoszyku;

            inicjalizacjaWidokow();
            

            










        }
        /// <summary>
        /// Metoda odpowiedziala za nadawanie kazdemu z widoków delegata
        /// </summary>
        /// <remarks>
        /// Delegaty te odpowiedzialne będą za filtrowanie danych wedle ściśle określonych kryteriów.
        /// Delegat dodawany jest również do listy reperezentującej bibliotekę użytkownika
        /// </remarks>
        public void Filtrowanie()
        {

            for (int i = 0; i < 7; i++)
            {
                widoki[i].Filter = FiltrUzytkownika;
               
            }
            


            widok.Filter = WidokBiblioteki;

        }

        /// <summary>
        /// Metoda która określa sposób sortowania wykazu gier
        /// </summary>
        /// <remarks>
        /// Dodatkowo metoda odświeża widoki po każdej zmianie w zelu akutaliazji.
        /// </remarks>
        /// <param name="co">Określa według jakiego paramtery listy gier będą sortowane</param>
        /// <param name="kierunek"> określa kierunek sortowania(rosnący bądź malejący)</param>
        public void Sortowanie(string co,int kierunek)
        {
            ListSortDirection kier = ListSortDirection.Ascending;
            
            if(kierunek==1)
            {
                kier = ListSortDirection.Descending;

            }
            for (int i = 0; i < 7; i++)
            {
                widoki[i].SortDescriptions.Clear();




                widoki[i].SortDescriptions.Add(new SortDescription(co, kier));
               

            }
            refreshowanie();

        }

        /// <summary>
        /// Metoda sortująca wyniki listy biblioteki gier urzytkownika
        /// </summary>
        /// <param name="item">
        /// jest to parametr będoący konkretnym obiektem (grą) wchodzącym w skład biblioteki na względem którego określony będzie warunek określający to czy będzie on mógł być wyświetlany
        /// </param>
        /// <returns>
        /// Wartością zwracaną jest bool która określa czy własciwosci danego obiektu spełniają warunki  nałożonego filtru.
        /// </returns>
        private bool WidokBiblioteki(object item)
        {
            if (String.IsNullOrEmpty(filtrBiblioteki.Text))
            {
                return true;
            }
            else
            {
                return ((item as GryBiblioteka).Nazwa.IndexOf(filtrBiblioteki.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }






        }

        /// <summary>
        /// Metoda odpowiadająca za filtrowanie danych  oraz zwracanie wartości typu bool określającej spełnienie wymagań filtrowania
        /// </summary>
        /// <param name="item">
        /// Parametrym tym jest zmienna typu object która po rzutowaniu na typ klasy Gry pozwoli na dostęp do jej własciwości oraz możliwość ich porównywania z filtrem
        /// </param>
        /// <returns>
        /// Wartością zwracaną jest bool która określa czy własciwosci danego obiektu spełniają warunki  nałożonego filtru.
        /// </returns>

        private bool FiltrUzytkownika(object item)
        {
            if( (String.IsNullOrEmpty(txtfiltrowanie.Text) || ((item as Gry).Nazwa.IndexOf(txtfiltrowanie.Text, StringComparison.OrdinalIgnoreCase) >= 0)) && ((item as Gry).Cena <= Jakacena.Value) && ((item as Gry).Rokwydania>=Convert.ToInt32(rokmin.Text)) && ((item as Gry).Rokwydania <= Convert.ToInt32(rokmax.Text)) && (dodatkowekontrolki1(item,"coop")==true) && (dodatkowekontrolki1(item, "multi") == true) && (dodatkowekontrolki1(item, "open") == true) && (dodatkowekontrolki1(item, "apokalipsa") == true) && (gryJuzPosiadane(item)==false))
            {
                return true;
            }
            else
            {
                return false;
            }

            

            

        }
        /// <summary>
        /// MEtoda ta jest częscią FiltryUzytkownika(jest wywoływana w jej ciele).
        /// </summary>
        /// <remarks>
        /// Metoda ta jest jednym z filtrów.
        /// </remarks>
        /// <param name="item">
        /// Parametrym tym jest zmienna typu object która po rzutowaniu na typ klasy Gry pozwoli na dostęp do jej własciwości oraz możliwość ich porównywania z filtrem
        /// </param>
        /// <returns>
        /// Wartością zwracaną jest bool która określa czy własciwosci danego obiektu spełniają warunki  nałożonego filtru.
        /// </returns>
        public bool gryJuzPosiadane(object itm)
        {
            bool wynik = false;
            if(gryWBibliotece==null)
            {
                
            }
            else
            {
                for (int i = 0; i < listagier.Count; i++)
                {
                    if (listagier[i].Nazwa_gry.Contains((itm as Gry).Nazwa))
                    {
                        wynik = true;
                    }

                }

            }
            
            return wynik;
            

        }
        /// <summary>
        /// MEtoda ta jest częscią FiltryUzytkownika(jest wywoływana w jej ciele).
        /// </summary>
        /// <remarks>
        /// Metoda ta jest jednym z filtrów.
        /// </remarks>
        /// <param name="item">
        /// Parametrym tym jest zmienna typu object która po rzutowaniu na typ klasy Gry pozwoli na dostęp do jej własciwości oraz możliwość ich porównywania z filtrem
        /// </param>
        /// <param name="nazwa">
        /// parametr ten stanowi wartość wedle której filtrowanie będzie przeprowadzane.
        /// </param>
        /// <returns>
        /// Wartością zwracaną jest bool która określa czy własciwosci danego obiektu spełniają warunki  nałożonego filtru.
        /// </returns>
        public bool dodatkowekontrolki1(object itm,string nazwa)
        {
            if(nazwa=="coop")
            {
                if(cbkoop.IsChecked==false)
                {
                    return true;
                }
                else if ((itm as Gry).Podgatunek1 == "coop" || (itm as Gry).Podgatunek2 == "coop" || (itm as Gry).Podgatunek1 == "coop" || (itm as Gry).Podgatunek1 == "coop")
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else if(nazwa=="multi")
            {
                if (cbkmulti.IsChecked == false)
                {
                    return true;
                }
                else if ((itm as Gry).Podgatunek1 == "multiplayer" || (itm as Gry).Podgatunek2 == "multiplayer" || (itm as Gry).Podgatunek1 == "multiplayer" || (itm as Gry).Podgatunek1 == "multiplayer")
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else if (nazwa == "apokalipsa")
            {
                if (cbkapo.IsChecked == false)
                {
                    return true;
                }
                else if ((itm as Gry).Podgatunek1 == "apokalipsa" || (itm as Gry).Podgatunek2 == "apokalipsa" || (itm as Gry).Podgatunek1 == "apokalipsa" || (itm as Gry).Podgatunek1 == "apokalipsa")
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                if (cbkopen.IsChecked == false)
                {
                    return true;
                }
                else if ((itm as Gry).Podgatunek1 == "open world" || (itm as Gry).Podgatunek2 == "open world" || (itm as Gry).Podgatunek1 == "open world" || (itm as Gry).Podgatunek1 == "open world")
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
           

           


        }
       
       


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                
                this.DragMove();
                
            }
            catch (InvalidOperationException )
            {

                
            }
     
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
           
            Application.Current.Shutdown();
        }

        

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {

            if(this.WindowState==WindowState.Normal ||this.WindowState == WindowState.Maximized )
            {
                this.WindowState = WindowState.Minimized;

            }
            else if(this.WindowState==WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
          
        }

       

       

       

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.biedronka.pl/pl/regulamin-serwisu");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
            System.Diagnostics.Process.Start("https://www.facebook.com");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        
            System.Diagnostics.Process.Start("https://www.instagram.com");

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://play.google.com/store/apps/details?id=com.snapchat.android&hl=pl");

        }

        /// <summary>
        /// siema co tam kacper sie nazywam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/explore");

        }

        private void ClickToRegister_Click(object sender, RoutedEventArgs e)
        {
            Rejestracja.Visibility = Visibility.Visible;
            Logowanie.Visibility = Visibility.Hidden;
        }

        public void resetowanie_danych_rejestracji()
        {
            tbEmail.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbLogin.Text = string.Empty;

            cbAgrement.BorderBrush = Brushes.Black;
            tbPassword.BorderBrush = Brushes.Black;
            tbLogin.BorderBrush = Brushes.Black;
            tbEmail.BorderBrush = Brushes.Black;
            errorLogin.Visibility = Visibility.Collapsed;
            cbAgrement.IsChecked = false;
        }
        private void GotSignIn_Click(object sender, RoutedEventArgs e)
        {
            Rejestracja.Visibility = Visibility.Collapsed;
            Logowanie.Visibility = Visibility.Visible;
            resetowanie_danych_rejestracji();

        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if(tbPassword.Text==string.Empty || tbLogin.Text==string.Empty ||tbEmail.Text==string.Empty || cbAgrement.IsChecked==false || tbPassword.Text.Count()<8 || tbLogin.Text.Count() < 5 || tbEmail.Text.Count() < 8 )
            {
                errorLogin.Visibility = Visibility.Visible;

                if (tbPassword.Text == string.Empty || tbPassword.Text.Count() < 8)
                {
                    tbPassword.BorderBrush = Brushes.Red;
                }
                else
                {
                    tbPassword.BorderBrush = Brushes.Black;

                }
                if (tbLogin.Text == string.Empty || tbLogin.Text.Count() < 5)
                {
                    tbLogin.BorderBrush = Brushes.Red;
                    takiNickJest.Visibility = Visibility.Hidden;
                }
                else
                {
                    tbLogin.BorderBrush = Brushes.Black;

                }
                if (tbEmail.Text == string.Empty || tbEmail.Text.Count() < 8)
                {
                    tbEmail.BorderBrush = Brushes.Red;
                    takiEmailJest.Visibility = Visibility.Hidden;
                }
                else
                {
                    tbEmail.BorderBrush = Brushes.Black;

                }
                if(cbAgrement.IsChecked == false)
                {
                    cbAgrement.BorderBrush = Brushes.Red;
                }
                else
                {
                    cbAgrement.BorderBrush = Brushes.Black;

                }
                

            }
            else
            {

                cbAgrement.BorderBrush = Brushes.Black;
                tbEmail.BorderBrush = Brushes.Black;
                tbLogin.BorderBrush = Brushes.Black;
                tbPassword.BorderBrush = Brushes.Black;

                string Nick=tbLogin.Text;
                string Email=tbEmail.Text;
                string haslo = tbPassword.Text;
                if (bazadanych.DaneKontas.Count()==0)
                {
                    DodajUzytkownika(Email, Nick, haslo);
                   

                }
                else
                {
                   

                    DaneKonta konto = bazadanych.DaneKontas.FirstOrDefault(n => n.NazwaUżytkownika == Nick);
                    DaneKonta konto1 = bazadanych.DaneKontas.FirstOrDefault(n => n.EmailAdress == Email);
                    if (konto != null || konto1!=null)
                    {
                        errorLogin.Visibility = Visibility.Visible;




                        if (konto != null)
                        {
                            takiNickJest.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            takiNickJest.Visibility = Visibility.Hidden;

                        }
                        if(konto1 != null)
                        {
                            takiEmailJest.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            takiEmailJest.Visibility = Visibility.Hidden;
                            

                        }



                    }
                    else
                    {
                        takiNickJest.Visibility = Visibility.Hidden;
                        takiEmailJest.Visibility = Visibility.Hidden;
                        DodajUzytkownika(Email, Nick, haslo);
                        resetowanie_danych_rejestracji();

                        PotwierdzenieRejestracji.Visibility = Visibility.Visible;
                        Rejestracja.Visibility = Visibility.Hidden;


                    }
                    
                    
                   
                    
                   

                }
                    
               

               
                







            }
        }
        /// <summary>
        /// Metoda Dodawania nowego urzytkownika do bazy danych wraz z określonymi danymi.
        /// </summary>
        /// <param name="Email">
        /// Określa wymagany email uzytkowinika.
        /// </param>
        /// <param name="Nick">
        /// Określa nickname użytkownika.
        /// </param>
        /// <param name="haslo">
        /// Określa hasło użytkownika
        /// </param>
        public void DodajUzytkownika(string Email,string Nick,string haslo)
        {
            bazadanych.DaneKontas.Add(new DaneKonta { EmailAdress = Email, NazwaUżytkownika = Nick, HasloUzytkownika = haslo });
            bazadanych.SaveChanges();

        }

        private void btprzejdzdoLog_Click(object sender, RoutedEventArgs e)
        {
            Logowanie.Visibility = Visibility.Visible;
            PotwierdzenieRejestracji.Visibility = Visibility.Collapsed;
        }

        private void LogInNow_Click(object sender, RoutedEventArgs e)
        {
            string loginLogowanie = string.Empty;
            string PasswordLogowanie = string.Empty;
            loginLogowanie = emailusernameLogin.Text;
            PasswordLogowanie = passwordLogin.Password;
            
            if(loginLogowanie==string.Empty || PasswordLogowanie==string.Empty)
            {
                bladLogowania.Visibility = Visibility.Visible;
                emailusernameLogin.BorderBrush = Brushes.Red;
                passwordLogin.BorderBrush = Brushes.Red;



            }
            else
            {
                emailusernameLogin.BorderBrush = Brushes.Black;
                passwordLogin.BorderBrush = Brushes.Black;
                bladLogowania.Visibility = Visibility.Collapsed;

                logowanie = null;


                logowanie=bazadanych.DaneKontas.FirstOrDefault(n => (n.NazwaUżytkownika == loginLogowanie || n.EmailAdress==loginLogowanie) && n.HasloUzytkownika == PasswordLogowanie);


                if(logowanie==null)
                {
                    brakUsera.Visibility = Visibility.Visible;
                }
                else
                {
                    listagier = null;
                    listagier = bazadanych.GrywMojejBiblioteces.Where(n => n.Użytkownik == logowanie.Id).ToList();
                    if(listagier.Count==0)
                    {

                    }
                    else
                    {
                        dodwanieDoBiblioteki();




                    }
                    Filtrowanie();
                    this.daneuzytkownika.DataContext = logowanie;
                    





                    CollectionViewSource.GetDefaultView(gridBiblioteka.ItemsSource).Refresh();

                    if(gryWBibliotece.Count>0)
                    {
                        gryBibliotekaOkno.DataContext = gryWBibliotece[0];

                    }
                   


                    emailusernameLogin.Text = string.Empty;
                    passwordLogin.Password = string.Empty;



                    Nick.Text = loginLogowanie;
                    brakUsera.Visibility = Visibility.Collapsed;
                   

                    main2.Visibility = Visibility.Visible;
                  

                }



                    


            }
        }

        /// <summary>
        /// Dodawanie gier do biblioteki
        /// </summary>
        /// <remarks>
        /// Metoda ta służy dodawaniu gier do osobistej biblioteki użytkownika.Dane pobierane są zarówno z 
        /// listy listagier jak i listy Allgames.Konkatenacja poszczególnych danych dwóch listę gier jako tą posiadaną przez usera.
        /// </remarks>
        public void dodwanieDoBiblioteki()
        {
            gryWBibliotece.Clear();
            for (int i = 0; i < listagier.Count; i++)
            {
                for (int j = 0; j < Allgames.Count; j++)
                {
                    if (listagier[i].Nazwa_gry.Contains(Allgames[j].Nazwa))
                    {
                        gryWBibliotece.Add(new GryBiblioteka(Allgames[j].Zdjecie, Allgames[j].Nazwa, listagier[i].godzinywGrze,Allgames[j].ZdjTytulowe,listagier[i].Path,Allgames[j].SciezkaVideo,Allgames[j].Opis,Allgames[j].sciezKaVideoOkno));

                    }

                }

            }

        }
        /// <summary>
        /// Metoda zmieniająca borderthicnes przycików wyboru typu gier w zależnosci od aktualnie wybranego oraz oczywiście podczas samej zmiany.
        /// </summary>
        /// <param name="a">Określa który przycisk z przycisków wyboru typów gier  został naciśnięty </param>
        private void przyciskkolor(int a)
        {
            a = a - 1;

            for (int i = 0; i <= 6; i++)
            {
                if (i != a)
                {


                    przysiski[i].BorderThickness = new Thickness(1);

                }
                else
                {
                    przysiski[i].BorderThickness = new Thickness(4);

                }





            }

        }
        /// <summary>
        /// Metoda odpowiada za wyświetlanie odpowiedniej kontrolki(panelu)grid który symbolizuje dany typ gier.
        /// </summary>
        /// <param name="a">Określa który przycisk z przycisków wyboru typów gier  został naciśnięty </param>
        private void wyswietlanie(int a)
        {
            a = a - 1;

            for (int i = 0; i <= 6; i++)
            {
                if (i != a)
                {


                    gridyGier[i].Visibility = Visibility.Collapsed;

                }
                else
                {
                    gridyGier[i].Visibility = Visibility.Visible ;

                }





            }

        }

        private void leftbt1_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(1);
            wyswietlanie(1);

        }

        private void leftbt2_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(2);
            wyswietlanie(2);

        }

        private void leftbt3_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(3);
            wyswietlanie(3);

        }

        private void leftbt4_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(4);
            wyswietlanie(4);

        }

        private void leftbt5_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(5);
            wyswietlanie(5);

        }

        private void leftbt6_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(6);
            wyswietlanie(6);

        }

        private void leftbt7_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(7);
            wyswietlanie(7);

        }

        private void txtfiltrowanie_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtfiltrowanie.Text==string.Empty)
            {
                refreshowanie();

            }
            
            
        }
        /// <summary>
        /// Działanie metody polega na aktualizowaniu widoków(odświeżaniu ich) w celu aktualizacji wyświetlania wyników.
        /// </summary>
        /// <remarks>
        /// Kazdy z widoków podczas gdy określone filtry zostaną zdefiniowane w innych częsciach kody przez urzytkownika w aplikacji potrzebują akutalizacji w celu wizualizacji zmian w samej aplikacji.Metoda  ta to umożliwia.
        /// </remarks>
        public void refreshowanie()
        {

            CollectionViewSource.GetDefaultView(gridProdukty1.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(gridProdukty2.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(gridProdukty3.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(gridProdukty4.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(gridProdukty5.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(gridProdukty6.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(gridProdukty7.ItemsSource).Refresh();

        }

        

       

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            refreshowanie();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            refreshowanie();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            refreshowanie();

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            textslidera.Text = "300";
            Jakacena.Value = 300;
            rokmin.Text = "2000";
            rokmax.Text = "2020";
            cbkoop.IsChecked = false;
            cbkmulti.IsChecked = false;
            cbkopen.IsChecked = false;
            cbkapo.IsChecked = false;

            


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            gProfile.Visibility = Visibility.Collapsed;
            gridplacenie.Visibility = Visibility.Collapsed;
            lftpanel.Visibility = Visibility.Visible;
            gridpc.Visibility = Visibility.Visible;
            gridBasket.Visibility = Visibility.Collapsed;
            lftpanel.Visibility = Visibility.Visible;
            gryBibliotekaOkno.Visibility = Visibility.Collapsed;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

           
        }

        private void btndodajDoKosz1_Click(object sender, RoutedEventArgs e)
        {
            gryWkoszyku.Add((Gry)gridProdukty1.SelectedItem);

        }


        private void btndodajDoKosz2_Click(object sender, RoutedEventArgs e)
        {
            gryWkoszyku.Add((Gry)gridProdukty2.SelectedItem);

        }

        
        private void btndodajDoKosz3_Click(object sender, RoutedEventArgs e)
        {
            bool prawda = true;
            if (gryWBibliotece.Count == 0)
            {
                gryWkoszyku.Add((Gry)gridProdukty3.SelectedItem);

            }
            else
            {
                for (int i = 0; i < gryWBibliotece.Count; i++)
                {
                    if(gryWBibliotece[i].Nazwa==((Gry)gridProdukty3.SelectedItem).Nazwa)
                    {
                        prawda = false;
                        
                    }

                }
                if(prawda==true)
                {
                    gryWkoszyku.Add((Gry)gridProdukty3.SelectedItem);

                }


                

            }

            


            

        }

        private void btndodajDoKosz4_Click(object sender, RoutedEventArgs e)
        {
            gryWkoszyku.Add((Gry)gridProdukty4.SelectedItem);

        }

        private void btndodajDoKosz5_Click(object sender, RoutedEventArgs e)
        {
            gryWkoszyku.Add((Gry)gridProdukty5.SelectedItem);

        }
        private void btndodajDoKosz6_Click(object sender, RoutedEventArgs e)
        {
            gryWkoszyku.Add((Gry)gridProdukty6.SelectedItem);

        }

        private void btndodajDoKosz7_Click(object sender, RoutedEventArgs e)
        {
            gryWkoszyku.Add((Gry)gridProdukty7.SelectedItem);

        }
        /// <summary>
        /// Obliczanie całkiwitej ceny Zamówienia które znajduje się w koszyku na podstawie sumy cen gier które się tam znajdują.
        /// </summary>
        private void obliczanieFullPrice()
        {
            max = 0;
            
            for (int i = 0; i < gryWkoszyku.Count; i++)
            {
                max += gryWkoszyku[i].Cena;


            }
            
            cenaMax.Content = "Full price: " + max + "$";

        }



        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            cenaMax.Content = "Full price: " + 0 + "$";
            refresz();
            obliczanieFullPrice();
            gryBibliotekaOkno.Visibility = Visibility.Collapsed;
            gProfile.Visibility = Visibility.Collapsed;





            CollectionViewSource.GetDefaultView(datagridKoszyk.ItemsSource).Refresh();
            gridBasket.Visibility = Visibility.Visible;
            gridpc.Visibility = Visibility.Collapsed;
            lftpanel.Visibility = Visibility.Collapsed;


        }

        /// <summary>
        /// Metoda nie pozwalająca na duplikację kupowanych gier
        /// </summary>
        /// <remarks>
        /// Metoda ta ma zapobiec temu że 2 lub wiecej takich samych gier zostanie dodanych do koszyka co powinno być nie możlwe.
        /// </remarks>
        private void refresz()
        {
            int a = gryWkoszyku.Count;
            int i = 0;
            while (i < a)
            {
                for (int j = 0; j < gryWkoszyku.Count; j++)
                {
                    for (int s = 0; s < gryWkoszyku.Count; s++)
                    {
                        if (gryWkoszyku[s].Nazwa == gryWkoszyku[j].Nazwa && s != j)
                        {

                            gryWkoszyku.RemoveAt(s);
                            break;

                        }

                    }

                }

                i++;

            }
            

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Gry produktZlisty = datagridKoszyk.SelectedItem as Gry;
            MessageBoxResult odpowiedz = MessageBox.Show("Czy wykasowac produkt:" + produktZlisty.ToString() + "?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (odpowiedz == MessageBoxResult.Yes)
            {
                gryWkoszyku.Remove(produktZlisty);
            }
            obliczanieFullPrice();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (gryWkoszyku.Count == 0)
            {

            }
            else
            {
                MessageBoxResult odpowiedz = MessageBox.Show("Czy wykasowac zamówienie:" + "?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (odpowiedz == MessageBoxResult.Yes)
                {
                    gryWkoszyku.Clear();
                    max = 0;
                    cenaMax.Content = "Full price:       " + max + "$";

                }

            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if(max>0)
            {
                gridBasket.Visibility = Visibility.Collapsed;
                gridplacenie.Visibility = Visibility.Visible;

            }
            

        }

       

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Karty karta = null;
            karta = bazadanych.Karties.FirstOrDefault(n => n.Imie == imiePlacenie.Text && n.Nazwisko==nazwiskoPlacenie.Text && n.nrKarty== nrkartyPlacenie.Text && n.nrID== kodPlacenie.Text);
            if(karta!=null)
            {
                if(karta.Stan>=max)
                {

                    resetowaniedanychplacenia();
                    niepoprawnaKarta.Visibility = Visibility.Collapsed;
                    karta.Stan -= max;
                    bazadanych.SaveChanges();
                    for (int i = 0; i < gryWkoszyku.Count; i++)
                    {
                        bazadanych.GrywMojejBiblioteces.Add(new GrywMojejBibliotece { godzinywGrze = 0, Nazwa_gry = gryWkoszyku[i].Nazwa, Użytkownik = logowanie.Id });
                        bazadanych.HistoriaZakupows.Add(new HistoriaZakupow { Id_uzytkownika = logowanie.Id, Cena = gryWkoszyku[i].Cena.ToString(), Nazwa_prod = gryWkoszyku[i].Nazwa, Data_zakupu = DateTime.Today.ToString("M/d/yyyy")}); 
                    }
                    bazadanych.SaveChanges();
                    gryWBibliotece.Clear();

                    listagier = bazadanych.GrywMojejBiblioteces.Where(n => n.Użytkownik == logowanie.Id).ToList();

                    dodwanieDoBiblioteki();
                    gryWkoszyku.Clear();
                   
                    CollectionViewSource.GetDefaultView(datagridKoszyk.ItemsSource).Refresh();



                    gridplacenie.Visibility = Visibility.Collapsed;
                    potwiedzenieplacenia.Visibility = Visibility.Visible;
                    gridpc.Visibility = Visibility.Visible;
                    lftpanel.Visibility = Visibility.Visible;
                    refreshowanie();
                    CollectionViewSource.GetDefaultView(gridBiblioteka.ItemsSource).Refresh();
                    gryBibliotekaOkno.Visibility = Visibility.Collapsed;




                }
                else
                {
                    niepoprawnaKarta.Text = "Brak wystarczających środków na końcie";
                    niepoprawnaKarta.Visibility = Visibility.Visible;

                }
            }
            else
            {
                niepoprawnaKarta.Text = "Karta błędna lub nieprawidłowe dane";
                niepoprawnaKarta.Visibility = Visibility.Visible;
            }




        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            potwiedzenieplacenia.Visibility = Visibility.Collapsed;
            gridpc.Visibility = Visibility.Visible;
            lftpanel.Visibility = Visibility.Visible;
            gryBibliotekaOkno.Visibility = Visibility.Collapsed;


        }

        private void gridBiblioteka_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            gProfile.Visibility = Visibility.Collapsed;

            video.Stop();

            gryBibliotekaOkno.DataContext = (gridBiblioteka.SelectedItem as Gry);
            gridpc.Visibility = Visibility.Collapsed;
            lftpanel.Visibility = Visibility.Collapsed;
            gridBasket.Visibility = Visibility.Collapsed;
            gryBibliotekaOkno.Visibility = Visibility.Visible;




        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();

            }
            catch (InvalidOperationException)
            {


            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if(CzyoknoON.Wlaczany==false)
            {
                WindowFriends secwindow = new WindowFriends(logowanie.Id);
                secwindow.Show();

            }
           

        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(gridBiblioteka.ItemsSource).Refresh();

        }

        private void filtrBiblioteki_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(filtrBiblioteki.Text==String.Empty)
            {
                CollectionViewSource.GetDefaultView(gridBiblioteka.ItemsSource).Refresh();

            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com");
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
       
            System.Diagnostics.Process.Start("https://www.youtube.com");

        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
           
            
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://help.steampowered.com/pl/");

        }

        private void potwiedzenieklucza_Click(object sender, RoutedEventArgs e)
        {
           


            if (kluczwpisywanie.Text==string.Empty || kluczwpisywanie.Text.Length<9 || kluczwpisywanie.Text.Length >9)
            {
                zlykod.Visibility = Visibility.Visible;

            }
            else
            {
                if(kody!=null)
                {
                    kody = null;
                }
                kody = bazadanych.Kodies.FirstOrDefault(n => n.Kod_gry == kluczwpisywanie.Text);
                if(kody!=null)
                {
                    bool posiadanie=false;
                    zlykod.Visibility = Visibility.Collapsed;
                    for (int i = 0; i < listagier.Count; i++)
                    {
                        


                        if(listagier[i].Nazwa_gry.Contains(kody.Nazwa_gry))
                        {
                            
                            posiadanie = true;


                        }

                    }
                    if(posiadanie ==false)
                    {
                        bazadanych.GrywMojejBiblioteces.Add(new GrywMojejBibliotece { godzinywGrze = 0, Nazwa_gry = kody.Nazwa_gry, Użytkownik = logowanie.Id });
                        bazadanych.Kodies.Remove(kody);
                        bazadanych.SaveChanges();
                        listagier = bazadanych.GrywMojejBiblioteces.Where(n => n.Użytkownik == logowanie.Id).ToList();
                        dodwanieDoBiblioteki();
                        CollectionViewSource.GetDefaultView(gridBiblioteka.ItemsSource).Refresh();
                        nazwaGrypotwiedzeniekodu.Text = kody.Nazwa_gry;
                        gridpc.Visibility = Visibility.Visible;
                        lftpanel.Visibility = Visibility.Visible;
                        gryBibliotekaOkno.Visibility = Visibility.Collapsed;

                        potwiedzeniekodu.Visibility = Visibility.Visible; ;
                        lkod.IsOpen = false;
                        menukont.IsOpen = false;

                    }
                    else
                    {
                        zlykod.Visibility = Visibility.Visible;
                        

                    }




                }
                else
                {
                    zlykod.Visibility = Visibility.Visible;


                }
                
                



                
            }
            kluczwpisywanie.Text =string.Empty;
            



        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            potwiedzeniekodu.Visibility = Visibility.Collapsed;
        }

        private void wyborsortowania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(wyborsortowania.SelectedIndex==0)
            {
                


            }
            else
            {
                if(wyborsortowania.SelectedIndex == 1)
                {
                    Sortowanie("Cena", 0);
                    


                }
                else if (wyborsortowania.SelectedIndex == 2)
                {
                    Sortowanie("Cena", 1);
                    

                }
                else if (wyborsortowania.SelectedIndex == 3)
                {
                    Sortowanie("Rokwydania", 0);


                }
                else if (wyborsortowania.SelectedIndex == 4)
                {
                    Sortowanie("Nazwa", 0);


                }
                else if (wyborsortowania.SelectedIndex == 5)
                {
                    Sortowanie("Nazwa", 1);


                }

            }
            
           

           
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
           
            if(gryWBibliotece.Count>0)
            {
                gProfile.Visibility = Visibility.Collapsed;
                lftpanel.Visibility = Visibility.Collapsed;
                gridpc.Visibility = Visibility.Collapsed;
                gridBasket.Visibility = Visibility.Collapsed;
                gryBibliotekaOkno.Visibility = Visibility.Visible;
                gridplacenie.Visibility = Visibility.Collapsed;

            }
          
            
            
            
        }

       

        private void gridBiblioteka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            video.Stop();
           

            if (gryWBibliotece.Count > 0)
            {
                gProfile.Visibility = Visibility.Collapsed;
                lftpanel.Visibility = Visibility.Collapsed;
                gridpc.Visibility = Visibility.Collapsed;
                gridBasket.Visibility = Visibility.Collapsed;
                gryBibliotekaOkno.Visibility = Visibility.Visible;
                gridplacenie.Visibility = Visibility.Collapsed;

            }

        }
        public void resetowaniedanychplacenia()
        {
            imiePlacenie.Text = string.Empty;
            nazwiskoPlacenie.Text = string.Empty;
            nrkartyPlacenie.Text = string.Empty;
            kodPlacenie.Text = string.Empty;
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {

            gridplacenie.Visibility = Visibility.Collapsed;
            gridBasket.Visibility = Visibility.Visible;
            resetowaniedanychplacenia();
            niepoprawnaKarta.Visibility = Visibility.Collapsed;

        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            spsciezka.Visibility = Visibility.Visible;
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            spsciezka.Visibility = Visibility.Collapsed;
            tbsciezka.Text = string.Empty;
        }

        private void potwiedzeniesciezki_Click(object sender, RoutedEventArgs e)
        {
            
            
             updateSciezki = null;
             string sciezka= tbsciezka.Text; ;

             (gridBiblioteka.SelectedItem as GryBiblioteka).SciezkaGry = tbsciezka.Text;
            string nazwa = (gridBiblioteka.SelectedItem as GryBiblioteka).Nazwa;


             updateSciezki = bazadanych.GrywMojejBiblioteces.FirstOrDefault(n => (n.Nazwa_gry==nazwa && n.Użytkownik==logowanie.Id));
             if (updateSciezki != null)
             {
                 updateSciezki.Path = sciezka; 
                 bazadanych.SaveChanges(); ;


             }
            spsciezka.Visibility = Visibility.Collapsed;
            tbsciezka.Text = string.Empty;












        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            if(File.Exists((gridBiblioteka.SelectedItem as GryBiblioteka).SciezkaGry))
            {
                System.Diagnostics.Process.Start((gridBiblioteka.SelectedItem as GryBiblioteka).SciezkaGry);

            }
         
            

            
            
        }

        private void VideoPlaY(object sender, RoutedEventArgs e)
        {
            btstop.Visibility = Visibility.Visible;
            btplay.Visibility = Visibility.Collapsed;
            video.Play();
            if (timer != null)
            {
                timer.Start();
            }
        }

        private void VideoPause(object sender, RoutedEventArgs e)
        {
            btplay.Visibility = Visibility.Visible;
            btstop.Visibility = Visibility.Collapsed;
            video.Pause();
            if(timer!=null)
            {
                timer.Stop();
            }
        }

        private void VideoStop(object sender, RoutedEventArgs e)
        {
            video.Stop();
            if (timer != null)
            {
                timer.Stop();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            video.ScrubbingEnabled = true;
            video.Stop();
        }

        private void video_MediaOpened(object sender, RoutedEventArgs e)
        {
            acctime.Maximum = video.NaturalDuration.TimeSpan.TotalSeconds;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            

            

        }
        void timer_Tick(object sender, EventArgs e)
        {
            acctime.Value = video.Position.TotalSeconds;
        }

        private void acctime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            video.Position = TimeSpan.FromSeconds(acctime.Value);
        }

        private void acctime_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            video.Pause();
            if (timer != null)
            {
                timer.Stop();
            }

        }

        private void acctime_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            video.Play();
            timer.Start();

        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            gProfile.Visibility = Visibility.Visible;
            gryBibliotekaOkno.Visibility = Visibility.Collapsed;
            lftpanel.Visibility = Visibility.Collapsed;
            gridpc.Visibility = Visibility.Collapsed;
            gridBasket.Visibility = Visibility.Collapsed;
            gridplacenie.Visibility = Visibility.Collapsed;

            listazakupow = null;
            listazakupow = bazadanych.HistoriaZakupows.Where(n => n.Id_uzytkownika== logowanie.Id).ToList();


            listaZakupoowDoprzeglodania.Clear();
            
            for (int i = 0; i < listazakupow.Count(); i++)
            {
                listaZakupoowDoprzeglodania.Add(new HistoriaZakupow { Nazwa_prod = listazakupow[i].Nazwa_prod, Data_zakupu = listazakupow[i].Data_zakupu, Cena = listazakupow[i].Cena });

            }
            historiaZak.ItemsSource = listaZakupoowDoprzeglodania;

            CollectionViewSource.GetDefaultView(datagridKoszyk.ItemsSource).Refresh();

            
           
        }
       

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            scrollOrderhistory.Visibility = Visibility.Visible;
            spzmianahasla.Visibility = Visibility.Collapsed;
            daneuzytkownika.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            spzmianahasla.Visibility = Visibility.Visible;
            scrollOrderhistory.Visibility = Visibility.Collapsed;
            daneuzytkownika.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            if(newPassword.Text.Length<8)
            {
                bladzmianyhasla.Visibility = Visibility.Visible;
            }
            else
            {
                bladzmianyhasla.Visibility = Visibility.Collapsed;
                logowanie.HasloUzytkownika = newPassword.Text;
                bazadanych.SaveChanges();
               
                newPassword.Text = string.Empty;
                potwiedzenieZmianyHasla.Visibility = Visibility.Visible;


            }
        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            spzmianahasla.Visibility = Visibility.Collapsed;
            daneuzytkownika.Visibility = Visibility.Visible;
            scrollOrderhistory.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_26(object sender, RoutedEventArgs e)
        {
            logowanie.Imie = imieZmiana.Text;
            logowanie.Nazwisko = nazwiskoZmiana.Text;
            logowanie.Narodowosc = NarodowoscZmiana.Text;
            logowanie.Hobby = HobbySZmiana.Text;
            bazadanych.SaveChanges();
            potwiedzenieZmianydanych.Visibility = Visibility.Visible;


        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            if((gridBiblioteka.SelectedItem as GryBiblioteka).SciezkaVideo!=null)
            {
                System.Diagnostics.Process.Start((gridBiblioteka.SelectedItem as GryBiblioteka).SciezkaVideo.ToString());

            }
            
                
        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            potwiedzenieZmianydanych.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            potwiedzenieZmianyHasla.Visibility = Visibility.Collapsed;
        }

        private void Jakacena_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(Jakacena.Value==300)
            {

            }
            else
            {
                textslidera.Text = ((int)Jakacena.Value).ToString();

            }
            
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            zlykod.Visibility = Visibility.Collapsed;
        }
    }
}
