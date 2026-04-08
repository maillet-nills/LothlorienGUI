using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LothlorienGUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void AddOnPlantButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var plantInputWindow = new AddPlantWindow();
        
        await plantInputWindow.ShowDialog(this);
    }
}