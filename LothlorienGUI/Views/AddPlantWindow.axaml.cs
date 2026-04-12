using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LothlorienGUI.Views;

public partial class AddPlantWindow : Window
{
    public string plantName { get; private set; } = "";
    public DateTimeOffset? purchaseDate { get; private set; }
    public string plantLocation { get; private set; } = "";
    public string plantExposure { get; private set; } = "";
    public int wateringFrequency { get; private set; } = 7;
    public bool confirmed { get; private set; } = false;
    
    public AddPlantWindow()
    {
        InitializeComponent();
    }

    private void AddPlantButton_OnClick(object? sender, RoutedEventArgs e)
    {
        plantName = PlantNameInput.Text ?? "";
        purchaseDate = PlantPurchaseDateInput.SelectedDate;
        plantLocation = (LocationPicker.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
        
        if (FullSunRadioButton.IsChecked == true)
            plantExposure = "FullSun";
        else if (PartialSunRadioButton.IsChecked == true)
            plantExposure = "PartialSun";
        else if (LowSunRadioButton.IsChecked == true)
            plantExposure = "LowSun";

        wateringFrequency = (int)(WateringFrequencyInput.Value ?? 7);
        
        confirmed = true;
        
        Close();
    }
}