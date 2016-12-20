using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    class BaseUSSDFilteringChain: USSDFilteringChain
    {
        public List<USSDFilter> Filters { get; set; }

        public void proceed(USSDRequest request, USSDSession<Object> session, USSDResponse response)
        {
            if (Filters.Count > 0)
                Filters.ElementAt(0).doFilter(request, session, response, this);
        }

        public void appendFilter(USSDFilter filter)
        {
            Filters.Add(filter);
        }
    }
}
