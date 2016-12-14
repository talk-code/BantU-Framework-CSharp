/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IUSSDFilteringChain
    {
        void proceed(IUSSDRequest request, IUSSDSession<Object> USSDSession, IUSSDResponse response);
        void appendFilter(IUSSDFilter filter);
    }
}
