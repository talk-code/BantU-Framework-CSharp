using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IUSSDFilter
    {
        public void doFilter(IUSSDRequest request, IUSSDSession<Object> session, IUSSDResponse response, USSDFilteringChain execution);
    }
}
