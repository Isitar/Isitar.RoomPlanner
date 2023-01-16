namespace Isitar.RoomPlanner.Logic.Models;

using System.Collections.Concurrent;

public record Coordinates(double X, double Y)
{
    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.X + b.X, a.Y + b.Y);
    }
}

public class PlacedFurniture
{
    public Furniture Furniture { get; set; }
    public Coordinates Coordinates { get; set; }
    public double RotationInDeg { get; set; }


    public (Coordinates topLeft, Coordinates topRight, Coordinates BottomRight, Coordinates BottomLeft) RotatedCoords()
    {
        /*
         * rotation matrix A = (cos θ, -sin θ)
         *                     (sin θ,  cos θ)
         *
         * rotated point = A(x, y)^T
         */
        var rotationRad = RotationInDeg * (Math.PI / 180);
        var cosTheta = Math.Cos(rotationRad);
        var sinTheta = Math.Sin(rotationRad);

        var transform = (Coordinates c) => new Coordinates(c.X * cosTheta - c.Y * sinTheta, c.X * sinTheta + c.Y * cosTheta);

        var topLeft = transform(new Coordinates(0, 0)) + Coordinates;
        var topRight = transform(new Coordinates(Furniture.Width, 0)) + Coordinates;
        var bottomRight = transform(new Coordinates(Furniture.Width, Furniture.Length)) + Coordinates;
        var bottomLeft = transform(new Coordinates(0, Furniture.Length)) + Coordinates;
        return (topLeft, topRight, bottomRight, bottomLeft);
    }
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

    public double CalibratedAtWidth { get; set; }
    public double CalibratedWidthForOneUnit { get; set; }
    public double ScaleFactorX(double currentWidth) => (currentWidth / CalibratedAtWidth) * CalibratedWidthForOneUnit;


    public double CalibratedAtHeight { get; set; }
    public double CalibratedHeightForOneUnit { get; set; }
    public double ScaleFactorY(double currentWidth) => (currentWidth / CalibratedAtHeight) * CalibratedHeightForOneUnit;


    public string BackgroundImage { get; set; }
}