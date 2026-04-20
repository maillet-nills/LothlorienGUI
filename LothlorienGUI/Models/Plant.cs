using System;

namespace LothlorienGUI.Models;

public class Plant
{
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; }
    public string Exposure { get; set; }
    public int WateringFrequency { get; set; }

    public Plant(string name, DateTimeOffset date, string location, string exposure, int wateringFrequency)
    {
        this.Name = name;
        this.Date = date;
        this.Location = location;
        this.Exposure = exposure;
        this.WateringFrequency = wateringFrequency;
    }
}