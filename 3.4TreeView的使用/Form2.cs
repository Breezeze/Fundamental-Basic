using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._4TreeView的使用
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //获取当前EXE文件的绝对路径
            textBox1.Text = System.Windows.Forms.Application.StartupPath;
            //调用点击事件
            //this.button1.PerformClick();
            this.button1_Click(null, null);

        }

        #region 工作文档

        /*已实现功能：
         * 1.通过递归实现任意目录加载，默认TreeView根路径为当前EXE文件所在路径
         * 2.快捷键：上一级目录，以选定节点作为TreeView的根目录，打开文件资源管理器， 
         * 3.拷贝文件功能，复制粘贴按钮的错误操作提示
         * 4.加密/解密文件功能，错误操作提示
         * 5.优化目录加载方式

        

         *近期任务：
         * 1.改进代码，将函数封装入类
        */

        #endregion

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="hint">提示框显示的文字</param>
        private void Hint(string hint)
        {
            MessageBox.Show(hint, "提示", MessageBoxButtons.OK);
        }
        /// <summary>
        /// 获取节点的绝对路径
        /// </summary>
        /// <param name="node">节点</param>
        private string GetAbsolutePath(string path)
        {
            return Path.Combine(PathOfTreeView, path);
        }

        #region 全局变量

        /// <summary>
        /// 存储当前TreeView所示目录路径
        /// </summary>
        string PathOfTreeView;
        /// <summary>
        /// 源文件的绝对路径
        /// </summary>
        string PathOfOriginFile = "";
        /// <summary>
        /// 存储TreeView加载目录深度
        /// </summary>
        int LevelOfTreeViewNode = 0;

        #endregion

        #region Form事件

        //========查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            PathOfTreeView = textBox1.Text.Trim();
            LevelOfTreeViewNode = 0;
            UploadTreeview(PathOfTreeView, treeView1.Nodes);
        }
        //========复制按钮
        private void button2_Click(object sender, EventArgs e)
        {
            if (Path.HasExtension(treeView1.SelectedNode.FullPath))
            {
                PathOfOriginFile = GetAbsolutePath(treeView1.SelectedNode.FullPath);
            }
            else
            {
                Hint("目前不支持文件夹的复制粘贴！");
            }
        }
        //========粘贴按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (PathOfOriginFile == "")
            {
                Hint("请先选定要复制的文件！");
            }
            else
            {
                string SelectedPath = Path.Combine(PathOfTreeView, treeView1.SelectedNode.FullPath);
                if (!Path.HasExtension(SelectedPath))
                {
                    string NewFileName;
                    if (SelectedPath == Path.GetDirectoryName(PathOfOriginFile))
                    {
                        if (PathOfOriginFile.IndexOf("(") > 0 && PathOfOriginFile.IndexOf(")") > 0)
                        {

                            NewFileName = MakeNewFileName(Path.Combine(SelectedPath, PathOfOriginFile));
                            SelectedPath += @"\" + NewFileName;
                        }
                        else
                        {
                            NewFileName = Path.GetFileNameWithoutExtension(PathOfOriginFile) + "(0)" + Path.GetExtension(PathOfOriginFile);
                            NewFileName = MakeNewFileName(Path.Combine(SelectedPath, NewFileName));
                            SelectedPath += @"\" + NewFileName;

                        }
                    }
                    else
                    {
                        NewFileName = Path.GetFileName(PathOfOriginFile);
                        SelectedPath += @"\" + Path.GetFileName(PathOfOriginFile);
                    }
                    FileStreamOperate(PathOfOriginFile, SelectedPath, 2, false);
                    Hint("新文件\n“" + NewFileName + "”\n拷贝成功");
                    UploadTreeview(Path.Combine(PathOfTreeView, treeView1.SelectedNode.FullPath), treeView1.SelectedNode.Nodes);
                }
                else
                {
                    Hint("请选择文件夹！");
                }
            }
        }
        //========加密/解密文件
        private void button4_Click(object sender, EventArgs e)
        {
            if (Path.HasExtension(treeView1.SelectedNode.Text))
            {
                DialogResult dr = MessageBox.Show("确定在当前文件夹加密以下文件吗？\n" + treeView1.SelectedNode.Text, "警告！", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string meg;
                    string FilePath = Path.Combine(PathOfTreeView, treeView1.SelectedNode.FullPath);
                    string NewFileName = Path.GetFileName(FilePath);
                    if (NewFileName.IndexOf("加密_") < 0)
                    {
                        NewFileName = "加密_" + NewFileName + ".rar";
                        meg = "文件加密成功！\n";
                    }
                    else
                    {
                        NewFileName = "已解密_" + Path.GetFileNameWithoutExtension(NewFileName).Substring(3);
                        meg = "文件解密成功！\n";
                    }
                    FileStreamOperate(FilePath, Path.Combine(Path.GetDirectoryName(FilePath), NewFileName), 10, true);
                    Hint(meg + NewFileName);
                    UploadTreeview(Path.GetDirectoryName(FilePath), treeView1.SelectedNode.Parent == null ? treeView1.Nodes : treeView1.SelectedNode.Parent.Nodes);
                }
            }
            else
            {
                Hint("目前不支持文件夹的加密！");
            }
        }
        //========返回上一级目录
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = Path.GetDirectoryName(PathOfTreeView);
            this.button1.PerformClick();
        }
        private void button5_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.ToolTipTitle = "";
            this.toolTip1.IsBalloon = false;
            this.toolTip1.UseFading = true;
            this.toolTip1.Show("上一级目录", this.button5);
        }
        //========TreeView根目录重定义
        private void button6_Click(object sender, EventArgs e)
        {
            if (!Path.HasExtension(treeView1.SelectedNode.FullPath))
            {
                DialogResult dr = MessageBox.Show("确定重新定义根目录 吗？", "警告", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string OriginPath = GetAbsolutePath(treeView1.SelectedNode.FullPath);
                    textBox1.Text = OriginPath;
                    this.button1.PerformClick();
                }
            }
            else
            {
                Hint("请以文件夹作为根目录！");
            }
        }
        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.ToolTipTitle = "重新规定左侧视图显示目录的根目录";
            this.toolTip1.IsBalloon = false;
            this.toolTip1.UseFading = true;
            this.toolTip1.Show("请先在左侧视图中选定根目录！", this.button6);
        }
        //========在资源管理器中找到当前选定文件夹
        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.GetDirectoryName(GetAbsolutePath(treeView1.SelectedNode.FullPath)));
        }
        //========节点展开,自动加载
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            LevelOfTreeViewNode = 1;
            UploadTreeview(Path.Combine(PathOfTreeView, e.Node.FullPath), e.Node.Nodes);
        }

        #endregion

        #region 主要功能实现函数

        #region 加载目录

        /// <summary>
        /// TreeView查询目录（更新目录）
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <param name="treeNodeCollection">TreeView节点集合</param>
        private void UploadTreeview(string path, TreeNodeCollection treeNodeCollection)
        {
            treeNodeCollection.Clear();
            GetTreeViewPath(path, treeNodeCollection);
        }

        /// <summary>
        /// 递归加载目录
        /// </summary>
        /// <param name="path">根目录名</param>
        /// <param name="treeNodeCollection">TreeView节点集合</param>
        private void GetTreeViewPath(string path, TreeNodeCollection treeNodeCollection)
        {
            //优化：禁止加载过多节点
            TreeNode _node = treeNodeCollection.Add("_优化测试节点_");
            if (_node.Level > LevelOfTreeViewNode)
            {
                LevelOfTreeViewNode++;
                if (LevelOfTreeViewNode > 3)
                {
                    LevelOfTreeViewNode--;
                    _node.Remove();
                    return;
                }
            }
            _node.Remove();

            string[] dirs = Directory.GetDirectories(Path.GetFullPath(path));
            string[] files = Directory.GetFiles(Path.GetFullPath(path));
            foreach (string item in dirs)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                GetTreeViewPath(item, node.Nodes);
            }
            foreach (string item in files)
            {
                treeNodeCollection.Add(Path.GetFileName(item));
            }
        }

        #endregion

        #region 文件流操作   拷贝   加密

        /// <summary>
        /// 启用文件流进行文件的拷贝/加密/解密功能
        /// </summary>
        /// <param name="_OriginFilePath">源文件地址</param>
        /// <param name="NewFilePath">新建文件的目的地址</param>
        /// <param name="BufferSize">缓冲区大小（MB为单位）</param>
        /// <param name="Encrypt">是否进行加密处理</param>
        private void FileStreamOperate(string _OriginFilePath, string NewFilePath, int BufferSize, bool Encrypt)
        {
            try
            {
                using (FileStream fsRead = new FileStream(_OriginFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fsWrite = new FileStream(NewFilePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] Buffer = new byte[1024 * 1024 * BufferSize];
                        int byteCount = fsRead.Read(Buffer, 0, Buffer.Length);

                        while (byteCount > 0)
                        {
                            //文件加密
                            if (Encrypt)
                                for (int i = 1; i < Buffer.Length; i += Buffer.Length / 1024)
                                    Buffer[i] = (byte)(byte.MaxValue - Buffer[i]);

                            ////显示进度状态
                            //double ProgressLength = fsRead.Position * 1.0 / fsRead.Length;
                            //Console.WriteLine("已经拷贝了：{0}%", (int)(ProgressLength * 100));

                            fsWrite.Write(Buffer, 0, byteCount);
                            byteCount = fsRead.Read(Buffer, 0, Buffer.Length);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("启用文件流进行文件操作时出现错误！");
            }
        }

        /// <summary>
        /// 创建一个文件夹中没有的命名，防止重名导致文件覆盖
        /// </summary>
        /// <param name="_OriginFilePath">源文件的绝对路径</param>
        /// <returns>全新的文件名</returns>
        private string MakeNewFileName(string _OriginFilePath)
        {
            string NewFileName = Path.GetFileName(_OriginFilePath);
            string[] AllfileName = Directory.GetFiles(Path.GetDirectoryName(_OriginFilePath));
            for (int i = 0; i < AllfileName.Length; i++)
            {
                string[] _NewFileName = NewFileName.Split('(', ')');
                int num = Convert.ToInt32(_NewFileName[1]) + 1;
                NewFileName = _NewFileName[0] + "(" + num + ")" + _NewFileName[2];
                for (int j = 0; j < AllfileName.Length; j++)
                {
                    if (NewFileName == Path.GetFileName(AllfileName[j]))
                        break;
                    if (j == AllfileName.Length - 1)
                    {
                        return NewFileName;
                    }
                }
            }
            throw new Exception("出现未知错误，新文件命名失败！");
        }

        #endregion





        #endregion


    }
}
