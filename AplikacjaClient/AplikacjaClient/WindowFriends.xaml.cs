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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace AplikacjaClient
{


    /// <summary>
    /// Klasa WindowsFriend jako klasa określająca Okno aplikacji do zarządzania urzytkownikami(przyjaciumi).
    /// </summary>
    /// <remarks>
    /// Klasa ta określa aplikację która pozwala na dostęp do bazy danych i określanie przyjaciół danego zalogowanego do aplikacji urzytkownika.
    /// Kolejnymi możlwościami będzie możliwość dodawania znajomych oraz ich usuwania.
    /// </remarks>
    public partial class WindowFriends : Window
    {
        /// <value>
        /// Własciwość ta określa Id urzytkownika który aktualnie zalogowany jest do podstawowej aplikacji (platformy z grami).
        /// 
        /// </value>
        public int Id { get; set; }


        /// <summary>
        /// Zmienna która pozwala na dostęp do bazy danych i pobieranie oraz zapisywanie do niej odpowiedznich wartości.
        /// </summary>
        private BazaUżytkownikowEntities bazadanych = null;

        /// <summary>
        /// Zmienna która typu Lista która odpowiadała będzie za listę przyjaciół danego użytkownika.
        /// </summary>
        private List<Friend> listaprzyjaciol=null;

        /// <summary>
        /// Zmienna typu CollectionView odpowiadać będzie za manipulacje na filtrach dla danego obiektu(w tym przypadku datagrid) po uprzednim przypisaniu do tej zmiennej widoku przez metode GetDefaultView.
        /// </summary>
        CollectionView widok = null;


        private DaneKonta czyjestPrzyjaciel = null;

        private int zmiennauzytkownika ;

        /// <summary>
        /// Metoda główna Okna
        /// </summary>
        /// <remarks>
        /// Do funkcji tej metody należ m.in. stworzenie instancji(objektu) bazy danych,inicjalizacja poszczególnych elementów startowych aplikacji,wywoływanie metody określającej znajomych danego urzytkownika na podstawie Id.
        /// </remarks>
        public WindowFriends(int a)
        {
            bazadanych = new BazaUżytkownikowEntities();
            InitializeComponent();
            listaprzyjaciol = new List<Friend>();
            inicjalizacjaListyfriends(a);
            zmiennauzytkownika = a;

            CzyoknoON.Wlaczany = true;





        }
        /// <summary>
        /// metoda która inicjalizuje listę "listaprzyjaciol" objektami typu Friend 
        /// </summary>
        /// <remarks>
        ///Działanie tej metody polega na tym że pobierane są (w postaci listy) obiekty których Id_kodo pasuje do id urzytkownika kożystającego z aplikacji.Id_kogo jest to własciwość która jest jednocześnie kluczem obcym klucza Id_ z tabeli DaneKonta.
        ///Kolejnym etapem metody jest przypisanie Domyślnego widoku do zmiennej CollevtionView widok która posłuży za możliwość filtrowania danych.
        ///Ostatnim ktokiem jest przypisanie delegata do właściwości Filter widoku.
        /// </remarks>
        /// <param name="s">
        /// Oznacza zmienną typu int określającą Id urzytkownika.
        /// 
        /// </param>
        public void inicjalizacjaListyfriends(int s)
        {

            listaprzyjaciol=bazadanych.Friends.Where(n => n.Id_kogo == s).ToList();
            gridFriends.ItemsSource = listaprzyjaciol;
            CollectionViewSource.GetDefaultView(gridFriends.ItemsSource).Refresh();
            widok=((CollectionView)CollectionViewSource.GetDefaultView(gridFriends.ItemsSource));
            widok.Filter = Filtr;





        }
        /// <summary>
        /// Metoda określająca spełnienie warunków filtru.
        /// </summary>
        /// <remarks>
        /// Metoda ta określa na podstawie wytycznych i warunków wewnątrz jej czy dany obiekt będący obiektem typu Friend spełnia określone warunki.
        ///Nie spełnienie ich będzie oznaczało nie wyswietlanie tego urzytkownika w aplikacji.
        /// </remarks>
        /// <param name="a">
        /// Oznacza on zmienną typu object która będzie kontretnym objektem typu Friend wyswietlanym przy pomocy datagrid.
        /// 
        /// </param>

        public bool Filtr(object a)
        {
            if(String.IsNullOrEmpty(filtrowanieFriends.Text))
            {
                return true;
            }
            else
            {
                return ((a as Friend).Nick.IndexOf(filtrowanieFriends.Text,StringComparison.OrdinalIgnoreCase) >=0);
            }

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CzyoknoON.Wlaczany = false;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();

            }
            catch (InvalidOperationException)
            {


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((CollectionView)CollectionViewSource.GetDefaultView(gridFriends.ItemsSource)).Refresh();

        }

        private void filtrowanieFriends_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filtrowanieFriends.Text == string.Empty)
            {
                ((CollectionView)CollectionViewSource.GetDefaultView(gridFriends.ItemsSource)).Refresh();


            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dodajznaj.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if(wpisywanianowegoZnaj.Text==string.Empty)
            {

                bladznajomego.Text = "Incorrect data";
                bladznajomego.Visibility = Visibility.Visible;

                wpisywanianowegoZnaj.BorderBrush = Brushes.Red;


            }
            else
            {
               
                
                czyjestPrzyjaciel = null;
                czyjestPrzyjaciel = bazadanych.DaneKontas.FirstOrDefault(n => n.NazwaUżytkownika == wpisywanianowegoZnaj.Text);
                if(czyjestPrzyjaciel!=null)
                {
                    if(czyjestPrzyjaciel.Id!= zmiennauzytkownika)
                    {

                        bool czyistniejektosTaki = false;
                        for (int i = 0; i < listaprzyjaciol.Count; i++)
                        {
                            if(listaprzyjaciol[i].Nick.Contains(wpisywanianowegoZnaj.Text))
                            {
                                czyistniejektosTaki = true;
                            }

                        }
                        if(czyistniejektosTaki==false)
                        {
                            wpisywanianowegoZnaj.BorderBrush = Brushes.Black;
                            bazadanych.Friends.Add(new Friend { Id_kogo = zmiennauzytkownika, Nick = wpisywanianowegoZnaj.Text });
                            bazadanych.SaveChanges();
                            listaprzyjaciol = bazadanych.Friends.Where(n => n.Id_kogo == zmiennauzytkownika).ToList();
                            gridFriends.ItemsSource = listaprzyjaciol;

                            ((CollectionView)CollectionViewSource.GetDefaultView(gridFriends.ItemsSource)).Refresh();

                            bladznajomego.Visibility = Visibility.Collapsed;
                            wpisywanianowegoZnaj.BorderBrush = Brushes.Black;

                           
                            bladznajomego.Visibility = Visibility.Collapsed;



                        }
                        
                        


                    }
                    


                }
                else
                {
                    bladznajomego.Text = "Incorrect data";
                    bladznajomego.Visibility = Visibility.Visible;
                }



            }
            
            
            

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            bladznajomego.Visibility = Visibility.Collapsed;
            wpisywanianowegoZnaj.Text = string.Empty;
            dodajznaj.Visibility = Visibility.Collapsed;
        }

        private void usuwanieZnajomego_Click(object sender, RoutedEventArgs e)
        {
            Friend dousuniecia = null;
            dousuniecia = gridFriends.SelectedItem as Friend;

            
            bazadanych.Friends.Remove(dousuniecia);
            listaprzyjaciol.Remove(dousuniecia);
           

            bazadanych.SaveChanges();
            ((CollectionView)CollectionViewSource.GetDefaultView(gridFriends.ItemsSource)).Refresh();
        }
    }
}
