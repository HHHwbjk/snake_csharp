namespace Snake;
//打印墙体--->

public enum MoveDirection
{
	Left,
	Right,
	Up,
	Down,
	None
}
public class SnakeHead:Object
{
	public SnakeHead(int x,int y)
	{
		this.x = x;
		this.y = y;
	}
	public override void DrawSelf()
	{
		Console.SetCursorPosition(x,y);
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.Write("X");
	}
}

