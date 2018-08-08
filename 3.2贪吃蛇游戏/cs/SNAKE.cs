using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2贪吃蛇游戏
{
    static class SNAKE
    {
        static SNAKE()
        {
            SnakeLength = 4;
            SnakeMoveCoordinate.Add(121);   //设置初始位置
            SnakeMoveCoordinate.Add(122);
            SnakeMoveCoordinate.Add(123);
            SnakeMoveCoordinate.Add(124);
        }
        static public List<int> SnakeMoveCoordinate = new List<int>();
        //
        // 摘要: 
        //     获取或设置 System.Windows.Forms.TextBox 中的当前文本。
        //
        // 返回结果: 
        //     The text displayed in the control.
        static public int SnakeLength { get; set; }//蛇身长度
        static public string FoodCoor { get; set; }//食物位置
        static public string Direction { get; set; }//前进方向
        static public int SnakeStart//蛇头位置
        {
            get
            {
                return SnakeMoveCoordinate[SnakeMoveCoordinate.Count - 1];
            }
        }
        static public int SnakeEnd//蛇尾位置
        {
            get
            {
                return SnakeMoveCoordinate[SnakeMoveCoordinate.Count - SnakeLength];
            }
        }
        static public int[] ChangeToCD(int id)//id转化为coordinate
        {
            int[] coordinate = new int[2];
            if (id % 20 != 0)   //不是右边缘时
            {
                coordinate[0] = (int)(id / 20 + 1);     //第x行
                coordinate[1] = id % 20;                //第y列
            }
            else        //在右边缘时，即id为20的整数倍
            {
                coordinate[0] = id / 20;     //第x行
                coordinate[1] = 20;                //第y列
            }
            return coordinate;
        }
        static public int SnakeCoorID(int x, int y)//coordinate转化为id
        {
            int id = 20 * (x - 1) + y;
            return id;
        }
        static public string RandomFoodCoor()//随机给出食物的位置
        {
            Random random = new Random();
            int x;
            bool judge = true;
            for (x = random.Next(1, 301); judge; )
            {
                for (int i = 0; i < SnakeLength; i++)
                {
                    if (x == SnakeMoveCoordinate[SnakeMoveCoordinate.Count - i - 1] && x == Convert.ToInt32(FoodCoor))//- SnakeLength + i
                    {
                        break;
                    }
                    judge = false;
                }
            }
            FoodCoor = x.ToString();
            return FoodCoor;
        }
    }
}
