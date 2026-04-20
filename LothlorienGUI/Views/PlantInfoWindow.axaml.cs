using System;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Controls;
using Avalonia.Interactivity;
using LothlorienGUI.Models;

namespace LothlorienGUI.Views;

public partial class PlantInfoWindow : Window
{
    public Plant Plant { get; set; }
    public bool confirmed { get; private set; } = false;
    
    public PlantInfoWindow(Plant plant)
    {
        InitializeComponent();
        this.Plant = plant;
        InfoTitleTextBlock.Text =  plant.Name;
        PlantNameTextBox.Text = plant.Name;
        PlantDatePicker.SelectedDate = plant.Date;
        
        foreach (var item in PlantLocationComboBox.Items)
        {
            var comboItem = item as ComboBoxItem;
            if (comboItem?.Content?.ToString() == plant.Location)
            {
                PlantLocationComboBox.SelectedItem = comboItem;
                break;
            }
        }

        if (plant.Exposure == "FullSun")
        {
            FullSunRadioButton.IsChecked = true;
        } else if (plant.Exposure == "PartialSun")
        {
            PartialSunRadioButton.IsChecked = true;
        } else if (plant.Exposure == "LowSun")
        {
            LowSunRadioButton.IsChecked = true;
        }
        
        WateringFrequencyInput.Value = plant.WateringFrequency;
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
        Plant.Name = PlantNameTextBox.Text;
        Plant.Date = (DateTimeOffset)PlantDatePicker.SelectedDate;
        Plant.Location =(PlantLocationComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
        
        if (FullSunRadioButton.IsChecked == true)
            Plant.Exposure = "FullSun";
        else if (PartialSunRadioButton.IsChecked == true)
            Plant.Exposure = "PartialSun";
        else if (LowSunRadioButton.IsChecked == true)
            Plant.Exposure = "LowSun";
        
        Plant.WateringFrequency = (int)(WateringFrequencyInput.Value ?? 7);
        
        confirmed = true;
        
        Close();
    }
}