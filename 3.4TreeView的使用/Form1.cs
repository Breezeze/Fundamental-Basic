using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._4TreeView的使用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //清空所有节点
        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }
        //添加一个根节点
        private void button2_Click(object sender, EventArgs e)
        {
            string txt = textBox2.Text.Trim();
            if (txt != "")
            {
                //返回值就是新添加的这个节点，可以通过这个返回值控制新节点
                TreeNode node = treeView1.Nodes.Add(txt);
                node.BackColor = Color.Yellow;
            }
        }
        //向选中的节点中添加一个子节点
        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node != null)//判断是否选中
            {
                string txt = textBox2.Text.Trim();
                if (txt != "")
                {
                    //返回值就是新添加的这个节点，可以通过这个返回值控制新节点
                    TreeNode node2 = node.Nodes.Add(txt);
                }
            }


        }
        //修改选中节点的名称
        private void button4_Click(object sender, EventArgs e)
        {
            string txt = textBox2.Text.Trim();
            if (txt != "" && treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Text = txt;
            }
        }
        //删除选中节点
        private void button5_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode!=null)
            {
                treeView1.SelectedNode.Remove();
            }
        }
        //拓展
        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }










        #region 资源管理器

        // private void Form1_Load(object sender, EventArgs e)
        //{
        //    string path = "demo";
        //    //递归加载
        //    LoadData(path, treeView1.Nodes);
        //}

        ///// <summary>
        ///// 递归加载目录
        ///// </summary>
        ///// <param name="path">根目录名</param>
        ///// <param name="treeNodeCollection">TreeView节点</param>
        //private void LoadData(string path, TreeNodeCollection treeNodeCollection)
        //{
        //    //1.获取path下的所有目录与文件
        //    string[] files = Directory.GetFiles(path, "*.txt");
        //    string[] dirs = Directory.GetDirectories(path);
        //    //2.遍历加载到TreeView
        //    //文件
        //    foreach (string item in files)
        //    {
        //        treeNodeCollection.Add(Path.GetFileName(item));
        //    }
        //    //目录
        //    foreach (string item in dirs)
        //    {
        //        TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
        //        LoadData(item, node.Nodes);
        //    }


        #endregion

    }
}
