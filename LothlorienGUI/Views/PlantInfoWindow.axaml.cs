using System;
using Avalonia.Controls;

namespace LothlorienGUI.Views;

public partial class PlantInfoWindow : Window
{
    public PlantInfoWindow(string plantName, DateTimeOffset plantDate, string plantLocation, string plantExposure, int plantWatering)
    {
        InitializeComponent();
        InfoTitleTextblock.Text =  plantName;
        PlantNameTextbox.Text = plantName;
        PlantDateTextbox.Text = plantDate.ToString("dd/MM/yyyy");
        PlantLocationTextbox.Text = plantLocation;
        PlantExposureTextbox.Text = plantExposure;
        PlantWateringTextbox.Text = plantWatering.ToString();
    }
}