namespace Snake;
public class GameStart:StartAndEndBase
{
	public GameStart()
	{
		title = "The Snake Game!!!";
		option1 = "Play";
		option2 = "Quit";
	}
	public override void ChangeStage()
	{
		Console.Clear();
		Game.setStage(2);
	}
}