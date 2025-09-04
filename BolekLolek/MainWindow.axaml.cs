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
        string zadanie = zadanieDodaj.Text?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(zadanie))
        {
            zadania.Add(zadanie);
            zadanieDodaj.Text = "";
        }
    }
}