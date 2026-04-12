using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LothlorienGUI.Views;

public partial class PlantInfoWindow : Window
{
    public PlantInfoWindow(string plantName, DateTimeOffset plantDate, string plantLocation, string plantExposure, int plantWatering)
    {
        InitializeComponent();
        InfoTitleTextBlock.Text =  plantName;
        PlantNameTextBox.Text = plantName;
        PlantDatePicker.SelectedDate = plantDate;
        PlantLocationComboBox.PlaceholderText = plantLocation;

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
        
        PlantWateringTextBlock.Text = plantWatering.ToString();
    }

    private void EditPlantButton_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}