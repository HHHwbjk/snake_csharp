namespace Snake;

public abstract class Object
{
	protected int x, y;
	public abstract void DrawSelf();

	public static bool operator ==(Object o1, Object o2)
	{
		return o1.x == o2.x && o1.y == o2.y;
	}

	public static bool operator !=(Object o1, Object o2)
	{
		return !(o1 == o2);
	}

	public int GetX()
	{
		return x;
	}

	public int GetY()
	{
		return y;
	}

	public void SetX(int x)
	{
		this.x = x;
	}

	public void SetY(int y)
	{
		this.y = y;
	}
}