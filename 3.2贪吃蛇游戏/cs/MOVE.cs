using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2贪吃蛇游戏
{
    static class MOVE
    {
        static private int nextPosition;//移动后的蛇头位置
        static public int MoveNextPosition(string direction)//移动后的蛇头位置
        {
            int[] coordinate = SNAKE.ChangeToCD(SNAKE.SnakeStart);
            //coordinate[0]是行-X坐标，coordinate[1]是列-Y坐标
            switch (direction)
            {
                case "↑":
                    coordinate[0] += -1;
                    break;
                case "↓":
                    coordinate[0] += 1;
                    break;
                case "←":
                    coordinate[1] += -1;
                    break;
                case "→":
                    coordinate[1] += 1;
                    break;
                default:
                    break;
            }
            int i = SNAKE.SnakeCoorID(coordinate[0], coordinate[1]);
            nextPosition = i;
            SNAKE.SnakeMoveCoordinate.Add(i);        //记录到SNAKE.SnakeMoveCoordinate数组
            return i;
        }
        static public int MoveDisappear//移动后的蛇尾位置
        {
            get
            {
                //判断是否吃到食物
                if (nextPosition.ToString() == SNAKE.FoodCoor)
                {
                    SNAKE.SnakeLength++;
                    return 0;
                }
                else
                {
                    return SNAKE.SnakeMoveCoordinate[SNAKE.SnakeMoveCoordinate.Count - SNAKE.SnakeLength - 1];
                }
            }
        }
    }
}
