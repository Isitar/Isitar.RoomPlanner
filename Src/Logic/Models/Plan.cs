namespace Isitar.RoomPlanner.Logic.Models;

using System.Collections.Concurrent;

public class PlacedFurniture
{
    public Furniture Furniture { get; set; }
    public (decimal X, decimal Y) Coordinates { get; set; }
}

public class Plan
{
    public Plan(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();
    public ICollection<PlacedFurniture> PlacedFurnitures { get; set; } = new List<PlacedFurniture>();

    public decimal CalibratedAtWidth { get; set; }
    public decimal CalibratedWidthForOneUnit { get; set; }
    public decimal ScaleFactorX(decimal currentWidth) => (currentWidth / CalibratedAtWidth) * CalibratedWidthForOneUnit;


    public decimal CalibratedAtHeight { get; set; }
    public decimal CalibratedHeightForOneUnit { get; set; }
    public decimal ScaleFactorY(decimal currentWidth) => (currentWidth / CalibratedAtHeight) * CalibratedHeightForOneUnit;
    public decimal CalibratedHeight { get; set; }


    public string BackgroundImage { get; set; }
}