using System;
using System.Collections.Generic;

namespace FullStack.FrameWork.Common.Query
{
    public class SearchQueryObject : QueryObject
    {
        public string? Search { get; set; }
    }

    public class SearchQueryObject<TFilter> : SearchQueryObject
    {
        public TFilter Filter { get; set; }
    }

    public class SearchQueryObjectPostRequest : IQueryObject
    {
        public string Search { get; set; }

        public SearchQueryObjectPostRequest()
        {
            Paging = new Paging();
            Order = new List<Order>();
        }

        public Paging Paging { get; set; }

        public IEnumerable<Order> Order { get; set; }

        public string OrderBy => String.Join(",", Order);

        public string[]? OptionalColumns { get; set; }
    }
}
