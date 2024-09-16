namespace Snake;

public class Food:Object
{
	public Food(int x,int y)
	{	
		this.x = x;
		this.y = y;
	}
	public override void DrawSelf()
	{
		Console.SetCursorPosition(x,y);
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Write("\u2606");
	}
	public void ChangePosition()
	{
		this.x = ObjectData.random.Next(1, 79);
		this.y = ObjectData.random.Next(1, 19);
		for (int i = 0; i < ObjectData.count + 1; i++)
		{
			if (this == ObjectData.Snake[i])
			{
				ChangePosition();
			}
		}
	}
	
}