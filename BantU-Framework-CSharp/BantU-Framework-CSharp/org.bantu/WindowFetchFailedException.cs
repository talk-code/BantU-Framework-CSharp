using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class WindowFetchFailedException: BantURequestException
    {
        public WindowFetchFailedException(String windowId, USSDRequest request, USSDResponse response, USSDSession<Object> session)
            :base(String.Format("Failed to fetch window with Id {%s} from NavigationCache", windowId), request, response, session)
        {
        }
    }
}
