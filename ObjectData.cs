namespace Snake;

public class ObjectData
{
	public static Object[] Snake = new Object[100];
	public static Food food ;
	public static Wall[] walls=new Wall[200];
	public static int count = 0;
	public static MoveDirection direction = MoveDirection.None;
	public static Random random = new Random();
}