namespace Snake;

public class GameMid:I_Update
{
    public   void ChangeStage()
    {
        Console.Clear();
        Game.setStage(3);
    }

    public   void Update()
    {
        DrawWall();
        DrawFood();
        CheckFoodCrash();
        BodyMove();
        HeadMove(); 
        DrawSnake(); 
    }

    public void DrawSnake()
    {
        for (int i = 0; i < ObjectData.count + 1; i++)
        {
            ObjectData.Snake[i].DrawSelf();
        }
    }

    public void DrawWall()
    {
        foreach (var t in ObjectData.walls)
        {
            t.DrawSelf();
        }
    }

    public void DrawFood()
    {
        ObjectData.food.DrawSelf();
    }

    public void BodyMove()
    {
        Console.SetCursorPosition(ObjectData.Snake[ObjectData.count ].GetX(), ObjectData.Snake[ObjectData.count ].GetY());
        Console.Write("  "); 
        if (ObjectData.count > 0)
        {
            for (int i = ObjectData.count; i >0; i--)
            {
                ObjectData.Snake[i].SetX(ObjectData.Snake[i-1].GetX());
                ObjectData.Snake[i].SetY(ObjectData.Snake[i-1].GetY());
            }
        }
    }

    public void HeadMove()
    {
        int x=ObjectData.Snake[0].GetX();
        int y=ObjectData.Snake[0].GetY();
        if (ObjectData.direction != MoveDirection.None)
        {
            switch (ObjectData.direction)
            {
                case MoveDirection.Left:
                {
                    ObjectData.Snake[0].SetX(x - 1);
                    break;
                }
                case MoveDirection.Right:
                {
                    ObjectData.Snake[0].SetX(x + 1);
                    break;
                }
                case MoveDirection.Up:
                {
                    ObjectData.Snake[0].SetY(y - 1);
                    break;
                }
                case MoveDirection.Down:
                {
                    ObjectData.Snake[0].SetY(y + 1);
                    break;
                }
            }
        }
        CheckDeath();
        ChangeDirection();
    }
    
    public void ChangeDirection()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if (ObjectData.direction == MoveDirection.Right)
                        break;
                    ObjectData.direction = MoveDirection.Left;
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (ObjectData.direction == MoveDirection.Left)
                        break;
                    ObjectData.direction = MoveDirection.Right;
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (ObjectData.direction == MoveDirection.Down)
                        break;
                    ObjectData.direction = MoveDirection.Up;
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (ObjectData.direction == MoveDirection.Up)
                        break;
                    ObjectData.direction = MoveDirection.Down;
                    break;
                }

            }
        }
    }
    public void CheckFoodCrash()
    {
        int count = ObjectData.count;
        if (ObjectData.food == ObjectData.Snake[0])
        {
            ObjectData.food.ChangePosition();
            ObjectData.Snake[count + 1] = new SnakeBody(ObjectData.Snake[count].GetX(), ObjectData.Snake[count ].GetY());
            ObjectData.count++;
        }
    }

    public void CheckDeath()
    {
        int count = ObjectData.count;

        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (ObjectData.Snake[0] == ObjectData.Snake[i + 1])
                {
                    ChangeStage();
                }
            }
        }

        switch (ObjectData.direction)
        {
            case MoveDirection.Left:
                for (int i = 0; i < 20; i++)
                {
                    if (ObjectData.walls[160 + i] == ObjectData.Snake[0])
                        ChangeStage();
                }
                break;
            case MoveDirection.Right:
                for (int i = 0; i < 20; i++)
                {
                    if(ObjectData.walls[180 + i] == ObjectData.Snake[0])
                        ChangeStage();
                }
                break;
            case MoveDirection.Up:
                for (int i = 0; i < 80; i++)
                {
                    if(ObjectData.walls[i] == ObjectData.Snake[0])
                        ChangeStage();
                }
                break;
            case MoveDirection.Down:
                for (int i = 0; i < 80; i++)
                {
                    if(ObjectData.walls[i+80] == ObjectData.Snake[0])
                        ChangeStage();
                }
                break;
        }
    }

}