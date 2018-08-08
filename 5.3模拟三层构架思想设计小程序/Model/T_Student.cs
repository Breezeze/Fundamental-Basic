using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.模拟三层构架思想设计小程序.BLL
{
    class T_Student
    {
        public T_Student() { }
        public T_Student(int Nid, string StudentName, string StudentNu, string Gender, int Age)
        {
            this.Nid = Nid;
            this.StudentName = StudentName;
            this.StudentNu = StudentNu;
            this.Gender = Gender;
            this.Age = Age;
        }
        public int Nid { get; set; }
        public string StudentName { get; set; }
        public string StudentNu { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
