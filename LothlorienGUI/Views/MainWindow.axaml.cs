using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using LothlorienGUI.ViewModels;

namespace LothlorienGUI.Views;

public partial class MainWindow : Window
{
    private string[] plantNames = new string[100];
    private DateTimeOffset[]  plantDates = new DateTimeOffset[100];
    private string[] plantLocations = new string[100];
    private string[] plantExposures = new string[100];
    private int[] plantWateringFrequencies = new int[100];

    private int plantTotal;
    public MainWindow()
    {
        InitializeComponent();
        plantTotal = 0;
    }

    private async void AddOnPlantButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var plantInputWindow = new AddPlantWindow();
        
        await plantInputWindow.ShowDialog(this);

        if (plantInputWindow.confirmed)
        {
            plantNames[plantTotal] = plantInputWindow.plantName;
            plantDates[plantTotal] = plantInputWindow.purchaseDate ?? DateTimeOffset.Now;
            plantLocations[plantTotal] = plantInputWindow.plantLocation;
            plantExposures[plantTotal] = plantInputWindow.plantExposure;
            plantWateringFrequencies[plantTotal] = plantInputWindow.wateringFrequency;
            
            Console.WriteLine("=== New plant added ===");
            Console.WriteLine($"Name/ variety : {plantNames[plantTotal]}");
            Console.WriteLine($"Purchased Date : {plantDates[plantTotal]}");
            Console.WriteLine($"Location : {plantLocations[plantTotal]}");
            Console.WriteLine($"Watering : every {plantWateringFrequencies[plantTotal]} days");
            Console.WriteLine($"Exposure : {plantExposures[plantTotal]}");
            
            plantTotal++;
            Console.WriteLine($"Plant total : {plantTotal}");
            
            if (DataContext is MainWindowViewModel vm)
                vm.PlantCount = plantTotal;
        }
    }
}