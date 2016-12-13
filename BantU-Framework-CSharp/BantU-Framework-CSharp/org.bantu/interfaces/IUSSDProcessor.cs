using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IUSSDProcessor
    {
        void process(IUSSDRequest request, IUSSDSession<Object> session, IUSSDResponse response);
    }
}
