namespace Snake;

public abstract class StartAndEndBase: I_Update
{
     int input=1;
    protected string title="Snake";
    protected string option1 = "开始游戏";
    protected string option2 = "退出游戏";
    public abstract void ChangeStage();
    
    public   void Update()
    {
        for (int i = 0; i < ObjectData.count+1; i++)
        {
            Console.SetCursorPosition(ObjectData.Snake[i].GetX(),ObjectData.Snake[i].GetY());
            Console.Write("   ");
        }
        Console.SetCursorPosition(Console.BufferWidth/2, 5); 
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(title);
        Console.SetCursorPosition(Console.BufferWidth/2,8);
        Console.ForegroundColor = (input==1) ? ConsoleColor.Green : ConsoleColor.White;
        Console.Write(option1);
        Console.SetCursorPosition(Console.BufferWidth/2,11);
        Console.ForegroundColor = (input==2) ? ConsoleColor.Green : ConsoleColor.White;
        Console.Write(option2);
        ChangeOption();
    }

    public void ChangeOption()
    {
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.UpArrow:
            {
                if (input == 2)
                    input = 1;
                break;
            }
            case ConsoleKey.DownArrow:
            {
                if (input == 1)
                {
                    input = 2;
                }
                break;
            }
            case ConsoleKey.Spacebar:
            {
                if(input==1)
                    ChangeStage();//切换场景
                else if(input==2)
                    Environment.Exit(0);//离开游戏
                break;
            }
        }
    }

}