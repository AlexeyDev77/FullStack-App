using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.FrameWork.Common.Query
{
    public interface IPaging
    {
        int Skip { get; }
        int Take { get; }
        bool? TakeAll { get; set; }
    }
}
