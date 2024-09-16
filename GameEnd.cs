namespace Snake;

public class GameEnd:StartAndEndBase
{
	public GameEnd()
	{
		title="Game Over";
		option1 = "Return to title";
		option2 = "End Game";
	}
	public override void ChangeStage()
	{
		Console.Clear();
		Game.InitializeSnake();
		ObjectData.count = 0;
		ObjectData.direction = MoveDirection.None;
		Game.setStage(1);
	}
	


}