namespace Snake;

public class Wall:Object
{
	public Wall(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	
	public override void DrawSelf()
	{
		Console.SetCursorPosition(x,y);
		Console.ForegroundColor = ConsoleColor.Red;
		Console.Write("■");
	}
}