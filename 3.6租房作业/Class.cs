using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._6租房作业
{
    //租约接口
    public interface ILeases
    {
        //获取租约信息
        string GetLeases();
    }

    public abstract class Lease
    {
        /// <summary>
        /// 租户
        /// </summary>
        public string LesseeName { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 租赁时间(单位：日or月)
        /// </summary>
        public abstract int LeasedTime { get; }
        /// <summary>
        /// 总租金
        /// </summary>
        public abstract long TotalRent { get; }
    }
    //年租约
    public class YearLease : Lease, ILeases
    {
        /// <summary>
        /// 月租金
        /// </summary>
        public int MonthRent { get; set; }
        /// <summary>
        /// 已交租金
        /// </summary>
        public int HaveToPayRent { get; set; }
        /// <summary>
        /// 租赁时间(单位：日or月)
        /// </summary>
        public override int LeasedTime
        {
            get
            {
                int year = this.EndTime.Year - this.StartTime.Year;
                int month = this.EndTime.Month - this.StartTime.Month;
                return year * 12 + month + 1;
            }
        }
        /// <summary>
        /// 总租金
        /// </summary>
        public override long TotalRent { get { return this.MonthRent * this.LeasedTime; } }
        /// <summary>
        /// 欠款
        /// </summary>
        public long Debt { get { return this.HaveToPayRent > this.TotalRent ? 0 : this.TotalRent - this.HaveToPayRent; } }

        public string GetLeases()
        {
            string Leases = "";
            Leases += "租赁人：\t" + this.LesseeName;
            Leases += "\n月租金：\t" + this.MonthRent + "元";
            Leases += "\n起始时间：\t" + this.StartTime.ToString("d");
            Leases += "\n终止时间：\t" + this.EndTime.ToString("d");
            Leases += "\n总计租赁时间：\t" + this.LeasedTime + "月";
            Leases += "\n总计租金：\t" + this.TotalRent + "元";
            Leases += "\n已交租金：\t" + this.HaveToPayRent + "元";
            Leases += "\n欠款：\t\t" + this.Debt + "元";
            return Leases;
        }
    }

    //日租约
    public class DayLease : Lease, ILeases
    {
        /// <summary>
        /// 日租金
        /// </summary>
        public int DayRent { get; set; }
        /// <summary>
        /// 租赁时间(单位：日or月)
        /// </summary>
        public override int LeasedTime { get { return this.EndTime.Subtract(this.StartTime).Days + 1; } }
        /// <summary>
        /// 总租金
        /// </summary>
        public override long TotalRent { get { return this.DayRent * this.LeasedTime; } }

        public string GetLeases()
        {
            string Leases = "";
            Leases += "租赁人：\t" + this.LesseeName;
            Leases += "\n月租金：\t" + this.DayRent + "元";
            Leases += "\n起始时间：\t" + this.StartTime.ToString("d");
            Leases += "\n终止时间：\t" + this.EndTime.ToString("d");
            Leases += "\n总计租赁时间：\t" + this.LeasedTime + "日";
            Leases += "\n总计租金：\t" + this.TotalRent + "元";
            return Leases;
        }
    }

}
