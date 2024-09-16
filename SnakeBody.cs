namespace Snake;

public class SnakeBody:Object
{
	public SnakeBody()
	{
		
	}
	public SnakeBody(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	public override void DrawSelf()
	{
		Console.SetCursorPosition(x,y);
		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("O");
	}


}