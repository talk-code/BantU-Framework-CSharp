/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface USSDFilteringChain
    {
        void proceed(USSDRequest request, USSDSession<Object> USSDSession, USSDResponse response);
        void appendFilter(USSDFilter filter);
    }
}
