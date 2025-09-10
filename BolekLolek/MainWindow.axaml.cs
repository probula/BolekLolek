using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace BolekLolek;

public partial class MainWindow : Window
{
    
    private ObservableCollection<string> zadania = new ObservableCollection<string>();

    public MainWindow()
    {
        InitializeComponent();
        zadanieLista.ItemsSource = zadania;
        zadanieButton.Click += DodajZadanie;

        zadanieLista.DoubleTapped += usunZadanie;

        calendar.SelectedDatesChanged += kalendarzData;

        noweOkno.Click += NoweOkno_Click;
    }

    private void DodajZadanie(object? sender, RoutedEventArgs e)
    {
        var wykonawca = (wykonawcaComboBox.SelectedItem as ComboBoxItem).Content.ToString();

        string zdjecie = wykonawca switch
        {
            "Bolek" => "Assets/bolek.png",
            "Lolek" => "Assets/lolek.png",
        };

        wykonawcaZdj.Source = new Avalonia.Media.Imaging.Bitmap(zdjecie);
        
        string priorytet = "";
        if (rb1.IsChecked == true)
        {
            priorytet = "niski";
        }
        else if (rb2.IsChecked == true)
        {
            priorytet = "normalny";
        }
        else if (rb3.IsChecked == true)
        {
            priorytet = "wysoki";
        }

        bool naDworze = NaDworze.IsChecked ?? false;
        bool sprzet = Sprzet.IsChecked ?? false;
        bool pomoc = Koledzy.IsChecked ?? false;
        
        List<string> zaznaczoneCB = new List<string>();
        
        if (naDworze) zaznaczoneCB.Add("na dworze");
        if (sprzet) zaznaczoneCB.Add("sprzet");
        if (pomoc) zaznaczoneCB.Add("potrzebna pomoc kolegów");
        
        string opcjeCB = string.Join(", ", zaznaczoneCB);
        
        string nazwaZ = nazwaZadania.Text;

        string tekst = $"{wykonawca} - {nazwaZ}, priorytet: {priorytet}. Dodatkowe informacje: {opcjeCB}, data: {wybranaData}";
        zadania.Add(tekst);
        
    }

    private void usunZadanie(object? sender, RoutedEventArgs e)
    {
        if (zadanieLista.SelectedItem is string zadanie)
        {
            zadania.Remove(zadanie);
        }
    }

    private DateTime? wybranaData;
    private void kalendarzData(object sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        
        if (calendar.SelectedDate.HasValue)
        {
            wybranaData = calendar.SelectedDate.Value;
        }
        else
        {
            wybranaData = null;
        }
    }

    private void NoweOkno_Click(object sender, RoutedEventArgs e)
    {
        List<string>? zadaniaDlaDaty;

        if (calendar2.SelectedDate.HasValue)
        {

            DateTime wybranaData2 = calendar2.SelectedDate.Value;

            zadaniaDlaDaty = new List<string>();
            foreach (var zad in zadania)
            {
                if (zad.Contains(wybranaData2.ToShortDateString()))
                {
                    zadaniaDlaDaty.Add(zad);
                }
            }

            var window = new NoweOkno(zadaniaDlaDaty);
            window.Show();
        }
        else{
            Console.WriteLine("Brak danych!");
        }
    }
}