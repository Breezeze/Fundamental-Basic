using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    class aaa215
    {
        public int Public { get; set; }
        private int Private { get; set; }
        protected int Protected { get; set; }
        protected int _protected;
        internal int Internal { get; set; }
    }

    class bbb215 : aaa215
    {
        public void bb()
        {
            this.Protected = 0;
            this.Internal = 0;
            this._protected = 0;
        }
    }
}
