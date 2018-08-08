using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _3._5操作系统作业.cs
{
    /// <summary>
    /// 静态的解析代码类
    /// </summary>
    static public class AnalysisCode
    {
        /// <summary>
        /// 解析代码
        /// </summary>
        /// <param name="code">单句代码</param>
        /// <param name="ProcessIndex">所属程序的索引</param>
        static public void AnalysisOneCode(string code, int ProcessIndex)
        {
            Regex reg = new Regex(@"[a-z]+", RegexOptions.ECMAScript);
            Match mat1 = reg.Match(code);

            #region 声明变量int型

            if (mat1.Value == "int")
            {
                //检测变量名
                Match mat2 = reg.Match(code, mat1.Index + mat1.Value.Length);
                //申请内存，存储变量
                int i = Store.ApplyVariable(ProcessIndex, mat2.Value, "int");
                if (i == -1)
                {
                    Queue.IntoBlockQueue(ProcessIndex, "variable");
                    CPU.Result = ReturnResult(8, null, null);
                    return;
                }
                //检测是否赋值
                Match mat3 = Regex.Match(code, "=");
                if (mat3.Success)
                {
                    Match mat4 = Regex.Match(code, @"\d+", RegexOptions.ECMAScript);
                    if (mat4.Success == true)//数字
                    {
                        CPU.Result = ReturnResult(1, mat2.Value, mat4.Value);
                        Store.VariableMemory[i].Value = Convert.ToInt32(mat4.Value);
                        Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                        return;
                    }
                }
            }

            #endregion

            #region 申请或释放资源

            else if (mat1.Value == "wait" || mat1.Value == "signal")
            {
                string[] onecode = code.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (onecode[0] == "wait")
                {
                    if (onecode[1] == "A" || onecode[1] == "B" || onecode[1] == "C")
                    {
                        //持续占用
                        if (onecode.Length == 2)
                        {
                            bool b = Store.ApplyResource(onecode[1], -1);
                            if (b)
                            {
                                CPU.Result = ReturnResult(5, onecode[1], null);
                                CPU.form.output("申请资源“" + onecode[1] + "”成功!");
                                Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                                return;
                            }
                            else
                            {
                                CPU.Result = ReturnResult(6, onecode[1], null);
                                Queue.IntoBlockQueue(CPU.ProcedureIndex, onecode[1]);
                                CPU.form.output("申请资源失败，程序进入阻塞队列");
                                return;
                            }
                        }
                        //规定时间占用
                        else if (onecode.Length == 3)
                        {
                            bool b = Store.ApplyResource(onecode[1], Convert.ToInt32(onecode[2]));
                            if (b)
                            {
                                CPU.Result = ReturnResult(5, onecode[1], null);
                                CPU.form.output("申请资源“" + onecode[1] + "”成功!");
                                Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                                return;
                            }
                            else
                            {
                                CPU.Result = ReturnResult(6, onecode[1], null);
                                Queue.IntoBlockQueue(CPU.ProcedureIndex, onecode[1]);
                                CPU.form.output("申请资源失败，程序进入阻塞队列");
                                return;
                            }
                        }

                    }
                    else
                    {
                        CPU.form.output("申请资源失败，未找到你想要申请的资源“" + onecode[1] + "”!");
                        CPU.Result = ReturnResult(6, onecode[1], null);
                        Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                        return;
                    }
                }
                else
                {
                    if (onecode[1] == "A" || onecode[1] == "B" || onecode[1] == "C")
                    {
                        Store.ReleaseResource(onecode[1]);
                        CPU.Result = ReturnResult(7, onecode[1], null);
                        CPU.form.output("释放资源“" + onecode[1] + "”成功!");
                        Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                        return;
                    }
                    else
                    {
                        CPU.form.output("释放资源失败，未找到您释放的资源“" + onecode[1] + "”!");
                        CPU.Result = ReturnResult(6, onecode[1], null);
                        Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                        return;

                    }
                }

            }

            #endregion

            #region 程序返回执行结果

            else if (mat1.Value == "return")
            {
                string[] str = code.Split(new char[] { ' ' });
                int i = IndexVariable(str[1], CPU.ProcedureIndex);
                if (i != -1)
                {
                    Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                    CPU.Result = ReturnResult(9, null, null);
                    CPU.form.output("程序返回“" + Store.VariableMemory[i].Value + "”。");
                }
            }

            #endregion

            #region ++或--运算

            else
            {
                int varindex = IndexVariable(mat1.Value, ProcessIndex);
                int index = code.IndexOf("++");
                if (index != -1)
                {
                    Store.VariableMemory[varindex].Value = (int)Store.VariableMemory[varindex].Value + 1;
                    Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                    CPU.Result = ReturnResult(4, mat1.Value, "++");
                    return;
                }
                else
                {
                    index = code.IndexOf("--");
                    if (index != -1)
                    {
                        Store.VariableMemory[varindex].Value = (int)Store.VariableMemory[varindex].Value - 1;
                        Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex++;
                        CPU.Result = ReturnResult(4, mat1.Value, "--");
                        return;
                    }
                }



            }





            #endregion

        }
        /// <summary>
        /// 根据变量名查找内存中的变量，返回内存数组检索值
        /// </summary>
        /// <param name="VariableName">变量名</param>
        /// <param name="ProcessIndex">所属程序的索引</param>
        /// <returns></returns>
        static public int IndexVariable(string VariableName, int ProcessIndex)
        {
            int i;
            for (i = 0; i < Store.VariableMemory.Length; i++)
                if (Store.VariableMemory[i].Name == VariableName && Store.VariableMemory[i].ProcessIndex == ProcessIndex)
                {
                    break;
                }
                else if (i + 1 == Store.VariableMemory.Length)
                    return -1;
            return i;
        }
        /// <summary>
        /// 返回解析代码的结果
        /// </summary>
        public static string ReturnResult(int type, string varname, string value)
        {
            switch (type)
            {
                case 1://创建变量，并赋值
                    return "声明变量“" + varname + "”，并赋值为“" + value + "”。";
                case 2://创建未赋值变量
                    return "声明未赋值变量“" + varname + "”。";
                case 3://进行赋值
                    return "将变量“" + varname + "”赋值为“" + value + "”。";
                case 4://运算
                    return "对“" + varname + "”进行“" + value + "”运算。";
                case 5://申请资源，通过
                    return "申请资源" + varname + "成功。";
                case 6://申请资源，未通过
                    return "申请资源" + varname + "失败。";
                case 7://资源释放
                    return "资源" + varname + "已释放。";
                case 8://内存不足
                    return "变量内存不足，建立变量内存失败";
                case 9://程序返回值
                    return "程序结束返回值";
                default:
                    return "出现未知错误";
            }
        }
    }


}
