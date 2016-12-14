/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IUSSDFilter
    {
        void doFilter(IUSSDRequest request, IUSSDSession<Object> session, IUSSDResponse response, IUSSDFilteringChain execution);
    }
}
