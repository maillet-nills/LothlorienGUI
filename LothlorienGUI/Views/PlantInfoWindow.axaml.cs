using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LothlorienGUI.Views;

public partial class PlantInfoWindow : Window
{
    
    public string plantName { get; private set; } = "";
    public DateTimeOffset? purchaseDate { get; private set; }
    public string plantLocation { get; private set; } = "";
    public string plantExposure { get; private set; } = "";
    public int wateringFrequency { get; private set; } = 7;
    public bool confirmed { get; private set; } = false;
    
    public PlantInfoWindow(int plantIndex, string plantName, DateTimeOffset plantDate, string plantLocation, string plantExposure, int plantWatering)
    {
        InitializeComponent();
        InfoTitleTextBlock.Text =  plantName;
        PlantNameTextBox.Text = plantName;
        PlantDatePicker.SelectedDate = plantDate;
        
        foreach (var item in PlantLocationComboBox.Items)
        {
            var comboItem = item as ComboBoxItem;
            if (comboItem?.Content?.ToString() == plantLocation)
            {
                PlantLocationComboBox.SelectedItem = comboItem;
                break;
            }
        }

        if (plantExposure == "FullSun")
        {
            FullSunRadioButton.IsChecked = true;
        } else if (plantExposure == "PartialSun")
        {
            PartialSunRadioButton.IsChecked = true;
        } else if (plantExposure == "LowSun")
        {
            LowSunRadioButton.IsChecked = true;
        }
        
        WateringFrequencyInput.Value = plantWatering;
    }

    private void EditPlantButton_OnClick(object? sender, RoutedEventArgs e)
    {
        PlantNameTextBox.IsEnabled = true;
        PlantDatePicker.IsEnabled = true;
        PlantLocationComboBox.IsEnabled = true;
        FullSunRadioButton.IsHitTestVisible = true;
        PartialSunRadioButton.IsHitTestVisible = true;
        LowSunRadioButton.IsHitTestVisible = true;
        WateringFrequencyInput.IsHitTestVisible = true;
        
        EditPlantButton.IsVisible = false;
        SavePlantButton.IsVisible = true;
    }

    private void SavePlantButton_OnClick(object? sender, RoutedEventArgs e)
    {
        plantName = PlantNameTextBox.Text;
        purchaseDate = PlantDatePicker.SelectedDate;
        plantLocation =(PlantLocationComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
        
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