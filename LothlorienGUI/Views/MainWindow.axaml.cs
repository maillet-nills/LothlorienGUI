using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Media;
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

    private Border CreatePlantCard(int index)
    {
        var plantCard = new Border();
            plantCard.Width = 180;
            plantCard.Height = 180;
            plantCard.Margin = new Thickness(8);
            plantCard.CornerRadius = new CornerRadius(12);
            plantCard.Background = new SolidColorBrush(Color.Parse("#F4F9EE"));
            plantCard.BorderBrush = new SolidColorBrush(Color.Parse("#D0E8B0"));
            plantCard.BorderThickness = new Thickness(1);
            plantCard.BoxShadow = BoxShadows.Parse("0 2 8 0 #14000000");

            var plantCardButton = new Button();
            plantCardButton.Click += DisplayPlantInfo_OnClick;
            plantCardButton.Width = 180;
            plantCardButton.Height = 180;
            plantCardButton.CornerRadius = new CornerRadius(12);
            plantCardButton.Background = new SolidColorBrush(Color.Parse("Transparent"));
            plantCardButton.VerticalAlignment = VerticalAlignment.Center;
            plantCardButton.HorizontalAlignment = HorizontalAlignment.Center;

            var plantCardContent = new StackPanel();
            plantCardContent.VerticalAlignment = VerticalAlignment.Center;
            plantCardContent.HorizontalAlignment =  HorizontalAlignment.Center;
            plantCardContent.Spacing = 6;
            
            var iconText = new TextBlock();
            iconText.Text = "🌿";
            iconText.FontSize = 26;
            iconText.HorizontalAlignment = HorizontalAlignment.Center;
            
            var nameText = new TextBlock();
            nameText.Text = plantNames[index];
            nameText.FontSize = 14;
            nameText.FontWeight = FontWeight.Bold;
            nameText.Foreground = new SolidColorBrush(Color.Parse("#3A5A2A"));
            nameText.HorizontalAlignment = HorizontalAlignment.Center;
            nameText.TextAlignment = TextAlignment.Center;
            nameText.TextWrapping = TextWrapping.Wrap;

            var locationText = new TextBlock();
            locationText.Text = plantLocations[index];
            locationText.FontSize = 13;
            locationText.Foreground = new SolidColorBrush(Color.Parse("#90B070"));
            locationText.HorizontalAlignment = HorizontalAlignment.Center;

            var dateText = new TextBlock();
            dateText.Text = plantDates[index].ToString("dd/MM/yyyy");
            dateText.FontSize = 13;
            dateText.Foreground = new SolidColorBrush(Color.Parse("#90B070"));
            dateText.HorizontalAlignment = HorizontalAlignment.Center;
            
            plantCard.Child = plantCardButton;
            plantCardButton.Content = plantCardContent;
            plantCardContent.Children.Add(iconText);
            plantCardContent.Children.Add(nameText);
            plantCardContent.Children.Add(locationText);
            plantCardContent.Children.Add(dateText);

            plantCardButton.Tag = index;

            return plantCard;
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
            
            plantTotal++;
            
            if (DataContext is MainWindowViewModel vm)
                vm.PlantCount = plantTotal;
            
            CardPanel.Children.Add(CreatePlantCard(plantTotal - 1));
        }
    }

    private async void DisplayPlantInfo_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var index = (int)button?.Tag;

        var plantInfoWindow = new PlantInfoWindow(
            index,
            plantNames[index], 
            plantDates[index], 
            plantLocations[index], 
            plantExposures[index], 
            plantWateringFrequencies[index]);

        await plantInfoWindow.ShowDialog(this);

        if (plantInfoWindow.confirmed)
        {
            plantNames[index] = plantInfoWindow.plantName;
            plantDates[index] = plantInfoWindow.purchaseDate ?? DateTimeOffset.Now;
            plantLocations[index] = plantInfoWindow.plantLocation;
            plantExposures[index] = plantInfoWindow.plantExposure;
            plantWateringFrequencies[index] = plantInfoWindow.wateringFrequency;
        }

    }
}