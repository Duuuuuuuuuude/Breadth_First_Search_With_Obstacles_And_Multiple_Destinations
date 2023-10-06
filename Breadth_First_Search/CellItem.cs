
namespace BreadthFirst;

public class CellItem : IEquatable<CellItem>
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Distance { get; set; }

    public CellItem(int x, int y, int d)
    {
        this.Row = x;
        this.Col = y;
        this.Distance = d;
    }

    public bool Equals(CellItem? otherCellItem)
    {
        return otherCellItem != null &&
               this.Row == otherCellItem.Row &&
               this.Col == otherCellItem.Col;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Row, this.Col);
    }
}