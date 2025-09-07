using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BolekLolek;

public partial class MainWindow : Window
{
    
    private ObservableCollection<string> zadania = new ObservableCollection<string>();

    public MainWindow()
    {
        InitializeComponent();
        zadanieLista.ItemsSource = zadania;
        zadanieButton.Click += DodajZadanie;
    }

    private void DodajZadanie(object? sender, RoutedEventArgs e)
    {
        string zadanie = zadanieDodaj.Text;
        var wykonawca = (wykonawcaComboBox.SelectedItem as ComboBoxItem).Content.ToString();
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
        

        if (!string.IsNullOrWhiteSpace(zadanie))
        {
            string nazwaZ = nazwaZadania.Text;

            string tekst = $"{wykonawca} - {nazwaZ}, priorytet: {priorytet}. Dodatkowe informacje: {opcjeCB}";
            zadania.Add(tekst);
        }
    }
}