using System;
using System.Windows.Forms;

namespace _3._2贪吃蛇游戏
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //没有死亡系统
        //一个小BUG

        #region 全局定量
        //static int lieshu = 20;//列数
        //static int hangshu = 15;//行数
        //static bool[,] Coordinate = new bool[30, 15];//坐标，true代表黑色-选中，false代表白色-未选中即背景，初始值为false
        #endregion

        public object IdControl(int i)//显示蛇身
        {
            string id = "pictureBox" + i.ToString();    //根据id控制控件
            object control = this.GetType().GetField(id, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            return control;
            // ((#)IdControl(*)).Text = "已修改";       //#为控件类型，*为参数
        }
        public void RandomFoodCoor()//随机给出食物的位置
        {
            string id = "pictureBox" + SNAKE.RandomFoodCoor();
            object control = this.GetType().GetField(id, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((PictureBox)control).Visible = false;

            int[] asd = SNAKE.ChangeToCD(Convert.ToInt32(SNAKE.FoodCoor));
            label4.Text = "食物位置：(" + asd[0] + "," + asd[1] + ")";
            label2.Text = "长度：" + SNAKE.SnakeLength;
        }
        public void MoveToDo()//移动
        {
            int move = MOVE.MoveNextPosition(SNAKE.Direction);
            ((PictureBox)IdControl(move)).Visible = false;
            if (MOVE.MoveDisappear != 0)
            {
                ((PictureBox)IdControl(MOVE.MoveDisappear)).Visible = true;
            }
            else
            {
                RandomFoodCoor();
            }

            int[] asd = SNAKE.ChangeToCD(SNAKE.SnakeStart);
            label3.Text = "蛇头位置：(" + asd[0] + "," + asd[1] + ")";
        }
        private void Start_Click(object sender, EventArgs e)// START按键
        {
            #region 判断速度输入框输入是否正确

            int text = Convert.ToInt32(textBox2.Text);
            if (text < 1 || text > 10)
            {
                label8.Visible = true;
            }
            else
            {

            #endregion

                #region 设置初始值

                SNAKE.Direction = "→";

                #endregion

                #region 隐藏和显示控件

                ((PictureBox)IdControl(121)).Visible = false;
                ((PictureBox)IdControl(122)).Visible = false;
                ((PictureBox)IdControl(123)).Visible = false;
                ((PictureBox)IdControl(124)).Visible = false;

                label5.Visible = false;
                label8.Visible = false;
                textBox2.Visible = false;
                Start.Visible = false;

                label1.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;

                up.Visible = true;
                down.Visible = true;
                left.Visible = true;
                right.Visible = true;

                #endregion

                #region 随机出食物位置

                RandomFoodCoor();

                #endregion

                #region 设置蛇的速度

                timer1.Interval = 330 - text * 33;

                #endregion

                #region 时间控件开始运行

                timer1.Start();
                timer2.Start();

                #endregion
                

            }
        }
        private void up_Click(object sender, EventArgs e)// 移动按钮
        {
            if (SNAKE.Direction != "↓")
            {
                SNAKE.Direction = "↑";
            }
        }
        private void down_Click(object sender, EventArgs e)// 移动按钮
        {
            if (SNAKE.Direction != "↑")
            {
                SNAKE.Direction = "↓";
            }
        }
        private void left_Click(object sender, EventArgs e)// 移动按钮
        {
            if (SNAKE.Direction != "→")
            {
                SNAKE.Direction = "←";
            }
        }
        private void right_Click(object sender, EventArgs e)// 移动按钮
        {
            if (SNAKE.Direction != "←")
            {
                SNAKE.Direction = "→";
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)// 时间控件-自动运行蛇的移动
        {
            MoveToDo();
        }
        private void timer2_Tick(object sender, EventArgs e)// 实时读取键盘输入
        {
            string text = textBox1.Text;
            textBox1.Text = "";
            switch (text)
            {
                case "w":
                    if (SNAKE.Direction != "↓")
                    {
                        SNAKE.Direction = "↑";
                    }
                    break;
                case "s":
                    if (SNAKE.Direction != "↑")
                    {
                        SNAKE.Direction = "↓";
                    }
                    break;
                case "a":
                    if (SNAKE.Direction != "→")
                    {
                        SNAKE.Direction = "←";
                    }
                    break;
                case "d":
                    if (SNAKE.Direction != "←")
                    {
                        SNAKE.Direction = "→";
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
