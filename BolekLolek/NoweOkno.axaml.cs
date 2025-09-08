using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BolekLolek;

public partial class NoweOkno : Window
{
    public NoweOkno(List<string> zadaniaDlaDaty)
    {
        InitializeComponent();
        zadaniaListBox.ItemsSource = zadaniaDlaDaty;
    }
    
}