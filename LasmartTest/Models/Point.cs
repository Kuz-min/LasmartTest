namespace LasmartTest.Models;

public class Point
{
    public int Id { get; set; }
    public double PositionX { get; set; }
    public double PositionY { get; set; }
    public double Radius { get; set; }
    public string Color { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
}
