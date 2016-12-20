using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class WindowStoreFailedException: BantURequestException
    {
        public WindowStoreFailedException(String windowId, USSDRequest request, USSDResponse response, USSDSession<Object> session)
            : base(String.Format("Failed to store window with Id {%s} in NavigationCache", windowId), request, response, session)
        {            
        }
    }
}
