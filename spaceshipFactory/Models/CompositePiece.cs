namespace spaceshipFactory.Models;

public abstract class CompositePiece
{
	public string Name { get; }
	public int Quantity { get; set; }

	protected CompositePiece(string name, int quantity)
	{
		Name = name;
		Quantity = quantity;
	}

	public abstract void Add(CompositePiece piece);
	public abstract void Remove(CompositePiece piece);
	public abstract void Display(int depth);
}
