using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Media;
using LothlorienGUI.Models;
using LothlorienGUI.ViewModels;

namespace LothlorienGUI.Views;

public partial class MainWindow : Window
{
    private Plant[] _plants = new Plant[100];

    private int plantTotal;
    public MainWindow()
    {
        InitializeComponent();
        plantTotal = 0;
    }

    private Border CreatePlantCard(Plant plant)
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
            nameText.Text = plant.Name;
            nameText.FontSize = 14;
            nameText.FontWeight = FontWeight.Bold;
            nameText.Foreground = new SolidColorBrush(Color.Parse("#3A5A2A"));
            nameText.HorizontalAlignment = HorizontalAlignment.Center;
            nameText.TextAlignment = TextAlignment.Center;
            nameText.TextWrapping = TextWrapping.Wrap;

            var locationText = new TextBlock();
            locationText.Text = plant.Location;
            locationText.FontSize = 13;
            locationText.Foreground = new SolidColorBrush(Color.Parse("#90B070"));
            locationText.HorizontalAlignment = HorizontalAlignment.Center;

            var dateText = new TextBlock();
            dateText.Text = plant.Date.ToString("dd/MM/yyyy");
            dateText.FontSize = 13;
            dateText.Foreground = new SolidColorBrush(Color.Parse("#90B070"));
            dateText.HorizontalAlignment = HorizontalAlignment.Center;
            
            plantCard.Child = plantCardButton;
            plantCardButton.Content = plantCardContent;
            plantCardContent.Children.Add(iconText);
            plantCardContent.Children.Add(nameText);
            plantCardContent.Children.Add(locationText);
            plantCardContent.Children.Add(dateText);

            plantCardButton.Tag = plant;

            return plantCard;
    }

    private async void AddOnPlantButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var plantInputWindow = new AddPlantWindow();
        
        await plantInputWindow.ShowDialog(this);

        if (plantInputWindow.confirmed)
        {
            _plants[plantTotal] = new Plant(
                plantInputWindow.plantName,
                plantInputWindow.purchaseDate ?? DateTimeOffset.Now,
                plantInputWindow.plantLocation,
                plantInputWindow.plantExposure,
                plantInputWindow.wateringFrequency);
            
            plantTotal++;
            
            if (DataContext is MainWindowViewModel vm)
                vm.PlantCount = plantTotal;
            
            CardPanel.Children.Add(CreatePlantCard(_plants[plantTotal - 1]));
        }
    }

    private async void DisplayPlantInfo_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var plant = (Plant)button?.Tag;

        var plantInfoWindow = new PlantInfoWindow(plant);

        await plantInfoWindow.ShowDialog(this);

        if (plantInfoWindow.confirmed)
        {
            plant.Name = plantInfoWindow.Plant.Name;
            plant.Date = plantInfoWindow.Plant.Date;
            plant.Location = plantInfoWindow.Plant.Location;
            plant.Exposure = plantInfoWindow.Plant.Exposure;
            plant.WateringFrequency = plantInfoWindow.Plant.WateringFrequency;
        }

    }
}