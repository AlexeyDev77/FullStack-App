using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.FrameWork.Common.Query
{
    public class Order
    {
        public string Column { get; set; }

        public string Dir { get; set; }

        public Order()
        {

        }

        public Order(string column, string dir)
        {
            Column = column;
            Dir = dir;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Column, Dir);
        }
    }
}
