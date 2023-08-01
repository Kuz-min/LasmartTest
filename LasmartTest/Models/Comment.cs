namespace LasmartTest.Models;

public class Comment
{
    public int Id { get; set; }

    public Point Point { get; set; }
    public int PointId { get; set; }

    public string Text { get; set; }
    public string Background { get; set; }
}
