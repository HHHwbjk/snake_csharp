namespace Snake;
//隐藏光标
//游戏前--->游戏中--->游戏结束--->返回 游戏前
//游戏前--选项：开始，结束
//游戏中--读取用户指令
//游戏技术--选项:重新开始，退出
public class Game
{ 
    private static I_Update currentStage;//当前的游戏阶段
    private static int StageFlag=1; 
    public Game()
    {
        InitializeSnake();
        InitializeWall();
        IntializeFood();
        Console.SetWindowSize(100,30);
        Console.SetBufferSize(100,30);
        Console.CursorVisible = false;//隐藏光标
        setStage(1);//设置为游戏开始界面
    } 
    public void Run()
    {
        Thread th = new Thread(Update);
        th.Start();
    }

    public void Update()
    {
        while (true)
        {
            int sleepTime = StageFlag==2? 100:20;
            Thread.Sleep(sleepTime);
            currentStage.Update();
        }
     }
    public static void setStage(int flag)
    {
        switch (flag)
        {
            case 1:currentStage=new GameStart();break;
            case 2:currentStage=new GameMid();break;
            case 3:currentStage=new GameEnd();break;
        }

        StageFlag = flag;
    }

    public static void  InitializeSnake()
    {
        ObjectData.Snake[0] = new SnakeHead(40, 10);
        if (ObjectData.count > 0)
        {
            for (int i = 0; i < ObjectData.count; i++)
            {
                ObjectData.Snake[i+1] =null;
            }
        }
    }
 
    public void InitializeWall()
    {
        for (int i = 0; i < 80; i++)
        {
            ObjectData.walls[i] = new Wall(i, 0);
        }

        for (int i = 0; i < 80; i++)
        {
            ObjectData.walls[i+80] = new Wall(i, 20);
        }

        for (int i = 0; i < 20; i++)
        {
            ObjectData.walls[i+160] = new Wall(0,i);
        }

        for (int i = 0; i < 20; i++)
        {
            ObjectData.walls[i+180] = new Wall(80,i);
        }
    }

    public void IntializeFood()
    {
        ObjectData.food = new Food(2, 4);
        ObjectData.food.ChangePosition();
    }
}