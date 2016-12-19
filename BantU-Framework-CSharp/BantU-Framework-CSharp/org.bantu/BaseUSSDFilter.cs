using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BaseUSSDFilter : USSDFilter
    {
        public ProceedProcessing proceedProcessing { set; get; }
        public Window currentWindow { get; set; }
        public String currentWindowName { get; set; }

        public void doFilter(USSDRequest request, USSDSession<Object> session, USSDResponse response, USSDFilteringChain chain)
        {
            proceedProcessing(request, session, response, currentWindowName, currentWindow);
        }

        public delegate void ProceedProcessing(USSDRequest request, USSDSession<object> session, USSDResponse response, String currentWindowName, Window currentWindow);
    }
}
